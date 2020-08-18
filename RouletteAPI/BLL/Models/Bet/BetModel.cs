using System;

namespace BLL.Models.Bet
{
    public class BetModel
    {
        public int Bet_ID { get; set; }
        public int Roulette_ID { get; set; }
        public Guid User_ID { get; set; }
        public int? Number { get; set; }        
        public string Color { get; set; }        
        public decimal Money { get; set; }
        public string State { get; set; }
        public DateTime Creation_Date { get; set; }        
        public string Creation_User { get; set; }
    }
}
