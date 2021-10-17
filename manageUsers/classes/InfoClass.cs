using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manageUsers.classes
{
    class InfoClass
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }

        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Table_1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool Insert(InfoClass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
         
            try
            {
                String sql = "INSERT INTO Table_1 (Nom , Prenom ) VALUES (@Nom , @Prenom )";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nom", Nom);
                cmd.Parameters.AddWithValue("@Prenom", Prenom);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool Update(InfoClass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "Update Table_1 SET Prenom = @Prenom WHERE Nom = @Nom  ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nom", Nom);
                cmd.Parameters.AddWithValue("@Prenom", Prenom);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool Delete(InfoClass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                String sql = "DELETE FROM Table_1 WHERE Nom = @Nom  ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nom", Nom);
              

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
