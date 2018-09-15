using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamStart.Interfaces
{
    public interface IPlatformStuff
    {
        string GetVersion();
        string GetAppName();
        string GetLocalFilePath(string filename);
        string GetBaseUrl();
    }
}
