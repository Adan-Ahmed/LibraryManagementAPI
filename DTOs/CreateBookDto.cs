
using System.ComponentModel.DataAnnotations;

public class CreateBookDto
{

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [StringLength(60)]
    public string Author { get; set; }

}
