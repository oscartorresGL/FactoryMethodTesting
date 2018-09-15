using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XamStart.Interfaces;
using XamStart.iOS.DependencyServices;
using XamStart.Models;

[assembly: Dependency(typeof(ToastService))]
namespace XamStart.iOS.DependencyServices
{
    public class ToastService : IToastService
    {
        // Code stolen from here:  http://sezeromer.com/xamarin-forms-ios-toast-mesaj/ 
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;
        public void CookIt(string message, MyToastLength length)
        {
            var toastLength = (length == MyToastLength.Long) ? LONG_DELAY : SHORT_DELAY;
            alertDelay = NSTimer.CreateRepeatingScheduledTimer(toastLength, (obj) =>
            {
                MesajReddet();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void MesajReddet()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);

            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}