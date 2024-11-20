using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("computers")]
    public class ComputerEntity
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Processor { get; set; }

        [MaxLength(50)]
        [Required]
        public string Memory { get; set; }

        [MaxLength(50)]
        [Required]
        public string GraphicsCard { get; set; }

        [MaxLength(50)]
        [Required]
        public string Manufacturer { get; set; }

        [Required]
        [Column("production_date")]
        public DateTime ProductionDate { get; set; }
    }
}