using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoTeste.Models
{
    public class PessoaFisica : Pessoa
    {
        public String cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public String nome { get; set; }
        public String sobrenome { get; set; }
    }
}