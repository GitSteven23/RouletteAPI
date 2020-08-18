using System;

namespace BLL.Models.Roulette
{
    public class RouletteModel
    {
        public int Roulette_ID { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime? Opening_Date { get; set; }
        public DateTime? Closing_Date { get; set; }
    }
}
