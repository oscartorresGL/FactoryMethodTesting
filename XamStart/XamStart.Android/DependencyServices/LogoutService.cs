using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Xamarin.Forms;
using XamStart.Droid.DependencyServices;
using XamStart.Interfaces;

[assembly: Dependency(typeof(LogoutService))]
namespace XamStart.Droid.DependencyServices
{
    public class LogoutService : IPlatformLogout
    {
        public void Logout()
        {
            CookieManager.Instance.RemoveAllCookie();
        }
    }
}