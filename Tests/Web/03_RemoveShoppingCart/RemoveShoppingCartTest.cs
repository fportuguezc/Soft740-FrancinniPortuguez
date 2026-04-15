using ProyectoFinal.Pages;
using ProyectoFinal.Utils;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ProyectoFinal.Tests._03_RemoveShoppingCart
{
	public class RemoveShoppingCartTest : TestBase
	{

		[Test]
		public void Caso3_RemoveShoppingCartTest()
		{
			var loginPage = new LoginPage(Driver);

			//Se hace clic en el enlace "Signup / Login" para acceder a la página de registro
			loginPage.Fill_LoginForm("standard_user","secret_sauce");
			loginPage.Click_LoginButton();

			var addShoppingCartPage = new ShoppingCartPage(Driver);
			addShoppingCartPage.Click_SauceLabsBackpack_AddCart();

			var removeShoppingCartPage = new ShoppingCartPage(Driver);
			removeShoppingCartPage.Click_SauceLabsBackpack_RemoveCart();

			//Se valida que no se muestre el producto "Sauce Labs Backpack" en el carrito de compras
			ScreenshotHelper.TakeScreenshot(Driver, "ProductRemovedCartEmpty");
			Assert.That(removeShoppingCartPage.Show_SauceLabsBackpack_RemovedCart , "El carrito no debería mostrar 1 producto");
		
		}
	}

}