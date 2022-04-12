using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace AcessoBancoDados.Persistencia
{
    public abstract class Entidade
    {
        public abstract void transferirDados(MySqlCommand comandosql);

        public abstract void transferirDadosIdentificador(MySqlCommand comandosql);

        public abstract void lerDados(MySqlDataReader leitorDados);

    }
}
