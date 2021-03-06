using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcessoBancoDados.Persistencia
{
    public class BancoDados
    {
        private int porta = 3306;
        private string servidor = "localhost";
        private string nomeBD = "bd_contato";
        private MySqlConnection conexao;
        private MySqlTransaction transacao;
        private static BancoDados instancia = null; // para o singleton


        private string criarConexao(string usuario, string senha)
        {
            return "server = " + servidor +
                ";port = " + porta.ToString() +
                ";user id = " + usuario +
                ";database = " + nomeBD +
                ";password = " + senha;
        }


        public void conectar(string usuario, string senha)
        {
            try
            {
                conexao = new MySqlConnection(criarConexao(usuario, senha));
                conexao.Open();
                MessageBox.Show("Conexão realizada com sucesso!");
          
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: ", ex.Message);
            }
        }
        
        public void conectar()
        {
            conectar("root", "123456");
        }

        public void desconectar()
        {
            if(conexao != null && conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
                conexao.Dispose();
            }
        }

        public MySqlConnection getConexao()
        {
            return conexao;
        }

        public static BancoDados getInstancia()
        {
            if (instancia == null)
            {
                instancia = new BancoDados();
            }

            return instancia;
        }

        public void iniciarTransacao()
        {
            transacao = conexao.BeginTransaction();
        }

        public void confirmarTransacao()
        {
            if (transacao != null)
            {
                transacao.Commit();
                transacao.Dispose();
            }
        }

        public void cancelarTransacao()
        {
            if (transacao != null)
            {
                transacao.Rollback();
                transacao.Dispose();
            }
        }
    }
}


