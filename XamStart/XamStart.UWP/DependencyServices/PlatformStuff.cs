using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Xamarin.Forms;
using XamStart.Interfaces;
using XamStart.UWP.DependencyServices;

[assembly: Dependency(typeof(PlatformStuff))]
namespace XamStart.UWP.DependencyServices
{
    public class PlatformStuff : IPlatformStuff
    {
        //public string GetPersonalPath => Windows.Storage.ApplicationData.Current.LocalFolder.Path;
        public string GetLocalFilePath(string filename) => Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        public string GetBaseUrl()
        {
            return "ms-appx-web:///" + "web/";
        }

        public string GetVersion()
        {
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;
            return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        public string GetAppName()
        {
            return Package.Current.DisplayName;
        }
    }
}
