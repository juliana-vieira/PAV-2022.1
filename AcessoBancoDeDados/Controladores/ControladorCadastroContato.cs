using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AcessoBancoDados.Dados;

namespace AcessoBancoDados.Controladores
{
    public class ControladorCadastroContato : ControladorCadastro
    {
        override protected string criarComandoInclusao()
        {
            return "INSERT INTO CONTATO VALUES(ID_CONTATO, NOME, EMAIL, TELEFONE)";
        }

        override protected string criarComandoAtualizacao()
        {
            return " UPDATE CONTATO " +
                   " SET NOME = :NOME " +
                   "     EMAIL = :EMAIL " +
                   "     TELEFONE = :TELEFONE" +
                   " WHERE ID_CONTATO = :ID_CONTATO";
        }

        override protected string criarComandoExclusao()
        {
            return "DELETE FROM CONTATO WHERE ID_CONTATO = :ID_CONTATO";
        }
    }

}
