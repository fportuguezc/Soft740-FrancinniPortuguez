using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProyectoFinal.Utils
{
	// Clase base para tests. No sellada para permitir miembros protegidos.
	public abstract class TestBase
	{
		// Controlador de Selenium accesible en clases derivadas
		protected IWebDriver Driver;

		[SetUp]
		public void Setup()
		{
			// Configuración del driver de Chrome con opciones personalizadas para la automatización de pruebas
			var options = new ChromeOptions();
			options.AddArgument("--start-maximized");
			options.AddArgument("--disable-notifications");
			options.AddArgument("--disable-infobars");
			options.AddArgument("--disable-password-manager");
			options.AddArgument("--disable-save-password-bubble");
			options.AddUserProfilePreference("credentials_enable_service", false);
			options.AddUserProfilePreference("profile.password_manager_enabled", false);
			options.AddArgument("--incognito");


			//options.AddArgument("--headless=new"); //Se usa para ejecutar las pruebas sin levantar la interfaz
			options.AddArgument("--window-size=1920,1080");
			Driver = new ChromeDriver(options);
			Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
		}

		[TearDown]
		public void TearDown()
		{
			if (Driver != null)
			{
				Driver.Quit();
				Driver.Dispose();
			}
		}
	}
}