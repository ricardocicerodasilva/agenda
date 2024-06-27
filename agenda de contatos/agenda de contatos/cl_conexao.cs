using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_de_contatos
{
    internal class cl_conexao
    {
        //  string de conexão
        public MySqlConnection con = new MySqlConnection(@"Server=localhost;port=3306;Database=agenda;User=root;Pwd=''");

        public string conectar()
        {
            try
            {
                con.Open();
                return
                    ("conexão realizada com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }



        public string desconectar()
        {
            try
            {
                con.Close();
                return ("conexão encerrada!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }
    }
}

