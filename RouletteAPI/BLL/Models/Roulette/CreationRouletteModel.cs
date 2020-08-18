using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Roulette
{
    public class CreationRouletteModel
    {        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
