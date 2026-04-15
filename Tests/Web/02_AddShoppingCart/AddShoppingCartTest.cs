using ProyectoFinal.Pages;
using ProyectoFinal.Utils;

namespace ProyectoFinal.Tests._02_AddShoppingCart
{
	public class AddShoppingCartTest : TestBase
	{

		[Test]
		public void Caso2_AddShoppingCartTest()
		{
			var loginPage = new LoginPage(Driver);

			//Se hace login
			loginPage.Fill_LoginForm("standard_user","secret_sauce");
			loginPage.Click_LoginButton();
			
			var shoppingCartPage = new ShoppingCartPage(Driver);

			//Se agrega el producto "Sauce Labs Backpack" 
			shoppingCartPage.Click_SauceLabsBackpack_AddCart();
			
			//Se valida que se agregue la cantidad de 1 al carrito
			ScreenshotHelper.TakeScreenshot(Driver, "ProductAddedCartHas1");
			Assert.That(shoppingCartPage.Show_CartCount, Is.EqualTo("1"), "Elcarrito debería mostrar 1");
		
		}
	}

}