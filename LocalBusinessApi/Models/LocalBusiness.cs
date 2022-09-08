using System.ComponentModel.DataAnnotations;

namespace LocalBusinessApi.Models
{
  public class LocalBusiness
  {
    public int LocalBusinessId { get; set; }
    [Required]
    public string  Name { get; set; }
    [Required]
    public string Owner { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    [Range(1,5)]
    public int Rating { get; set; }


  }
}