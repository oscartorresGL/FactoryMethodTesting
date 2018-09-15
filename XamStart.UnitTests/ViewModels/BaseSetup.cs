using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamStart.Interfaces;

namespace XamStart.UnitTests.ViewModels
{
    public abstract class BaseSetup
    {
        protected Mock<ICurrentlySelectedFactory> currentlySelectedFactory;
        

        protected void SetupBaseMocks()
        {
            currentlySelectedFactory = new Mock<ICurrentlySelectedFactory>();
        }

    }
}
