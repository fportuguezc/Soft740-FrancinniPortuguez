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


		//Métodos necesarios para interactuar con los elementos de la página
		public void Click_SauceLabsBackpack_AddCart()
		{
			AddSauceLabsBackpack_P1.Click();
		}

		public bool Show_SauceLabsBackpack_RemovedCart()
		{
			return _driver.FindElements(By.ClassName("shopping_cart_badge")).Count == 0;
		}

		public void Click_ShoppingCartLink()
		{
			ShoppingCartLink.Click();
		}

		public string Show_CartCount()
		{
			return CartCount.Text;
		}

		public void Click_SauceLabsBackpack_RemoveCart()
		{
			RemoveSauceLabsBackpack_P1.Click();
		}

	}
}