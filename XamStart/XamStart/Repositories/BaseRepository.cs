using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamStart.Interfaces;
using Unity;

namespace XamStart.Repositories
{
    public class BaseRepository
    {
        ICurrentlySelectedFactory currentlySelectedFactory;

        string resultTemp;
        public BaseRepository(ICurrentlySelectedFactory currentlySelectedFactory)
        {
            this.currentlySelectedFactory = currentlySelectedFactory;
        }
        private HttpClient Initialize()
        {
            
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        protected async Task<T> GetAsync<T>(string url)
            where T : new()
        {
            HttpClient httpClient = Initialize();
#if (DEBUG == false)
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", currentlySelectedFactory.Token);
#endif
            T result;

            try
            {
                resultTemp = await httpClient.GetStringAsync(url);
                //new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
                result = await Task.Run(() => JsonConvert.DeserializeObject<T>(resultTemp, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                //result = await Task.Run(() => JsonConvert.DeserializeObject<T>(response));
            }
            catch(Exception e)
            {
                var error = "";
                var isHtml = false;
                if (resultTemp.Contains("!DOCTYPE"))
                {
                    error = resultTemp;
                    isHtml = true;
                }
                else
                {
                    error = e.Message;
                    
                }
                currentlySelectedFactory.LastError = new Models.ErrorItem()
                {
                    date = DateTime.Now.ToString(),
                    issue = error,
                    isHTML = isHtml
                };
                result = new T();
            }
            return result;
        }

        protected async Task<T> PostAsync<T,G>(G item, string url)
            where T : new()
        {
            HttpClient httpClient = Initialize();
#if (DEBUG == false)
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", currentlySelectedFactory.Token);
#endif
            T result;
            var dict = new Dictionary<string, string>();            

            foreach (var prop in item.GetType().GetProperties())
            {
                dict.Add(prop.Name, prop.GetValue(item, null).ToString());            }


#if (DEBUG == true)
            // view the content as Json
            string myJsonString = JsonConvert.SerializeObject(dict);
#endif

            var content = new FormUrlEncodedContent(dict);
            
            try
            {
                var response = await httpClient.PostAsync(url, content);
                resultTemp = await response.Content.ReadAsStringAsync();
                if(resultTemp == "{\"message\":\"Authorization has been denied for this request.\"}")
                {
                    ProcessError("Authorization has been denied for this request", false);
                    result = new T();
                }
                else
                {
                    try
                    {
                        result = JsonConvert.DeserializeObject<T>(resultTemp, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    }
                    catch (JsonSerializationException ex)
                    {
                        ProcessError(ex.Message, false);
                        result = new T();
                    }
                }
                

                //result = await Task.Run(() => JsonConvert.DeserializeObject<T>(resultTemp, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            }
            catch(Exception e)
            {
                if(resultTemp == null)
                {
                    ProcessError("No response, check connection", false);
                }
                else if (resultTemp.Contains("!DOCTYPE"))
                {
                    ProcessError(resultTemp, true);
                }
                else
                {
                    ProcessError(e.Message, false);
                }
                       
                result = new T();
            }            


            return result;
        }
        private void ProcessError(string error, bool isHtml)
        {
            currentlySelectedFactory.LastError = new Models.ErrorItem()
            {
                date = DateTime.Now.ToString(),
                issue = error,
                isHTML = isHtml
            };
        }
        
    }
}
