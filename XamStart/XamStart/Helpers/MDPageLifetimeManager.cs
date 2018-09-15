using System;
using Unity.Lifetime;
using XamStart.Interfaces;
using Unity;

namespace XamStart.Helpers
{
    public class MDPageLifetimeManager
        : SingletonLifetimeManager
    {
        protected override object SynchronizedGetValue(ILifetimeContainer container = null)
        {
                var currentlySelectedFactory = ViewModelLocator.Container.Resolve<ICurrentlySelectedFactory>();
                if (currentlySelectedFactory.DesiredMasterDetailDetailPage == null) {
                    return base.SynchronizedGetValue(container);
                } else {
                    return null;
                }
        }
        protected override void SynchronizedSetValue(object newValue, ILifetimeContainer container = null)
        {
            base.SynchronizedSetValue(newValue, container);
        }
    }
}
