using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ProyectoFinal.Pages
{
	public class CheckoutPage
	{
		private readonly IWebDriver _driver;

		public CheckoutPage(IWebDriver driver)
		{
			_driver = driver;
		}

        //Webelements con los que se interactúa 
        private IWebElement ShoppingCartLink => _driver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement CheckoutButton => _driver.FindElement(By.Id("checkout"));
        private IWebElement FirstNameField => _driver.FindElement(By.Id("first-name"));
        private IWebElement LastNameField => _driver.FindElement(By.Id("last-name"));
        private IWebElement ZipPostalCode => _driver.FindElement(By.Id("postal-code"));
        private IWebElement ContinueButton => _driver.FindElement(By.Id("continue"));
        private IWebElement FinishButton => _driver.FindElement(By.Id("finish"));

		// Método para ir al carrito
		public void Click_ShoppingCartLink()
		{
			ShoppingCartLink.Click();
		}

		//Retorna el nombre del producto agregado 
		public String Check_ProductAddedToCart()
		{
			var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
			var ProductAddedToCart = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-test='inventory-item-name']")));

			return ProductAddedToCart.Text;
		}

		//Método para presionar el botón checkout
		public void Click_CheckoutButton()
		{
			CheckoutButton.Click();
		}

		//Método para presionar el botón continue
		public void Click_ContinueButton()
		{
			ContinueButton.Click();
		}

		//Método para presionar el botón finalizar
		public void Click_FinishButton()
		{
			FinishButton.Click();
		}

		//Se completa el formulario de checkout
		public void Fill_CheckoutForm(String firstNameField, String lastNameField, String zipPostalCode)
		{
			FirstNameField.SendKeys(firstNameField);
			LastNameField.SendKeys(lastNameField);
			ZipPostalCode.SendKeys(zipPostalCode);
		}

		//Se retorna el texto de mensaje exitoso
		public string CheckoutSuccessMessage()
		{
			var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
			var SuccessMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("complete-header")));
			return SuccessMessage.Text;
		}

		//Se retorna el texto del mensaje de error
		public string Check_ErrorMessage()
		{
			var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
			var ErrorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h3[data-test='error']")));
			return ErrorMessage.Text;
		}
		
	}
}