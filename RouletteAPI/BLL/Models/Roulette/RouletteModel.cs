using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Roulette
{
    public class RouletteModel
    {
        public int Roulette_ID { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public DateTime? Opening_Date { get; set; }
        public DateTime? Closing_Date { get; set; }
    }
}
