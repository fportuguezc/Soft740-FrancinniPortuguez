﻿using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProyectoFinal.StepDefinitions.Hooks
{
	[Binding]
	public sealed class WebDriverHooks
	{
		private readonly ScenarioContext _scenarioContext;

		public WebDriverHooks(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			var options = new ChromeOptions();
			options.AddArgument("--start-maximized");
			options.AddArgument("--disable-notifications");
			options.AddArgument("--disable-infobars");
			options.AddArgument("--disable-password-manager");
			options.AddArgument("--disable-save-password-bubble");
			options.AddUserProfilePreference("credentials_enable_service", false);
			options.AddUserProfilePreference("profile.password_manager_enabled", false);
			options.AddArgument("--incognito");
			//options.AddArgument("headless");

			IWebDriver driver = new ChromeDriver(options);
			driver.Navigate().GoToUrl("https://www.saucedemo.com/");
			_scenarioContext.Set<IWebDriver>(driver);

		}

		[AfterScenario]
		public void AfterScenario()
		{
			if (_scenarioContext.TryGetValue<IWebDriver>(out var driver))
			{
				driver.Quit();
				driver.Dispose();
			}
		}
	}
}
