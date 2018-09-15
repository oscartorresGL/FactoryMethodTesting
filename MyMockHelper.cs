using System;

public class Class1
{
    public class MyMockHelper
    {
        private SettingsFactory settingsFactory;


        private ICurrentlySelectedFactory currentlySelectedFactory;
        public MyMockHelper()
        {
            currentlySelectedFactory = new CurrentlySelectedFactory();
        }
        public void SetupMockForViewModels(AutoMock mock)
        {
            settingsFactory = new SettingsFactory(defaultsFactory);
            var sqlLiteRepository = new MockSQLiteRepository(defaultsFactory);
            var settingsService = new SettingsService(sqlLiteRepository, settingsFactory);
            mock.Provide<ISettingsService>(settingsService);
            mock.Provide<ISettingsFactory>(settingsFactory);
            mock.Provide<IDefaultsFactory>(defaultsFactory);
            // the following will allow autofaq to automatically inject IPlatformStuffService
            // It will also change the normal operation of GetBaseUrl()
            // since that single method is the only difficult to test method, no point in creating a 
            // custom mock for the entire service.
            mock.Mock<IPlatformStuffService>().Setup(x => x.GetBaseUrl()).Returns("some base url");
        }

        public void RunBaseViewModelTests(IBaseViewModel sut)
        {
            // Assert   
            Assert.False(string.IsNullOrEmpty(sut.Title), "You didn't set a title");
            Assert.False(string.IsNullOrWhiteSpace(sut.Greeting), "You didn't set a greeting");
            Assert.Equal(defaultsFactory.GetFontSize(), sut.FontSize);
        }
        public IDefaultsFactory GetDefaultsFactory()
        {
            return defaultsFactory;
        }
        public SettingsFactory GetSettingsFactory()
        {
            return settingsFactory;
        }

    }
}
