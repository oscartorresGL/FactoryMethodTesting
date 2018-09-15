using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MessageUI;
using UIKit;
using Xamarin.Forms;
using XamStart.Interfaces;
using XamStart.iOS.DependencyServices;

[assembly: DependencyAttribute(typeof(SendEmailService))]
namespace XamStart.iOS.DependencyServices
{
    public class SendEmailService : ISendEmailService
    {
        public void ComposeMail(string[] recipients, string subject, string messagebody = null, Action<bool> completed = null)
        {
            if (MFMailComposeViewController.CanSendMail)
            {
                var controller = new MFMailComposeViewController();
                controller.SetToRecipients(recipients);
                controller.SetSubject(subject);
                if (!string.IsNullOrEmpty(messagebody))
                    controller.SetMessageBody(messagebody, false);
                controller.Finished += (object sender, MFComposeResultEventArgs e) => {
                    if (completed != null)
                        completed(e.Result == MFMailComposeResult.Sent);
                    e.Controller.DismissViewController(true, null);
                };

                //Adapt this to your app structure
                //var rootController = ((AppDelegate)(UIApplication.SharedApplication.Delegate)).Window.RootViewController.ChildViewControllers[0].ChildViewControllers[1].ChildViewControllers[0];
                var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;
                var navcontroller = rootController as UINavigationController;
                if (navcontroller != null)
                    rootController = navcontroller.VisibleViewController;
                rootController.PresentViewController(controller, true, null);
            }

        }
    }
}