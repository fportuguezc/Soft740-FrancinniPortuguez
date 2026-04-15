using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ProyectoFinal.Pages
{
	public class ShoppingCartPage
	{
		private readonly IWebDriver _driver;

		public ShoppingCartPage(IWebDriver driver)
		{
			_driver = driver;
		}

		//Webelements con los que se interactúa 
		private IWebElement AddSauceLabsBackpack_P1 => _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
		private IWebElement CartCount => _driver.FindElement(By.ClassName("shopping_cart_badge"));
		private IWebElement ShoppingCartLink => _driver.FindElement(By.ClassName("shopping_cart_link"));
		private IWebElement RemoveSauceLabsBackpack_P1 => _driver.FindElement(By.Id("remove-sauce-labs-backpack"));
		private IWebElement SortDropdown => _driver.FindElement(By.ClassName("product_sort_container"));
		private IList<IWebElement> Prices => _driver.FindElements(By.ClassName("inventory_item_price"));

		public void SortBy(string optionText)
		{
			SelectElement select = new SelectElement(SortDropdown);
			select.SelectByText(optionText);
		}

		// Método para obtener los precios de los productos en la página y convertirlos a una lista de números decimales
		public List<double> GetPrices()
		{
			var lista = new List<double>();
			foreach (var p in Prices)
			{
				string valor = p.Text.Replace("$", "");
				if (double.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out double precio))
				{
					lista.Add(precio);
				}
			}
			return lista;
		}

		// Método para hacer clic en el botón "Add to Cart" del producto "Sauce Labs Backpack"
		public void Click_SauceLabsBackpack_AddCart()
		{
			AddSauceLabsBackpack_P1.Click();
		}

		// Método para verificar si el producto "Sauce Labs Backpack" ha sido removido del carrito, verificando que no haya elementos con la clase "shopping_cart_badge"
		public bool Show_SauceLabsBackpack_RemovedCart()
		{
			return _driver.FindElements(By.ClassName("shopping_cart_badge")).Count == 0;
		}

		// Método para hacer clic en el enlace del carrito de compras para navegar a la página del carrito
		public void Click_ShoppingCartLink()
		{
			ShoppingCartLink.Click();
		}

		// Método para mostrar la cantidad de productos en el carrito, obteniendo el texto del elemento que muestra la cantidad
		public string Show_CartCount()
		{
			return CartCount.Text;
		}

		// Método para hacer clic en el botón "Remove" del producto "Sauce Labs Backpack" para eliminarlo del carrito
		public void Click_SauceLabsBackpack_RemoveCart()
		{
			RemoveSauceLabsBackpack_P1.Click();
		}

	}
}