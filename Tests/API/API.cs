using ProyectoFinal.Test.API.Dtos;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace ProyectoFinal.Tests.API
{
	public class API
	{
		private const string BaseUrl = "https://jsonplaceholder.typicode.com/";

		private static RestClient CreateClient() => new(BaseUrl);

		private static RestRequest CreateRequest(string resource, Method method)
		{
			var request = new RestRequest(resource, method);
			request.AddHeader("Content-type", "application/json; charset=UTF-8");
			return request;
		}

		//Get
		[Test]
		public async Task GetAlbums_ShouldReturnResults()
		{
			var client = CreateClient();
			var request = CreateRequest("/users/1/albums", Method.Get);

			var response = await client.ExecuteAsync(request);

			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), response.Content);
			var payload = JsonSerializer.Deserialize<List<AlbumDto>>(
				response.Content!,
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			Assert.That(payload, Is.Not.Null);
			Assert.That(payload!.Count, Is.EqualTo(10));
			Assert.That(payload, Is.Not.Null);
			Assert.That(payload.Count, Is.GreaterThan(0));
			Assert.That(payload[0].Title, Does.Contain("quidem molestiae enim"));
		}

		//Post
		[Test]
		public async Task Register_ShouldReturnData()
		{
			var client = CreateClient();
			var request = CreateRequest("/posts", Method.Post);
			request.AddJsonBody(new { title = "title1", body = "my title", userId = 1 });

			var response = await client.ExecuteAsync(request);

			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), response.Content);

			var payload = JsonSerializer.Deserialize<PostResponse>(
				response.Content!,
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			Assert.That(payload, Is.Not.Null);
			Assert.That(payload!.UserId, Is.GreaterThan(0));
			Assert.That(payload.Title, Is.Not.Null.And.Not.Empty);
			Assert.That(payload.Body, Is.Not.Null.And.Not.Empty);
		}

		//Update
		[Test]
		public async Task UpdateUser_ShouldReturnUpdatedAt()
		{
			var client = CreateClient();
			var request = CreateRequest("/posts/1", Method.Put);
			request.AddJsonBody(new { title = "title2", body = "my title updated", userId = 1 });

			var response = await client.ExecuteAsync(request);

			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), response.Content);

			var payload = JsonSerializer.Deserialize<PostResponse>(
				response.Content!,
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			Assert.That(payload, Is.Not.Null);
			Assert.That(payload!.UserId, Is.GreaterThan(0));
			Assert.That(payload.Title, Is.Not.Null.And.Not.Empty);
			Assert.That(payload.Body, Is.Not.Null.And.Not.Empty);
		}

		//Delete
		[Test]
		public async Task DeleteUser_ShouldReturnNoContent()
		{
			var client = CreateClient();
			var request = CreateRequest("/posts/1", Method.Delete);

			var response = await client.ExecuteAsync(request);

			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), response.Content);
			Assert.That(string.IsNullOrWhiteSpace(response.Content), Is.False);
		}
	}
}