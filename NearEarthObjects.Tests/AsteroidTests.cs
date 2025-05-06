using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace NearEarthObjects.Tests
{
    public class AsteroidTests : AppiumTestBase
    {
        [Test]
        public void VerifyAsteroidListPageLoads()
        {
            // Wait for the main page to load
            var asteroidNameElement = Driver.FindElement(By.Id("AsteroidName"));
            Assert.That(asteroidNameElement, Is.Not.Null, "Asteroid list page did not load correctly.");
        }

        [Test]
        public void VerifyNavigationToAsteroidDetailsPage()
        {
            // Tap on the first asteroid in the list
            var asteroidNameElement = Driver.FindElement(By.Id("AsteroidName"));
            asteroidNameElement.Click();

            // Verify navigation to the details page
            var detailsPageElement = Driver.FindElement(By.Id("AsteroidDetailsPage"));
            Assert.That(detailsPageElement, Is.Not.Null, "Failed to navigate to the asteroid details page.");
        }
    }
}