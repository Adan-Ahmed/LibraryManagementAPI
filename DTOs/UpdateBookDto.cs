using System.ComponentModel.DataAnnotations;
public class UpdateBookDto 
{

	[Required]
	[StringLength(100)]
	public string Title { get; set; } = string.Empty;

	[Required]
	[StringLength(60)]
	public string Author { get; set; } = string.Empty;
}