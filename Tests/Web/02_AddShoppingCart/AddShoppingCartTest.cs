using ProyectoFinal.Pages;
using ProyectoFinal.Utils;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ProyectoFinal.Tests._02_AddShoppingCart
{
	public class AddShoppingCartTest : TestBase
	{

		[Test]
		public void Caso2_AddShoppingCartTest()
		{

			var loginPage = new LoginPage(Driver);

			//Se hace clic en el enlace "Signup / Login" para acceder a la página de registro
			loginPage.Fill_LoginForm("standard_user","secret_sauce");
			loginPage.Click_LoginButton();
			
			var shoppingCartPage = new ShoppingCartPage(Driver);

			//Se hace clic en el enlace "Signup / Login" para acceder a la página de registro
			shoppingCartPage.Click_SauceLabsBackpack_AddCart();
			
			//Se valida que se muestra el nombre del usuario después de iniciar sesión
			ScreenshotHelper.TakeScreenshot(Driver, "ProductAddedCartHas1");
			Assert.That(shoppingCartPage.Show_CartCount, Is.EqualTo("1"), "Elcarrito debería mostrar 1");
		
		}
	}

}