using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace AcessoBancoDados.Persistencia
{
    public abstract class ControladorCadastro
    {
        private MySqlCommand comandoInclusao;
        private MySqlCommand comandoAtualizacao;
        private MySqlCommand comandoExclusao;
        private MySqlCommand comandoSelecao;

        protected abstract string criarComandoInclusao();
        protected abstract string criarComandoAtualizacao();
        protected abstract string criarComandoExclusao();
        protected abstract string criarComandoSelecao();


        protected abstract void criarParametros(MySqlCommand comandosql);

        protected abstract void criarParametrosChavePrimaria(MySqlCommand comandosql);

        protected virtual void criarParametrosInclusao(MySqlCommand comandoInclusao)
        {
            criarParametros(comandoInclusao);
        }

        protected virtual void criarParametrosAtualizacao(MySqlCommand comandoAtualizacao)
        {
            criarParametros(comandoAtualizacao);
        }

        protected virtual void criarParametrosExclusao(MySqlCommand comandoExclusao)
        {
            criarParametrosChavePrimaria(comandoExclusao);
        }

        protected virtual void criarParametrosSelecao(MySqlCommand comandoSelecao)
        {
            criarParametros(comandoSelecao);
        }

        public ControladorCadastro()
        {
            comandoInclusao = new MySqlCommand(criarComandoInclusao(), BancoDados.getInstancia().getConexao());
            comandoAtualizacao = new MySqlCommand(criarComandoAtualizacao(), BancoDados.getInstancia().getConexao());
            comandoExclusao = new MySqlCommand(criarComandoExclusao(), BancoDados.getInstancia().getConexao());
            comandoSelecao = new MySqlCommand(criarComandoSelecao(), BancoDados.getInstancia().getConexao());

            criarParametrosInclusao(comandoInclusao);
            criarParametrosAtualizacao(comandoAtualizacao);
            criarParametrosExclusao(comandoExclusao);
            criarParametrosSelecao(comandoSelecao);
        }

        public void selecionar(Entidade entidade)
        {
            BancoDados.getInstancia().iniciarTransacao();
            try
            {
                entidade.transferirDadosIdentificador(comandoSelecao);
                MySqlDataReader leitorDados = comandoSelecao.ExecuteReader();
                while (leitorDados.Read())
                {
                    entidade.lerDados(leitorDados);
                }
                leitorDados.Close();
                BancoDados.getInstancia().confirmarTransacao();
            } catch (Exception ex)
            {
                BancoDados.getInstancia().cancelarTransacao();
                throw new Exception(ex.Message);
            }
        }

        public void incluir(Entidade entidade)
        {
            BancoDados.getInstancia().iniciarTransacao();
            try
            {
                entidade.transferirDados(comandoInclusao);
                comandoInclusao.ExecuteNonQuery();
                BancoDados.getInstancia().confirmarTransacao();
            } catch (Exception ex)
            {
                BancoDados.getInstancia().cancelarTransacao();
                throw new Exception(ex.Message);
            }
        }

        public void atualizar(Entidade entidade)
        {
            BancoDados.getInstancia().iniciarTransacao();
            try
            {
                entidade.transferirDados(comandoAtualizacao);
                comandoAtualizacao.ExecuteNonQuery();
                BancoDados.getInstancia().confirmarTransacao();
            } catch (Exception ex)
            {
                BancoDados.getInstancia().cancelarTransacao();
                throw new Exception(ex.Message);
            }
        }

        public void excluir(Entidade entidade)
        {
            BancoDados.getInstancia().iniciarTransacao();
            try
            {
                entidade.transferirDadosIdentificador(comandoExclusao);
                comandoExclusao.ExecuteNonQuery();
                BancoDados.getInstancia().confirmarTransacao();
            } catch (Exception ex)
            {
                BancoDados.getInstancia().cancelarTransacao();
                throw new Exception(ex.Message);
            }
        }

    }
}
