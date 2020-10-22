using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDDD.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool ativo { get; set; }

        //Cliente tem uma coleccção de Produtos
        public virtual IEnumerable<Produto> Produtos { get; set; }

        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.ativo && DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
        }

    }
}
