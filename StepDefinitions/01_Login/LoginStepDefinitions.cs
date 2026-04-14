using ProyectoFinal.Utils;
using OpenQA.Selenium;
using ProyectoFinal.Pages;
using Reqnroll;
using System;

namespace ProyectoFinal.StepDefinitions._01_Login
{
	[Binding]
	public class LoginStepDefinitions
	{
		private readonly ScenarioContext _scenarioContext;
		private readonly IWebDriver _driver;
		private LoginPage _loginPage; 
		public LoginStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
			_driver = _scenarioContext.Get<IWebDriver>();
			_loginPage = new LoginPage(_driver);
		}

		[Given(@"I am on the login page")]
		public void GivenIAmOnTheStartPage()
		{
			//Se valida que se muestra la página de inicio
		}

		[Given(@"I am logged on SaudeDemo")]
		public void GivenIAmLoggedOnSaudeDemo()
		{
			_loginPage.Fill_LoginForm("standard_user", "secret_sauce");
			_loginPage.Click_LoginButton();
		}

		[When(@"I fill the login form with user ""(.*)"" and password ""(.*)""")]
		public void WhenIFillTheLoginFormWithEmailAndPassword(string email, string password)
		{
			_loginPage.Fill_LoginForm(email, password);
		}

		[When(@"I click the login button")]
		public void WhenIClickTheLoginButton()
		{
			_loginPage.Click_LoginButton();
			ScreenshotHelper.TakeScreenshot(_driver, "BDD_LoginByUserTest_test.png");
		}

		[Then(@"I should see the ""(.*)"" button")]
		public void ThenIShouldSeeTheButton(string textOption)
		{
			Assert.That(_loginPage.Check_ShoppingCartIsPresent, "La opción de carrito debería mostrarse");
			ScreenshotHelper.TakeScreenshot(_driver, "BDD_loggedUser");
		}

		[Then(@"I should see the error message ""(.*)""")]
		public void ThenIShouldSeeTheErrorMessage(string message)
		{
			Assert.That(_loginPage.Check_ErrorMessage, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"), "El mensaje de error debería mostrarse");
			ScreenshotHelper.TakeScreenshot(_driver, "ErrorMessageAfterLogin.png");
		}
	}
}