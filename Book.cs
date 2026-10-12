
using System.ComponentModel.DataAnnotations;

public class Book
{
    public int Id { get; set; }

    [Required]
    [StringLength (100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength (60)]
    public string Author { get; set; } = string.Empty;

}
