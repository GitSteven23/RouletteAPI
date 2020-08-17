using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RouletteAPI.Models.Roulette
{
    public class CreateRouletteModel
    {
        public int Roulette_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}