using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AcessoBancoDados.Dados;
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
            comandosql.Attributes.SetAttribute(ATRIBUTO_ID_CONTATO, idContato);
            comandosql.Attributes.SetAttribute(ATRIBUTO_NOME, nome);
            comandosql.Attributes.SetAttribute(ATRIBUTO_EMAIL, email);
            comandosql.Attributes.SetAttribute(ATRIBUTO_TELEFONE, telefone);
        }

        public override void lerDados(MySqlCommand comandosql)
        {
            idContato = int.Parse(comandosql.Attributes[0].Value.ToString());
            nome = comandosql.Attributes[1].Value.ToString();
            email = comandosql.Attributes[2].Value.ToString();
            telefone = comandosql.Attributes[3].Value.ToString();
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
