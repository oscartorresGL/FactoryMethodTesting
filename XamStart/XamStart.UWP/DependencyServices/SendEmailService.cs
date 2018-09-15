using XamStart.UWP.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamStart.Interfaces;
using Windows.ApplicationModel.Contacts;
using Windows.ApplicationModel.Email;

[assembly: Dependency(typeof(SendEmailService))]
namespace XamStart.UWP.DependencyServices
{
    public class SendEmailService : ISendEmailService
    {
        public void ComposeMail(string[] recipients, string subject, string messagebody = null, Action<bool> completed = null)
        {
            List<ContactEmail> contacts = new List<ContactEmail>();
            foreach(var email in recipients)
            {
                contacts.Add(new ContactEmail()
                {
                    Address = email
                });
            }

            ComposeEmail(contacts, subject, messagebody);
        }

        private void ComposeEmail(List<ContactEmail> contacts, string subject, string messageBody)
        {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Body = messageBody;
            foreach(var address in contacts)
            {
                var emailRecipient = new EmailRecipient(address.Address);
                emailMessage.To.Add(emailRecipient);
            }            
            emailMessage.Subject = subject;

            Device.BeginInvokeOnMainThread(async () =>
            {
                await EmailManager.ShowComposeNewEmailAsync(emailMessage);
            });
            
        }
    }
}
