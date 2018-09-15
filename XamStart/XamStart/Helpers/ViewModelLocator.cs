using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;
using Xamarin.Forms;
using XamStart.Factories;
using XamStart.Interfaces;
using XamStart.Services;
using XamStart.ViewModels;
using XamStart.Views;

namespace XamStart.Helpers
{
    public class ViewModelLocator: IViewModelLocator
    {
        public static IUnityContainer Container { get; set; }
        public IMasterDetailPageMasterViewModel MasterDetailPageMasterViewModel => Container.Resolve<IMasterDetailPageMasterViewModel>();
        public IErrorPageViewModel ErrorPageViewModel => Container.Resolve<IErrorPageViewModel>();
        public IHelpPageViewModel HelpPageViewModel => Container.Resolve<IHelpPageViewModel>();
        public ILoginPageViewModel LoginPageViewModel => Container.Resolve<ILoginPageViewModel>();
        public ISettingsPageViewModel SettingsPageViewModel => Container.Resolve<ISettingsPageViewModel>();
        public ILogoutPageViewModel LogoutPageViewModel => Container.Resolve<ILogoutPageViewModel>();
        public IHomePageViewModel HomePageViewModel => Container.Resolve<IHomePageViewModel>();

        static ViewModelLocator()
        {
            var _platformStuff = DependencyService.Get<IPlatformStuff>();
            var _logoutService = DependencyService.Get<IPlatformLogout>();
            var _sendEmailService = DependencyService.Get<ISendEmailService>();
            var _toastService = DependencyService.Get<IToastService>();
            Container = Container ?? new UnityContainer();

            // Dependency Services
            Container.RegisterInstance<IPlatformStuff>(_platformStuff);
            Container.RegisterInstance<ISendEmailService>(_sendEmailService);
            Container.RegisterInstance<IPlatformLogout>(_logoutService);
            Container.RegisterInstance<IToastService>(_toastService);

            //singleton  see: https://msdn.microsoft.com/en-us/library/ff647854.aspx
            Container.RegisterType<ICurrentlySelectedFactory, CurrentlySelectedFactory>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IAPIFactory, APIFactory>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILoginService, LoginService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IWidgetService, WidgetService>(new ContainerControlledLifetimeManager());


            // Views
            Container.RegisterType<ILoginPage, LoginPage>();
            Container.RegisterType<IMDPage, MDPage>(new MDPageLifetimeManager());
            Container.RegisterType<IErrorPage, ErrorPage>();
            Container.RegisterType<IHelpPage, HelpPage>();
            Container.RegisterType<IHomePage, Home>();
            Container.RegisterType<ISettingsPage, SettingsPage>();

            // ViewModels
            Container.RegisterType<IErrorPageViewModel, ErrorPageViewModel>();
            Container.RegisterType<IHelpPageViewModel, HelpPageViewModel>();
            Container.RegisterType<ISettingsPageViewModel, SettingsPageViewModel>();
            Container.RegisterType<ILoginPageViewModel, LoginPageViewModel>();
            Container.RegisterType<ILogoutPageViewModel, LogoutPageViewModel>();
            Container.RegisterType<IMasterDetailPageMasterViewModel, MasterDetailPageMasterViewModel>();
            Container.RegisterType<IHomePageViewModel, HomePageViewModel>();


            var unityServiceLocator = new UnityServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }
    }
}
