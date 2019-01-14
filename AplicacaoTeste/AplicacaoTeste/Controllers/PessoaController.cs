using AplicacaoTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacaoTeste.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            if (form["razaosocial"] != "") {
                //Pessoa Juridica
                PessoaJuridica pessoajuridica = new PessoaJuridica();
                pessoajuridica.cnpj = form["cnpj"];
                pessoajuridica.razaoSocial = form["razaosocial"];
                pessoajuridica.nomeFantasia = form["nomefantasia"];

                //Pessoa
                pessoajuridica.cep = form["cep"];
                pessoajuridica.logradouro = form["logradouro"];
                pessoajuridica.numero = Convert.ToInt32(form["numero"]);
                pessoajuridica.complemento = form["complemento"];
                pessoajuridica.bairro = form["bairro"];
                pessoajuridica.cidade = form["cidade"];
                pessoajuridica.uf = form["uf"];


                using (PessoaModel model = new PessoaModel())
                {
                    model.CreateJuridica(pessoajuridica);
                    return RedirectToAction("Sucesso");
                }
            }
            else
            {
                //Pessoa Fisica
                PessoaFisica pessoafisica = new PessoaFisica();
                pessoafisica.cpf = form["cpf"];
                pessoafisica.nome = form["nome"];
                pessoafisica.sobrenome = form["sobrenome"];
                pessoafisica.dataNascimento =Convert.ToDateTime( form["datanascimento"]+"/"+form["anonascimento"] + " 00:00");

                //Pessoa
                pessoafisica.cep = form["cep"];
                pessoafisica.logradouro = form["logradouro"];
                pessoafisica.numero = Convert.ToInt32(form["numero"]);
                pessoafisica.complemento = form["complemento"];
                pessoafisica.bairro = form["bairro"];
                pessoafisica.cidade = form["cidade"];
                pessoafisica.uf = form["uf"];


                using (PessoaModel model = new PessoaModel())
                {
                    model.CreateFisica(pessoafisica);
                    return RedirectToAction("Sucesso");
                }
            }
        }

        public ActionResult Sucesso()
        {
            return View();
        }
    }
}