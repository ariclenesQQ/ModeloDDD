using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDDD.MVC.ViewModels
{
    public class ClienteVM
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Email")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)] //Para não exibir/Criar a data de cadastro
        public DateTime DataCadastro { get; set; }
        public bool ativo { get; set; }

        //Cliente tem uma coleccção de Produtos
        public virtual IEnumerable<ProdutoVM> Produtos { get; set; }
    }
}
