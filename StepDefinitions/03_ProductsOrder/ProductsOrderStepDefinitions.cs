using ProyectoFinal.Utils;
using OpenQA.Selenium;
using ProyectoFinal.Pages;
using Reqnroll;
using System;

namespace ProyectoFinal.StepDefinitions._05_ProductsOrder
{
	[Binding]
	public class ProductsOrderStepDefinitions
	{
		private readonly ScenarioContext _scenarioContext;
		private readonly IWebDriver _driver;
		private readonly LoginPage _loginPage;
		private readonly ShoppingCartPage _shoppingCartPage;
		private readonly CheckoutPage _checkoutShoppingCart;

		public ProductsOrderStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
			_driver = _scenarioContext.Get<IWebDriver>();
			_loginPage =new LoginPage(_driver);
			_shoppingCartPage = new ShoppingCartPage(_driver);
			_checkoutShoppingCart = new CheckoutPage(_driver);
		}

		[When(@"I select the price low to high order option")]
		public void WhenISelectThePriceLowToHighOrderOption()
		{
			// Ordenar por precio de menor a mayor
			_shoppingCartPage.SortBy("Price (low to high)");			
		}  

		[Then(@"I should see the products ordered by price low to high")]
		public void ThenIShouldSeeTheProductsOrderedByPriceLowToHigh()
		{
			// Obtener lista de precios
			var prices = _shoppingCartPage.GetPrices();
			// Crear lista ordenada
			var sortedPrices = prices.OrderBy(p => p).ToList();
			ScreenshotHelper.TakeScreenshot(_driver, "BDD_SortedByPrice");
			Assert.That(prices, Is.EqualTo(sortedPrices), "Los precios no están ordenados correctamente.");
		}
	}
}