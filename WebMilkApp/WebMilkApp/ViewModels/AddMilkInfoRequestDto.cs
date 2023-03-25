using System.ComponentModel.DataAnnotations;

namespace WebMilkApp.ViewModels
{
    public class AddMilkInfoRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Storage { get; set; }
    }
}
