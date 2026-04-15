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
		private readonly ShoppingCartPage _shoppingCartPage;

		public RemoveShoppingCartStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
			_driver = _scenarioContext.Get<IWebDriver>();
			_shoppingCartPage = new ShoppingCartPage(_driver);
		}

		[When(@"I select the product to remove from the cart")]
		public void WhenISelectTheProductToRemoveFromTheCart()
		{
			_shoppingCartPage.Click_SauceLabsBackpack_RemoveCart();
		}  

		[Then(@"I should not see the product removed from the cart")]
		public void ThenIShouldNotSeeTheProductRemovedFromTheCart()
		{
			//Se valida que se muestra el nombre del usuario después de iniciar sesión
			ScreenshotHelper.TakeScreenshot(_driver, "BDD_ProductRemovedCartIsEmpty");
			Assert.That(_shoppingCartPage.Show_SauceLabsBackpack_RemovedCart, "El carrito no debería mostrar 1 producto");
		}
	}
}