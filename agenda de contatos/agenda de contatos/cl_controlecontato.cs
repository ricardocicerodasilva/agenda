using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_de_contatos
{
    internal class cl_controlecontato
    {
        cl_conexao c = new cl_conexao();
        public string Cadastrar(cl_contato cont)
        {
            try
            {
                string sql = "INSERT INTO tbcontato(nome,telefone,celular,email)" + "values ('" + cont.Nome + "'," + cont.Telefone + "','" + cont.Celular + "','" + cont.Email + "')";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                // abrindo a conexão com o banco
                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Cadastro reaalizado com sucesso");

            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }


        public string excluir(cl_contato cont)

        {
            try
            {
                string sql = "delete from tbcontato where codcontato=" + cont.Codcontato + ";";
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                // abrindo a conexão
                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("dados excluídos com sucesso!!!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }

        }
        public string alterar(cl_contato cont)

        {
            try
            {
                string sql = "update tbcontato set (nome='" + cont.Nome + "',telefone='" + cont.Telefone + "',celular='" + cont.Celular + "',email='" + cont.Email + ",where codcontato=";
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                // abrindo a conexão
                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("dados atualizados com sucesso!!!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }

        }

        public cl_contato buscar(int codigo)
        {
            cl_contato cont = new cl_contato();

            try
            {
                string sql = "select*from tbcontato where codcontato=" + codigo + ";";
                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                c.conectar();

                MySqlDataReader objDados = cmd.ExecuteReader();
                if (!objDados.HasRows)
                {
                    return null;

                }
                else
                {
                    objDados.Read();
                    cont.Codcontato = Convert.ToInt32(objDados["codcontato"]);
                    cont.Nome = objDados["nome"].ToString();
                    cont.Telefone = objDados["telefone"].ToString();
                    cont.Celular = objDados["celular"].ToString();
                    cont.Email = objDados["email"].ToString();

                    objDados.Close();
                    return cont;
                }

            }
            catch (MySqlException e)
            {
                throw (e);
            }
            finally
            {
                c.desconectar();
            }
        }
        public DataTable pesquisaCodigo(int codigo)
        {
            string sql = "select codcontato as ''Codigo', nomes as Nome,telefone as Telefone," +
                "celulae as Celular email as Email from tbcontato where codcontato=" + codigo + ";";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }
        public DataTable pesquisanome(string nomecontato)
        {
            string sql = "select codcontato as 'Codigo', nome as Nome,telefone as Telefone," +
               "celulae as Celular email as Email from tbcontato where nome like '%" + nomecontato + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }
        public DataTable preencherTodos()
        {
            string sql = "select codcontato as 'Codigo', nome as Nome,telefone as Telefone," +
               "celulae as Celular email as Email from tbcontato";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }

    }

}