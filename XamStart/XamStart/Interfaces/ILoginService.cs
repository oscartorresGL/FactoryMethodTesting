using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamStart.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Login();
    }
}
