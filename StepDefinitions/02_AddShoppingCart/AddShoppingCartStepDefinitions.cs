using ProyectoFinal.Utils;
using OpenQA.Selenium;
using ProyectoFinal.Pages;
using Reqnroll;
using System;

namespace ProyectoFinal.StepDefinitions._02_AddShoppingCart
{
	[Binding]
	public class AddShoppingCartStepDefinitions
	{
		private readonly ScenarioContext _scenarioContext;
		private readonly IWebDriver _driver;
		private readonly ShoppingCartPage _shoppingCartPage;

		public AddShoppingCartStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
			_driver = _scenarioContext.Get<IWebDriver>();
			_shoppingCartPage = new ShoppingCartPage(_driver);
		}

		[When(@"I select the product to add the cart")]
		public void WhenISelectTheProductToAddTheCart()
		{
			//Se hace clic en el enlace "Signup / Login" para acceder a la página de registro
			_shoppingCartPage.Click_SauceLabsBackpack_AddCart();
		}  

		[Then(@"I should see the product added to the cart")]
		public void ThenIShouldSeeTheProductAddedToTheCart()
		{
			//Se valida que se muestra el nombre del usuario después de iniciar sesión
			ScreenshotHelper.TakeScreenshot(_driver, "BDD_ProductAdded");
		}
	}
}