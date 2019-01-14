using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AplicacaoTeste.Models
{
    public class PessoaModel : IDisposable
    {
        private SqlConnection connection;

        public PessoaModel()
        {
            string strConn = "Data Source=localhost;Initial Catalog=BDContato;Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void CreateJuridica(PessoaJuridica pessoa)
        {
            int idPessoaJur = 0;
            idPessoaJur= CreatePessoa(pessoa);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO PESSOAJURIDICA(ID_PESSOA,CNPJ,RAZAOSOCIAL,NOMEFANTASIA)"
                             +"VALUES ("+idPessoaJur+",@CNPJ,@RAZAOSOCIAL,@NOMEFANTASIA)";

            cmd.Parameters.AddWithValue("@CNPJ",pessoa.cnpj);
            cmd.Parameters.AddWithValue("@RAZAOSOCIAL", pessoa.razaoSocial);
            cmd.Parameters.AddWithValue("NOMEFANTASIA", pessoa.nomeFantasia);

            cmd.ExecuteNonQuery();
        }

        public void CreateFisica(PessoaFisica pessoa)
        {
            int idPessoaFis = 0;
            idPessoaFis = CreatePessoa(pessoa);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO PESSOAFISICA(ID_PESSOA,CPF,NOME,SOBRENOME,DATA_NASCIMENTO)"
                             + "VALUES (" + idPessoaFis + ",@CPF,@NOME,@SOBRENOME,@DATA_NASCIMENTO)";

            cmd.Parameters.AddWithValue("@CPF", pessoa.cpf);
            cmd.Parameters.AddWithValue("@NOME", pessoa.nome);
            cmd.Parameters.AddWithValue("@SOBRENOME", pessoa.sobrenome);
            cmd.Parameters.AddWithValue("@DATA_NASCIMENTO", pessoa.dataNascimento);

            cmd.ExecuteNonQuery();
        }

        public int CreatePessoa(Pessoa pessoa)
        {
            int idPessoa = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO PESSOA(CEP,LOGRADOURO,NUMERO,COMPLEMENTO,BAIRRO,CIDADE,UF)  OUTPUT Inserted.ID_PESSOA"
                             + " VALUES (@CEP,@LOGRADOURO,@NUMERO,@COMPLEMENTO,@BAIRRO,@CIDADE,@UF);";

            cmd.Parameters.AddWithValue("CEP", pessoa.cep);
            cmd.Parameters.AddWithValue("@LOGRADOURO", pessoa.logradouro);
            cmd.Parameters.AddWithValue("@NUMERO", pessoa.numero);
            cmd.Parameters.AddWithValue("@COMPLEMENTO", pessoa.complemento);
            cmd.Parameters.AddWithValue("@BAIRRO", pessoa.bairro);
            cmd.Parameters.AddWithValue("@CIDADE", pessoa.cidade);
            cmd.Parameters.AddWithValue("@UF", pessoa.uf);           

            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                idPessoa = Convert.ToInt32(dataReader["ID_PESSOA"]);
            }
            
            dataReader.Close();
            return (idPessoa);

        }
    }
}
 
 