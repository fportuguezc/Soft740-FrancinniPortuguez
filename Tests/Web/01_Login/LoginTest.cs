using ProyectoFinal.Utils;
using ProyectoFinal.Tests.Web.Login.Asserts;
using ProyectoFinal.Pages;

namespace ProyectoFinal.Tests._01_Login
{
	public class LoginTest : TestBase
	{

		[Test, TestCaseSource(typeof(LoginDataSource), nameof(LoginDataSource.UsersIsValid))]
		public void Caso1_LoginTest(string user, string password, bool isValid)
		{
			var loginPage = new LoginPage(Driver);

			//Se hace clic en el enlace "Signup / Login" para acceder a la página de registro
			loginPage.Fill_LoginForm(user, password);
			loginPage.Click_LoginButton();

			//Se valida si el dato es valido o no para ver que elemento debe ser validado en cada caso
			if (isValid)
			{
				//Se valida que se muestra el nombre del usuario después de iniciar sesión
				ScreenshotHelper.TakeScreenshot(Driver, "loggedUser");
				Assert.That(loginPage.Check_ShoppingCartIsPresent, "La opción de carrito debería mostrarse");
			}
			else 
			{
				//Se valida que se muestra el mensaje de error cuando se ingresa con datos incorrectos
				ScreenshotHelper.TakeScreenshot(Driver, "ErrorMessageAfterLoginIncorrect");
				Assert.That(loginPage.Check_ErrorMessage, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"), "El mensaje de error debería mostrarse");
			}
		}

	}

}