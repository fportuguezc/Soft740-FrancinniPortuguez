namespace ProyectoFinal.Test.API.Dtos;

internal sealed class PostResponse
{
	public string Title { get; set; } = string.Empty; 
	public string Body { get; set; } = string.Empty;
	public int UserId { get; set; }
}
