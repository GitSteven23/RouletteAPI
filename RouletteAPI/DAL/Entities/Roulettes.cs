namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Roulettes.Roulettes")]
    public partial class Roulettes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Roulettes()
        {
            Bets = new HashSet<Bets>();
        }

        [Key]
        public int Roulette_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool State { get; set; }

        public DateTime? Opening_Date { get; set; }

        public DateTime? Closing_Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bets> Bets { get; set; }
    }
}
