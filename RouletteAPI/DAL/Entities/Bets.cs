namespace DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bets.Bets")]
    public partial class Bets
    {
        [Key]
        public int Bet_ID { get; set; }

        public int Roulette_ID { get; set; }

        public Guid User_ID { get; set; }

        public int? Number { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Money { get; set; }

        public bool State { get; set; }

        public DateTime Creation_Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Creation_User { get; set; }

        public virtual Roulettes Roulettes { get; set; }

        public virtual Users Users { get; set; }
    }
}
