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
using XamStart.Droid.DependencyServices;
using XamStart.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SendEmailService))]
namespace XamStart.Droid.DependencyServices
{
    public class SendEmailService : Java.Lang.Object, ISendEmailService
    {

        public SendEmailService() { }
        //public void SendMail(List<string> to, List<string> cc, string subject, string body, Object controlToPresent)
        public void ComposeMail(string[] recipients, string subject, string messagebody = null, Action<bool> completed = null)
        {
            
            var email = new Intent(Intent.ActionSend);
            email.PutExtra(Intent.ExtraEmail, recipients);
            email.PutExtra(Intent.ExtraSubject, subject);
            email.PutExtra(Intent.ExtraText, messagebody);
            email.PutExtra(Intent.ExtraHtmlText, true);
            email.SetType("message/rfc822");
            MainActivity.Context.StartActivity(Intent.CreateChooser(email, "Send Email Via"));

        }
    }
}