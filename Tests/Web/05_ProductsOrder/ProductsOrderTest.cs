using ProyectoFinal.Pages;
using ProyectoFinal.Utils;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ProyectoFinal.Tests_05_ProductsOrderTest
{
	public class ProductsOrderTest : TestBase
	{

		[Test]
		public void Caso5_ProductsOrderTest()
		{

			var loginPage = new LoginPage(Driver);

			//Se hace clic en el enlace "Signup / Login" para acceder a la página de registro
			loginPage.Fill_LoginForm("standard_user","secret_sauce");
			loginPage.Click_LoginButton();

			var shoppingCartPage = new ShoppingCartPage(Driver);
			// Ordenar por precio de menor a mayor
			shoppingCartPage.SortBy("Price (low to high)");

			// Obtener lista de precios
			var prices = shoppingCartPage.GetPrices();

			// Crear lista ordenada
			var sortedPrices = prices.OrderBy(p => p).ToList();
			ScreenshotHelper.TakeScreenshot(Driver, "SortedByPrice");
			Assert.That(prices, Is.EqualTo(sortedPrices), "Los precios no están ordenados correctamente.");
		}
	}

}