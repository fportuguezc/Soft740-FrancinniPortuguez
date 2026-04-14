using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
        private IWebElement ProductAddedToCart => WaitUntilElementIsVisible(By.CssSelector("div[data-test='inventory-item-name']"));
        private IWebElement CheckoutButton => _driver.FindElement(By.Id("checkout"));
        private IWebElement FirstNameField => _driver.FindElement(By.Id("first-name"));
        private IWebElement LastNameField => _driver.FindElement(By.Id("last-name"));
        private IWebElement ZipPostalCode => _driver.FindElement(By.Id("postal-code"));
        private IWebElement ContinueButton => _driver.FindElement(By.Id("continue"));
        private IWebElement FinishButton => _driver.FindElement(By.Id("finish"));
        private IWebElement SuccessMessage => WaitUntilElementIsVisible(By.ClassName("complete-header"));
        private IWebElement ErrorMessage => WaitUntilElementIsVisible(By.CssSelector("h3[data-test='error']"));

		//Métodos necesarios para interactuar con los elementos de la página
		public void Click_ShoppingCartLink()
		{
			ShoppingCartLink.Click();
		}

		public String Check_ProductAddedToCart()
		{
			Console.WriteLine("Product name: " + ProductAddedToCart.Text);
			return ProductAddedToCart.Text;
		}

		public void Click_CheckoutButton()
		{
			CheckoutButton.Click();
		}

		public void Click_ContinueButton()
		{
			ContinueButton.Click();
		}

		public void Click_FinishButton()
		{
			FinishButton.Click();
		}

		public void Fill_CheckoutForm(String firstNameField, String lastNameField, String zipPostalCode)
		{
			FirstNameField.SendKeys(firstNameField);
			LastNameField.SendKeys(lastNameField);
			ZipPostalCode.SendKeys(zipPostalCode);
		}

		public string CheckoutSuccessMessage()
		{
			return SuccessMessage.Text;
		}

		public string Check_ErrorMessage()
		{
			return ErrorMessage.Text;
		}

        // Helper: espera hasta que el elemento esté presente y visible
        private IWebElement WaitUntilElementIsVisible(By by, int timeoutSeconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(by);
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

	}
}