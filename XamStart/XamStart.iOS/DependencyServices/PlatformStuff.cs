using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using XamStart.Interfaces;
using XamStart.iOS.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformStuff))]
namespace XamStart.iOS.DependencyServices
{
    class PlatformStuff : IPlatformStuff
    {
        //public string GetPersonalPath => System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }

        public string GetBaseUrl()
        {
            return NSBundle.MainBundle.BundlePath + "/web";
        }

        public string GetVersion()
        {
            return NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();
        }

        public string GetAppName()
        {
            return NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleDisplayName")].ToString();
        }
    }
}