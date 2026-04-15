using ProyectoFinal.Pages;
using ProyectoFinal.Tests.Web.Checkout.Asserts;
using ProyectoFinal.Tests.Web.Login.Asserts;
using ProyectoFinal.Utils;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ProyectoFinal.Tests._04_CheckoutShoppingCart
{
	public class CheckoutShoppingCartTest : TestBase
	{


		[Test, TestCaseSource(typeof(CheckoutDataSource), nameof(CheckoutDataSource.CheckoutValid))]
		public void Caso4_CheckoutShoppingCartTest(string firstName, string lastName,string zipCode, bool isValid)
		{
			var loginPage = new LoginPage(Driver);

			//Se hace clic en el enlace "Signup / Login" para acceder a la página de registro
			loginPage.Fill_LoginForm("standard_user","secret_sauce");
			loginPage.Click_LoginButton();

			var addShoppingCartPage = new ShoppingCartPage(Driver);
			addShoppingCartPage.Click_SauceLabsBackpack_AddCart();

			var checkoutShoppingCart = new CheckoutPage(Driver);
			checkoutShoppingCart.Click_ShoppingCartLink();
			ScreenshotHelper.TakeScreenshot(Driver, "ProductAdded");
			checkoutShoppingCart.Click_CheckoutButton();
			checkoutShoppingCart.Fill_CheckoutForm(firstName, lastName, zipCode);
			ScreenshotHelper.TakeScreenshot(Driver, "CheckoutFormFilled");
			checkoutShoppingCart.Click_ContinueButton();

			//Se valida si el dato es valido o no para ver que elemento debe ser validado en cada caso
			if (isValid)
			{

				checkoutShoppingCart.Click_FinishButton();
				//Se valida que se muestra el nombre del usuario después de iniciar sesión
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