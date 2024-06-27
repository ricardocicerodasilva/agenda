using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_de_contatos
{
    internal class cl_login
   cl_conexao c = new cl_conexao();
    public bool Logar(string l, string s)
    {
        try
        {
            string sql = "select login,senha from tblogin where login like '" + l + "'and senha like '" + s + "'";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();
            MySqlDataReader objDados = cmd.ExecuteReader();
            //leitura no banco


            if (objDados.HasRows)
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        catch (Exception e)
        {
            throw (e);

        }
        finally
        {
            c.desconectar();
        }


    }
}
}