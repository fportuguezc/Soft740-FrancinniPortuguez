using ProyectoFinal.Utils;
using OpenQA.Selenium;
using ProyectoFinal.Pages;
using Reqnroll;
using System;

namespace ProyectoFinal.StepDefinitions._02_ShoppingCart
{
	[Binding]
	public class ShoppingCartStepDefinitions
	{
		private readonly ScenarioContext _scenarioContext;
		private readonly IWebDriver _driver;
		private readonly ShoppingCartPage _shoppingCartPage;
		private readonly CheckoutPage _checkoutShoppingCart;

		public ShoppingCartStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
			_driver = _scenarioContext.Get<IWebDriver>();
			_shoppingCartPage = new ShoppingCartPage(_driver);
			_checkoutShoppingCart = new CheckoutPage(_driver);
		}

		[Given(@"I am on the products list")]
		public void GivenIAmOnTheProductsPage()
		{
			//Dado que estoy en la página de productos
		}

		[When(@"I select a product to add the cart")]
		public void WhenISelectAProduct()
		{
			_shoppingCartPage.Click_SauceLabsBackpack_AddCart();
		}  

		[Then(@"I should see the cart quantity according to the products added")]
		public void ThenIShouldSeeTheQuantity()
		{
			//Se valida que se muestra el nombre del usuario después de iniciar sesión
			Assert.That(_shoppingCartPage.Show_CartCount(), Is.EqualTo("1"), "Elcarrito debería mostrar 1");
		}

		[When(@"I click the cart button")]
		public void WhenIClickTheCartButton()
		{
			_shoppingCartPage.Click_ShoppingCartLink();
		}

		[Then(@"I should see the products added to the cart")]
		public void ThenIShouldSeeTheProductsAddedToTheCart()
		{
			Assert.That(_checkoutShoppingCart.Check_ProductAddedToCart(), Is.EqualTo("Sauce Labs Backpack"), "El producto debería mostrarse");
		}

		[When(@"I click the checkout button")]
		public void WhenIClickTheCheckoutButton()
		{
			_checkoutShoppingCart.Click_CheckoutButton();
		}

		[When(@"I fill the checkout form with firstname ""(.*)"" lastname ""(.*)"" and zipcode ""(.*)""")]
		public void WhenIFillCheckoutForm( string firtstName, string lastName, string zipCode)
		{
			_checkoutShoppingCart.Fill_CheckoutForm(firtstName, lastName, zipCode);
			ScreenshotHelper.TakeScreenshot(_driver, "BDD_CheckoutForm");
		}

		[When(@"I click the continue button")]
			public void WhenIClickTheContinueButton()
			{
			_checkoutShoppingCart.Click_ContinueButton();
		}

		[When(@"I click the finish button")]
		public void WhenIClickTheFinishButton()
		{			
			_checkoutShoppingCart.Click_FinishButton();
		}

		[Then(@"I should see the checkout success message")]
		public void ThenIShouldSeeTheCheckoutMessage()
		{
			//Se valida que se muestra el nombre del usuario después de iniciar sesión
			ScreenshotHelper.TakeScreenshot(_driver, "BDD_SuccessCheckout");
			Assert.That(_checkoutShoppingCart.CheckoutSuccessMessage(), Is.EqualTo("Thank you for your order!"), "El mensaje de éxito debería mostrarse");
		}

		[Then(@"I should see the checkout error message")]
		public void ThenIShouldSeeTheCheckoutErrorMessage()
		{
			//Se valida que se muestra el mensaje de error cuando se ingresa con datos incorrectos
			ScreenshotHelper.TakeScreenshot(_driver, "BDD_ErrorMessageAfterCheckout");
			Assert.That(_checkoutShoppingCart.Check_ErrorMessage(), Is.EqualTo("Error: Postal Code is required"), "El mensaje de error debería mostrarse");
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