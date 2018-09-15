using System;
using System.Collections.Generic;
using System.Text;
using XamStart.Models;

namespace XamStart.Interfaces
{
    public interface IToastService
    {
        void CookIt(string message, MyToastLength length);
    }
}
