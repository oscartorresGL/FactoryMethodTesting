using System;
using System.Collections.Generic;
using System.Text;

namespace XamStart.Interfaces
{
    public interface ISendEmailService
    {
        void ComposeMail(string[] recipients, string subject, string messagebody = null, Action<bool> completed = null);
    }
}
