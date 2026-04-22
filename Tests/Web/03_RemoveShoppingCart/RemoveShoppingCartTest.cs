using ProyectoFinal.Pages;
using ProyectoFinal.Reporting;
using ProyectoFinal.Utils;

namespace ProyectoFinal.Tests._03_RemoveShoppingCart
{
	public class RemoveShoppingCartTest : ReportedTestBase
	{

		[Test]
		public void Caso3_RemoveShoppingCartTest()
		{
			var loginPage = new LoginPage(Driver);

			//Se hace Login" 
			loginPage.Fill_LoginForm("standard_user","secret_sauce");
			loginPage.Click_LoginButton();

			//Se agrega el producto "Sauce Labs Backpack" al carrito de compras
			var removeShoppingCartPage = new ShoppingCartPage(Driver);
			removeShoppingCartPage.Click_SauceLabsBackpack_AddCart();

			//Se remueve el producto "Sauce Labs Backpack" del carrito de compras
			removeShoppingCartPage.Click_SauceLabsBackpack_RemoveCart();

			//Se valida que no se muestre el producto "Sauce Labs Backpack" en el carrito de compras
			ScreenshotHelper.TakeScreenshot(Driver, "ProductRemovedCartEmpty");
			Assert.That(removeShoppingCartPage.Show_SauceLabsBackpack_RemovedCart , "El carrito no debería mostrar 1 producto");
		
		}
	}

}