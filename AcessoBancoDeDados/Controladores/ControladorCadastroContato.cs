using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AcessoBancoDados.Persistencia;
using AcessoBancoDados.Entidades;
using MySql.Data.MySqlClient;

namespace AcessoBancoDados.Controladores
{
    public class ControladorCadastroContato : ControladorCadastro
    {

        override protected string criarComandoSelecao()
        {
            return "SELECT * FROM CONTATO WHERE ID_CONTATO = @ID_CONTATO";
        }

        override protected string criarComandoInclusao()
        {
            return "INSERT INTO CONTATO VALUES(@ID_CONTATO, @NOME, @EMAIL, @TELEFONE)";
        }

        override protected string criarComandoAtualizacao()
        {
            return " UPDATE CONTATO " +
                   " SET NOME = @NOME " +
                   "     EMAIL = @EMAIL " +
                   "     TELEFONE = @TELEFONE" +
                   " WHERE ID_CONTATO = @ID_CONTATO";
        }

        override protected string criarComandoExclusao()
        {
            return "DELETE FROM CONTATO WHERE ID_CONTATO = @ID_CONTATO";
        }

        override protected void criarParametros(MySqlCommand comandosql)
        {
            comandosql.Parameters.Add(Contato.ATRIBUTO_ID_CONTATO, MySqlDbType.Int32);
            comandosql.Parameters.Add(Contato.ATRIBUTO_NOME, MySqlDbType.String);
            comandosql.Parameters.Add(Contato.ATRIBUTO_EMAIL, MySqlDbType.String);
            comandosql.Parameters.Add(Contato.ATRIBUTO_TELEFONE, MySqlDbType.String);

        }

        override protected void criarParametrosChavePrimaria(MySqlCommand comandoExclusao)
        {
            comandoExclusao.Parameters.Add(Contato.ATRIBUTO_ID_CONTATO, MySqlDbType.Int32);
        }
    }

}
