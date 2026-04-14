namespace ProyectoFinal.Tests.Web.Checkout.Asserts
{
	public static class CheckoutDataSource
	{
		private const string nameJson = "CheckoutData.json";

		/// <summary>
		/// Metodos que nos permite obtener los usuarios validos y no validos desde el archivo Json y nos permite separar los casos de prueba
		/// Se implementa el patron Yield Return para devolver los casos de prueba uno por uno
		/// ya que NUnit los consume de esa manera y se optimiza el uso de memoria
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<TestCaseData> CheckoutValid()
		{
			var lista = JsonHelper.LoadListFromJson<CheckoutData>(nameJson);

			foreach (var item in lista)
			{
				yield return new TestCaseData(item.FirstName, item.LastName, item.ZipCode, item.IsValid);
			}
		}
	}
}