namespace ProyectoFinal.Tests.Web.Checkout.Asserts
{
	public class CheckoutData
	{
		private string firstName;
		private string lastName;
		private string zipCode;
		private bool isValid;

		public CheckoutData(string firstName, string lastName, string zipCode, bool isValid)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.zipCode = zipCode;
			this.isValid = isValid;
		}
		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}
		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}
		public string ZipCode
		{
			get { return zipCode; }
			set { zipCode = value; }
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
		public static List<CheckoutData> LoadList(string nombreArchivo)
		{
			return JsonHelper.LoadListFromJson<CheckoutData>(nombreArchivo);
		}

	}
}