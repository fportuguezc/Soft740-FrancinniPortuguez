using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace ProyectoFinal.Pages
{
	public class LoginPage(IWebDriver driver)
	{
		private readonly IWebDriver _driver = driver;

		//Webelements con los que se interactúa 
		private IWebElement UsernameField => _driver.FindElement(By.Id("user-name"));
		private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
		private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));
		private IWebElement ShoppingCart => _driver.FindElement(By.ClassName("shopping_cart_link"));
		private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("h3[data-test = 'error']"));

		//Métodos necesarios para interactuar con los elementos de la página

		//Se llena el campo de correo electrónico y contraseña
		public void Fill_LoginForm(String userName, String password)
		{
			UsernameField.SendKeys(userName);
			PasswordField.SendKeys(password);
		}

		//Se hace clic en el botón "Login" para enviar el formulario de inicio de sesión
		public void Click_LoginButton()
		{
			LoginButton.Click();
		}

		// Retorna el estado de visibilidad del ícono del carrito de compras, lo que indica si el inicio de sesión fue exitoso
		public bool Check_ShoppingCartIsPresent()
		{
			if(ShoppingCart.Displayed)
			{
				return true;
			}else
			{
				return false;
			}
		}

		// Retorna el mensaje de error que se muestra después de usar datos incorrectos
		public string Check_ErrorMessage()
		{
			return ErrorMessage.Text;
		}
	}
}
