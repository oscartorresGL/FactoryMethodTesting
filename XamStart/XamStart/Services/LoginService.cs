using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamStart.Interfaces;
using XamStart.Models;

namespace XamStart.Services
{
    public class LoginService : ILoginService
    {
        private readonly ICurrentlySelectedFactory currentlySelectedFactory;
        private readonly IAPIFactory aPIFactory;
        public LoginService(IAPIFactory aPIFactory, ICurrentlySelectedFactory currentlySelectedFactory)
        {
            this.aPIFactory = aPIFactory;
            this.currentlySelectedFactory = currentlySelectedFactory;
        }
        public async Task<bool> Login()
        {
            await Task.Delay(1000);
            this.currentlySelectedFactory.SelectedUser = new User()
            {
                fullName = "John Doe",
                email = "me@aol.com"
            };
            return true;
        }

        public void Logout()
        {
            // do task like clear token
        }
    }
}
