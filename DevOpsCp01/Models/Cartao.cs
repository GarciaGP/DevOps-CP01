using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevOpsCp01.Models
{
    [Table("TAB_CARTAO")]
    public class Cartao
    {
        [Column("id_cartao")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("nr_cartao")]
        public long Numero { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("ds_cartao")]
        public string Descricao { get; set; }

        [Required]
        [Column("nr_cvv")]
        public int Cvv { get; set; }

        [NotMapped]
        public Cliente Cliente { get; set; }

        [Required]
        [Column("vl_limite")]
        public float Limite { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        [Column("id_cliente")]
        public int IdCliente { get; set; }

    }
}
