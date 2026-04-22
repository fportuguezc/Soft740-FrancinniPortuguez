using ProyectoFinal.Pages;
using ProyectoFinal.Reporting;
using ProyectoFinal.Tests.Web.Checkout.Asserts;
using ProyectoFinal.Tests.Web.Login.Asserts;
using ProyectoFinal.Utils;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ProyectoFinal.Tests._04_CheckoutShoppingCart
{
	public class CheckoutShoppingCartTest : ReportedTestBase
	{

		[Test, TestCaseSource(typeof(CheckoutDataSource), nameof(CheckoutDataSource.CheckoutValid))]
		public void Caso4_CheckoutShoppingCartTest(string firstName, string lastName,string zipCode, bool isValid)
		{
			var loginPage = new LoginPage(Driver);

			//Se hace clic Login" 
			loginPage.Fill_LoginForm("standard_user","secret_sauce");
			loginPage.Click_LoginButton();

			//Se agrega el producto "Sauce Labs Backpack" al carrito de compras
			var addShoppingCartPage = new ShoppingCartPage(Driver);
			addShoppingCartPage.Click_SauceLabsBackpack_AddCart();

			//Se realiza el checkout
			var checkoutShoppingCart = new CheckoutPage(Driver);
			checkoutShoppingCart.Click_ShoppingCartLink();
			ScreenshotHelper.TakeScreenshot(Driver, "ProductAddedToCart");
			checkoutShoppingCart.Click_CheckoutButton();
			checkoutShoppingCart.Fill_CheckoutForm(firstName, lastName, zipCode);
			ScreenshotHelper.TakeScreenshot(Driver, "CheckoutFormFilled");
			checkoutShoppingCart.Click_ContinueButton();

			//Se valida si el dato es valido o no para ver que flujo seguir
			if (isValid)
			{
				checkoutShoppingCart.Click_FinishButton();
				//Se valida que se muestra el mensaje de éxito cuando se ingresa con datos correctos
				ScreenshotHelper.TakeScreenshot(Driver, "SuccessCheckout");
				Assert.That(checkoutShoppingCart.CheckoutSuccessMessage, Is.EqualTo("Thank you for your order!"), "El mensaje de éxito debería mostrarse");
			}
			else
			{
				//Se valida que se muestra el mensaje de error cuando se ingresa con datos incorrectos
				ScreenshotHelper.TakeScreenshot(Driver, "ErrorMessageAfterCheckout");
				Assert.That(checkoutShoppingCart.Check_ErrorMessage, Is.EqualTo("Error: Postal Code is required"), "El mensaje de error debería mostrarse");
			}
		}
	}

}