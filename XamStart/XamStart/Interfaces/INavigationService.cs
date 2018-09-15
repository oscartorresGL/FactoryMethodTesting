using System;
using System.Threading.Tasks;

namespace XamStart.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToChildPage(Type type);
        void MDDetailPageNavigate(Type type);
        void RootNavigate(Type type);
        Task NavigateToChildModalPage(Type type);
        Task PopAsync();
        Task PopModalAsync();
    }
}
