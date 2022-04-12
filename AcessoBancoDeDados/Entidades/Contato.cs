using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AcessoBancoDados.Persistencia;
using MySql.Data.MySqlClient;

namespace AcessoBancoDados.Entidades
{
    public class Contato : Entidade
    {
        public const string ATRIBUTO_ID_CONTATO = "ID_CONTATO";
        public const string ATRIBUTO_NOME = "NOME";
        public const string ATRIBUTO_EMAIL = "EMAIL";
        public const string ATRIBUTO_TELEFONE = "TELEFONE";

        private int idContato;
        private string nome;
        private string email;
        private string telefone;

        public override void transferirDados(MySqlCommand comandosql)
        {
            comandosql.Parameters[ATRIBUTO_ID_CONTATO].Value = idContato;
            comandosql.Parameters[ATRIBUTO_NOME].Value = nome;
            comandosql.Parameters[ATRIBUTO_EMAIL].Value = email;
            comandosql.Parameters[ATRIBUTO_TELEFONE].Value = telefone;
        }

        public override void transferirDadosIdentificador(MySqlCommand comandosql)
        {
            comandosql.Parameters[ATRIBUTO_ID_CONTATO].Value = idContato;
        }

        public override void lerDados(MySqlDataReader leitorDados)
        {
            idContato = int.Parse(leitorDados[ATRIBUTO_ID_CONTATO].ToString());
            nome = leitorDados[ATRIBUTO_NOME].ToString();
            email = leitorDados[ATRIBUTO_EMAIL].ToString();
            telefone = leitorDados[ATRIBUTO_TELEFONE].ToString();
        }

        public string getNome()
        {
            return nome;
        }

        public string getEmail()
        {
            return email;
        }

        public int getId()
        {
            return idContato;
        }

        public string getTelefone()
        {
            return telefone;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        } 

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }

        public void setId(int id)
        {
            this.idContato = id;
        }
    }

}
