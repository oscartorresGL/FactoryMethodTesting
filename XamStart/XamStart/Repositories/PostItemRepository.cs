using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamStart.Interfaces;
using XamStart.Repositories;
using Xamarin.Forms;

[assembly: Dependency(typeof(PostItemRepository))]
namespace XamStart.Repositories
{
    
    public class PostItemRepository : BaseRepository, IPostItemRepository
    {
        public PostItemRepository(ICurrentlySelectedFactory currentlySelectedFactory) : base(currentlySelectedFactory) { }
        public async Task<T> Search<T,G>(G search, string uri)
            where T : new()
        {
            return await PostAsync<T, G>(search, uri);
        }
    }
}
