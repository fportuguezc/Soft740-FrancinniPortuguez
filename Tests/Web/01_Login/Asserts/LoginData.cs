namespace ProyectoFinal.Tests.Web.Login.Asserts
{
	public class LoginData
	{
		private string user;
		private string password;
		private bool isValid;

		public LoginData(string user, string password, bool isValid)
		{
			this.user = user;
			this.password = password;
			this.isValid = isValid;
		}
		public string User
		{
			get { return user; }
			set { user = value; }
		}
		public string Password
		{
			get { return password; }
			set { password = value; }
		}
		public bool IsValid
		{
			get { return isValid; }
			set { isValid = value; }
		}

		/// <summary>
		/// Carga una lista de objetos LoginData desde un archivo JSON usando JsonHelper.
		/// </summary>
		/// <param name="nombreArchivo">Nombre del archivo JSON</param>
		/// <returns>Lista de LoginData</returns>
		public static List<LoginData> LoadList(string nombreArchivo)
		{
			return JsonHelper.LoadListFromJson<LoginData>(nombreArchivo);
		}

	}
}