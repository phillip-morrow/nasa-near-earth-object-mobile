using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;

namespace NearEarthObjects.Tests
{
    public class AppiumTestBase
    {
        protected AppiumDriver Driver;
        private AppiumLocalService _appiumService;

        [SetUp]
        public void Setup()
        {
            // Start Appium service
            var options = new OptionCollector()
                .AddArguments(GeneralOptionList.PreLaunch());
            _appiumService = new AppiumServiceBuilder().WithArguments(options).Build();
            _appiumService.Start();

            // Configure Appium driver
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.PlatformName, "iOS"); // Change to "Android" for Android
            appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.DeviceName, "iPhone Simulator"); // Change to your device/emulator name
            appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.App, "../../NearEarthObjects/bin/Debug/net7.0-ios/iossimulator/NearEarthObjects.app"); // Path to the built .app file

            Driver = new IOSDriver(_appiumService.ServiceUrl, appiumOptions); // Use AndroidDriver for Android
        }

        [TearDown]
        public void TearDown()
        {
            // Quit the driver and stop Appium service
            Driver?.Quit();
            _appiumService?.Dispose();
        }
    }
}