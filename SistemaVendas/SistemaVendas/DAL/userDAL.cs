using SistemaVendas.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVendas.DAL
{
    class userDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region selecionar dados do banco de dados
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                String sql = "Select * from tbl_usuarios";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //ABRIR BD, METODO
                conn.Open();
                //FILL, TRAZ OS DADOS NO DT
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //FECHANDO A CONEXÃO
                conn.Close();
            }
            //FECHAR O RETURN DO DATA TABLE
            return dt;
        }

        #endregion
        #region Inserindo dados no banco de dados
        public bool Insert(userBLL u)
        {
            bool isSucesso = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String incluisql = "INSERT INTO tbl_usuarios(nome,s_nome,email,usuario,senha,contato,endereco,sexo,usuario_tipo,add_data,add_por) VALUES (@nome,@s_nome,@email,@usuario,@senha,@contato,@endereco,@sexo,@usuario_tipo,@add_data,@add_por)";
               //PASSAR A STRING DE DADOS E A CONEXÃO
                SqlCommand cmd = new SqlCommand(incluisql, conn);

                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@s_nome", u.s_nome);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@usuario", u.usuario);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@contato", u.contato);
                cmd.Parameters.AddWithValue("@endereco", u.endereco);
                cmd.Parameters.AddWithValue("@sexo", u.sexo);
                cmd.Parameters.AddWithValue("@usuario_tipo", u.usuario_tipo);
                cmd.Parameters.AddWithValue("@add_data", u.add_data);
                cmd.Parameters.AddWithValue("@add_por", u.add_por);
                //ABRI A CONEXÃO
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //VERIFICAÇÃO DA CONSULTA(QUERY)
                if (rows > 0)
                {
                    isSucesso = true;
                }
                else
                {
                    isSucesso = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //FECHA CONEXÃO
                conn.Close();
            }
            //RETORNAR
            return isSucesso;

        }
        #endregion
        #region Atualizar dados do banco de dados
        public bool Update(userBLL u)
        {
            bool isSucesso = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "UPDATE tbl_usuarios SET nome=@nome,s_nome=@s_nome,email=@email,usuario=@usuario,senha=@senha,contato=@contato,endereco,sexo=@sexo,usuario_tipo=@usuario_tipo,add_data=@add_data,add_por=@add_por WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@s_nome", u.s_nome);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@usuario", u.usuario);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@contato", u.contato);
                cmd.Parameters.AddWithValue("@endereco", u.endereco);
                cmd.Parameters.AddWithValue("@sexo", u.sexo);
                cmd.Parameters.AddWithValue("@usuario_tipo", u.usuario_tipo);
                cmd.Parameters.AddWithValue("@add_data", u.add_data);
                cmd.Parameters.AddWithValue("@add_por", u.add_por);
                cmd.Parameters.AddWithValue("@id", u.id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucesso = true;
                }
                else
                {
                    isSucesso = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSucesso;

        }
        #endregion
        #region Deletar dados do banco de dados
        public bool Delete(userBLL u)
        {
            bool isSucesso = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String excluisql = "DELETE FROM tbl_usuarios  WHERE id=@id";
                SqlCommand cmd = new SqlCommand(excluisql, conn);

                cmd.Parameters.AddWithValue("@id", u.id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucesso = true;
                }
                else
                {
                    isSucesso = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSucesso;

        }
        #endregion
    }
}
