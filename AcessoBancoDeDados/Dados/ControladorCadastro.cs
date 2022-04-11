using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace AcessoBancoDados.Dados
{
    public abstract class ControladorCadastro
    {
        private MySqlCommand comandoInclusao;
        private MySqlCommand comandoAtualizacao;
        private MySqlCommand comandoExclusao;

        protected abstract string criarComandoInclusao();
        protected abstract string criarComandoAtualizacao();
        protected abstract string criarComandoExclusao();

        public ControladorCadastro()
        {
            comandoInclusao = new MySqlCommand(criarComandoInclusao(), BancoDados.getInstancia().getConexao());
            comandoAtualizacao = new MySqlCommand(criarComandoAtualizacao(), BancoDados.getInstancia().getConexao());
            comandoExclusao = new MySqlCommand(criarComandoExclusao(), BancoDados.getInstancia().getConexao());

        }

    }
}
