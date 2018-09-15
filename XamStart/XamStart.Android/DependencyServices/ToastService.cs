using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XamStart.Droid.DependencyServices;
using XamStart.Interfaces;
using XamStart.Models;

[assembly: Dependency(typeof(ToastService))]
namespace XamStart.Droid.DependencyServices
{
    public class ToastService : IToastService
    {
        internal static Func<Context> GetContext { get; set; }
        
        public void CookIt(string message, MyToastLength length)
        {
            var context = GetContext();
            var toastLength = (length == MyToastLength.Long) ? ToastLength.Long : ToastLength.Short;
            Toast.MakeText(context, message, toastLength).Show();
        }
        
    }
}