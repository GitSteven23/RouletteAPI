﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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