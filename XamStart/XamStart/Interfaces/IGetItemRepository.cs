using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamStart.Interfaces
{
    public interface IGetItemRepository
    {
        Task<T> Search<T>(string uri, string query = "")
            where T : new();
    }
}
