using System;
using System.Collections.Generic;
using System.Text;
using XamStart.Factories;
using XamStart.Models;

namespace XamStart.Interfaces
{
    public interface ICurrentlySelectedFactory
    {
        ErrorItem LastError{ get; set; }
        User SelectedUser { get; set; }
        string Token { get; set; }
        Type DesiredMasterDetailDetailPage { get; set; }
    }
}