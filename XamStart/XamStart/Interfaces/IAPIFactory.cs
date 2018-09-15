using System;
using System.Collections.Generic;
using System.Text;

namespace XamStart.Interfaces
{
    public interface IAPIFactory
    {
        string AzureGraphResourceURI();
        string AzureReturnUri();
        string AzureAuthority();
        string AzureClientId();
    }
}
