using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamStart.Helpers;
using XamStart.Interfaces;
using XamStart.Models;
using Unity;
using Unity.Resolution;

namespace XamStart.Factories
{
    public class ResponseHttpObjFactory : HttpObjFactoryBase, IResponseHttpObjFactory
    {
        public override IHttpObj CreateWidget(string json)
        {
            // following is a way to consume property names that came back from 
            // the api in a different format (in this case with underscores) without
            // having to create another model
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = (CustomContractResolver)ViewModelLocator.Container.Resolve<ICustomContractResolver>(new ParameterOverrides{
                {"dict", new Dictionary<string, string>
                    {
                        {"lastName", "last_Name"},
                        {"firstName", "first_Name"},
                    }
                }
            });
            var x = JsonConvert.DeserializeObject<Widget>(json, settings);
            return x;
        }
        public override IHttpObj CreateWidget(IHttpObj httpObj)
        {
            throw new NotImplementedException();
        }

        public override List<IHttpObj> CreateWidgetList(string json)
        {
            var jsonList = JsonConvert.DeserializeObject<List<Widget>>(json);

            var returnList = jsonList.ConvertAll<IHttpObj>(x => (IHttpObj)x);
            return returnList;
        }
    }
}
