using ProyectoFinal.Utils;
using OpenQA.Selenium;
using ProyectoFinal.Pages;
using Reqnroll;
using System;

namespace ProyectoFinal.StepDefinitions._03_RemoveShoppingCart
{
	[Binding]
	public class RemoveShoppingCartStepDefinitions	
	{
		private readonly ScenarioContext _scenarioContext;
		private readonly IWebDriver _driver;
		private readonly LoginPage _loginPage;
		private readonly ShoppingCartPage _shoppingCartPage;
		private readonly CheckoutPage _checkoutShoppingCart;

		public RemoveShoppingCartStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
			_driver = _scenarioContext.Get<IWebDriver>();
			_loginPage =new LoginPage(_driver);
			_shoppingCartPage = new ShoppingCartPage(_driver);
			_checkoutShoppingCart = new CheckoutPage(_driver);
		}

		[When(@"I select the product to remove from the cart")]
		public void WhenISelectTheProductToRemoveFromTheCart()
		{
			//_shoppingCartPage.Click_SauceLabsBackpack_AddCart();
			_shoppingCartPage.Click_SauceLabsBackpack_RemoveCart();
		}  

		[Then(@"I should see the product removed from the cart")]
		public void ThenIShouldSeeTheProductRemovedFromTheCart()
		{
			//Se valida que se muestra el nombre del usuario después de iniciar sesión
			ScreenshotHelper.TakeScreenshot(_driver, "BDD_ProductRemoved");
			Assert.That(_shoppingCartPage.Show_CartCount, Is.EqualTo("0"), "El carrito debería mostrar 0");
		}
	}
}