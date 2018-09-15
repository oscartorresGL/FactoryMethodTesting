using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xamarin.Forms;
using XamStart.Factories;
using XamStart.Interfaces;
using XamStart.ViewModels;

namespace XamStart.UnitTests.ViewModels
{
    [TestClass]
    public class MasterDetailPageMasterViewModelTests : BaseSetup
    {
        MasterDetailPageMasterViewModel sut;
        
        [TestInitialize()]
        public void Initialize() {
            SetupBaseMocks();
            sut = new MasterDetailPageMasterViewModel(currentlySelectedFactory.Object);

        }
        [TestCleanup()]
        public void Cleanup() {
        }

        [TestMethod]
        public void Constructor_ShouldSet_MenuItems()
        {
            // arrange            


            // act


            // assert
            Assert.IsTrue(sut.MenuItems.Count >= 1);
            
        }
    }
}
