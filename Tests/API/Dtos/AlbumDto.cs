namespace ProyectoFinal.Test.API.Dtos;

internal sealed class AlbumDto
{
	public int UserId { get; set; }
	public int Id { get; set; }

	public string Title { get; set; } = string.Empty;
}