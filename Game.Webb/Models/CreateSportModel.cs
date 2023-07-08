using System.ComponentModel.DataAnnotations;

namespace Game.Webb.Models
{
    public class CreateSportModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "Name must be longer than two letters.", MinimumLength = 2)]
        public string? Name { get; set; }
    }
}
