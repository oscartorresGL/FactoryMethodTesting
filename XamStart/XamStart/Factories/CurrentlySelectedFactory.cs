using XamStart.Factories;
using XamStart.Helpers;
using XamStart.Interfaces;
using XamStart.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace XamStart.Factories
{
    public class CurrentlySelectedFactory : ICurrentlySelectedFactory
    {        
        public ErrorItem LastError { get; set; }
        public User SelectedUser { get; set; }
        public string Token { get; set; }
        public Type DesiredMasterDetailDetailPage { get; set; }
    }
}
