using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Bet
{
    public class CreateBetModel
    {
        public int Roulette_ID { get; set; }
        public Guid User_ID { get; set; }
        [Range(0, 36, ErrorMessage = "Invalid number for bet")]
        public int? Number { get; set; }
        [RegularExpression("Negro|Rojo", ErrorMessage = "The color must be either 'Negro' or 'Rojo' only.")]
        public string Color { get; set; }
        [Range(0, 10000, ErrorMessage = "Invalid amount")]
        public decimal Money { get; set; }
    }
}
