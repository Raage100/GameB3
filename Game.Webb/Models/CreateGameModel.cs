using System.ComponentModel.DataAnnotations;

namespace Game.Webb.Models
{
    public class CreateGameModel
    {
        [Required]
        public string Name { get; set; }

    }
}
