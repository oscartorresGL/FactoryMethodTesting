using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XamStart.Interfaces;
using XamStart.iOS.DependencyServices;

[assembly: Dependency(typeof(LogoutService))]
namespace XamStart.iOS.DependencyServices
{
    public class LogoutService : IPlatformLogout
    {
        public LogoutService()
        {

        }
        public void Logout()
        {
            NSHttpCookieStorage CookieStorage = NSHttpCookieStorage.SharedStorage;

            foreach (var cookie in CookieStorage.Cookies)
            {
                CookieStorage.DeleteCookie(cookie);
            }
        }
    }
}