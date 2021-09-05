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
        public int Id { get; set; }

        [Column("nr_cartao")]
        public int Numero { get; set; }

        [Column("ds_cartao")]
        public string Descricao { get; set; }

        [Column("nr_cvv")]
        public int Cvv { get; set; }
        public Cliente Cliente { get; set; }

        [Column("vl_limite")]
        public float Limite { get; set; }

    }
}
