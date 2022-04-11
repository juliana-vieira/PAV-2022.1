using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace AcessoBancoDados.Dados
{
    public abstract class Entidade
    {
        public abstract void transferirDados(MySqlCommand comandosql);

        public abstract void lerDados(MySqlCommand comandosql);
        
    }
}
