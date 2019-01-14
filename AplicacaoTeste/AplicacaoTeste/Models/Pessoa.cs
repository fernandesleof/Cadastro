using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoTeste.Models
{
    public abstract class Pessoa
    {        
        public String cep { get; set; }
        public String logradouro { get; set; }
        public int numero { get; set; }
        public String complemento { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String uf { get; set; }
    }
}