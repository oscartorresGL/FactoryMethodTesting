using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Notifications;
using Xamarin.Forms;
using XamStart.Interfaces;
using XamStart.Models;
using XamStart.UWP.DependencyServices;

[assembly: Dependency(typeof(ToastService))]
namespace XamStart.UWP.DependencyServices
{
    public class ToastService : IToastService
    {
        public void CookIt(string message, MyToastLength length)
        {
            var xmdock = CreateToast(message);
            var toast = new ToastNotification(xmdock);
            // Next show the toast using ToastNotificationManager class.  
            var notifi = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();
            notifi.Show(toast);  
        }

        public static Windows.Data.Xml.Dom.XmlDocument CreateToast(string message)
        {
            var xDoc = new XDocument(
               new XElement("toast",
               new XElement("visual",
               new XElement("binding", new XAttribute("template", "ToastGeneric"),
               new XElement("text", message)               
               //,new XElement("text", "Are you sure?") // uncomment for second line
            )
            ) // for actions uncomment following
            //,
            //new XElement("actions",
            //new XElement("action", new XAttribute("activationType", "background"),
            //new XAttribute("content", "Yes"), new XAttribute("arguments", "yes")),
            //new XElement("action", new XAttribute("activationType", "background"),
            //new XAttribute("content", "No"), new XAttribute("arguments", "no"))
            //)
            )
            );

            var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
            xmlDoc.LoadXml(xDoc.ToString());
            return xmlDoc;
        }
    }

    
}
