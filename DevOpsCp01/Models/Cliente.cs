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
        [MaxLength(180)]
        [Required]
        public string Nome { get; set; }

        [Required]
        [Column("nr_cpf")]
        public long Cpf { get; set; }

        [Required]
        [MaxLength(300)]
        [Column("nm_endereco")]
        public string Endereco { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        [Column("nm_email")]
        public string Email { get; set; }
    }
}
