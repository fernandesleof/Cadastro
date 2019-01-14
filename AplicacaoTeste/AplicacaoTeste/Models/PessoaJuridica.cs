using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoTeste.Models
{
    public class PessoaJuridica : Pessoa
    {
        public String cnpj { get; set; }
        public String razaoSocial { get; set; }
        public String nomeFantasia { get; set; }
    }
}