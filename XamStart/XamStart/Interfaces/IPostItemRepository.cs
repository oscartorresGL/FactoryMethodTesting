using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamStart.Interfaces
{
    public interface IPostItemRepository
    {
        Task<T> Search<T, G>(G search, string uri)
            where T : new();
    }
}
