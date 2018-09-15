using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamStart.Interfaces;
using XamStart.UWP.DependencyServices;

[assembly: Dependency(typeof(LogoutService))]
namespace XamStart.UWP.DependencyServices
{
    public class LogoutService : IPlatformLogout
    {
        public void Logout()
        {
            throw new NotImplementedException();
            // you have to know the uri you are calling in order to use the below method

            //var apiFactory = new APIFactory();
            //Windows.Web.Http.Filters.HttpBaseProtocolFilter myFilter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
            //var cookieManager = myFilter.CookieManager;
            //HttpCookieCollection myCookieJar = cookieManager.GetCookies(new System.Uri(apiFactory.AzureAuthority()));
            //foreach (HttpCookie cookie in myCookieJar)
            //{
            //    cookieManager.DeleteCookie(cookie);
            //}
        }
    }
}
