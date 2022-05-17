using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa.Entity
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int PessoaId { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome  { get; set; }

        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        [Display(Name = "Idade")]
        [Column("Idade")]
        public int Idade { get; set; }
    }
}
