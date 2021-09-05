using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevOpsCp01.Models
{
    [Table("TAB_CLIENTE")]
    public class Cliente
    {
        [Column("id_cliente")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nm_nome")]
        public string Nome { get; set; }

        [Column("nr_cpf")]
        public int Cpf { get; set; }

        [Column("nm_endereco")]
        public string Endereco { get; set; }

        [Column("nm_email")]
        public string Email { get; set; }
    }
}
