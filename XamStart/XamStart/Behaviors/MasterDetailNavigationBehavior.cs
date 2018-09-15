using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamStart.Helpers;
using Unity;
using XamStart.Interfaces;

namespace XamStart.Behaviors
{
    public class MasterDetailNavigationBehavior : Behavior<MasterDetailPage>
    {
        protected override void OnAttachedTo(BindableObject bindable)
        {
            ICurrentlySelectedFactory currentlySelectedFactory = ViewModelLocator.Container.Resolve<ICurrentlySelectedFactory>();
            Page pg = (Page)ViewModelLocator.Container.Resolve<IHomePage>();  // default home page if nothing was specified
            if (currentlySelectedFactory.DesiredMasterDetailDetailPage != null)
            {
                pg = (Page)ViewModelLocator.Container.Resolve(currentlySelectedFactory.DesiredMasterDetailDetailPage);
                currentlySelectedFactory.DesiredMasterDetailDetailPage = null;
            }
            ((MasterDetailPage)bindable).Detail = new NavigationPage(pg);
            base.OnAttachedTo(((MasterDetailPage)bindable));
        }
    }
}

