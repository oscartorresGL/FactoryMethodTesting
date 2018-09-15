
#if (DEBUG == false)
#define ISSECURE
#endif
using System;
using System.Collections.Generic;
using System.Text;
using XamStart.Interfaces;
using Xamarin.Forms;
using XamStart.Factories;

namespace XamStart.Factories
{
    public class APIFactory : IAPIFactory
    {

        // Azure AD Config
        private readonly string azureClientId = "the id"; 
        private readonly string azureAuthority = "https://login.windows.net/common";
        private readonly string azureReturnUri = "the return uri";
        //private readonly string azureGraphResourceUri = "https://graph.windows.net";
        private readonly string azureGraphResourceUri = "resource URI"; // TodoListService

        
        public string AzureClientId()
        {
            return azureClientId;
        }
        public string AzureAuthority()
        {
            return azureAuthority;
        }
        public string AzureReturnUri()
        {
            return azureReturnUri;
        }
        public string AzureGraphResourceURI()
        {
            return azureGraphResourceUri;
        }
        
    }
}
