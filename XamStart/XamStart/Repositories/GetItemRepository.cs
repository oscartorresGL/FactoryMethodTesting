using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamStart.Interfaces;
using XamStart.Models;
using XamStart.Repositories;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetItemRepository))]
namespace XamStart.Repositories
{
    public class GetItemRepository : BaseRepository, IGetItemRepository
    {
        public GetItemRepository(ICurrentlySelectedFactory currentlySelectedFactory) : base(currentlySelectedFactory) { }
        public async Task<T> Search<T>(string uri, string query = "") 
            where T : new()
        {
            if (String.IsNullOrEmpty(query))
            {
                return await GetAsync<T>(uri);
            } else
            {
                return await GetAsync<T>(uri + query.ToString());
            }
            
        }
    }
}
