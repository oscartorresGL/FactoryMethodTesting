using System;
using System.Collections.Generic;
using System.IO;
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

[assembly: Xamarin.Forms.Dependency(typeof(PlatformStuff))]
namespace XamStart.Droid.DependencyServices
{
    public class PlatformStuff : IPlatformStuff
    {
        internal static Func<Context> GetContext { get; set; }
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }

        public string GetBaseUrl()
        {
            //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            return "file:///android_asset/web/";
        }

        public string GetVersion()
        {
            var Context = GetContext();
            return Context.PackageManager.GetPackageInfo(Context.PackageName, 0).VersionName;
        }

        public string GetAppName()
        {
            //ApplicationInfo.LoadLabel(PackageManager);
            var Context = GetContext();
            var applicationInfo = Context.ApplicationInfo;
            int stringId = applicationInfo.LabelRes;
            return stringId == 0 ? applicationInfo.NonLocalizedLabel.ToString() : Context.GetString(stringId);
        }

    }
}