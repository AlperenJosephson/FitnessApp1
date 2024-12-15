using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace FitnessApp
{
    public partial class Favoriler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userMail = Session["Kullanici"] as string; // Giriş yapan kullanıcının mail adresini al
                if (string.IsNullOrEmpty(userMail))
                {
                    Response.Redirect("~/Login.aspx"); // Kullanıcı giriş yapmadıysa login sayfasına yönlendir
                    return;
                }

                // Favori hareketleri veritabanından çek
                List<Exercise> favoriteExercises = GetFavorites(userMail);
                if (favoriteExercises.Count == 0)
                {
                    // Eğer favorilerde hareket yoksa bir mesaj göster
                    Response.Write("<script>alert('Henüz favorilere eklenmiş bir egzersiz yok.');</script>");
                }

                // Favori hareketleri repeater'a bağla
                FavoritesRepeater.DataSource = favoriteExercises;
                FavoritesRepeater.DataBind();
            }
        }
        private List<Exercise> GetFavorites(string userMail)
        {
            List<Exercise> favorites = new List<Exercise>();

            string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT ExerciseName AS Name, Type, Muscle, Equipment, Difficulty
            FROM Favoriler
            WHERE Mail = @Mail";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Mail", userMail);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    favorites.Add(new Exercise
                    {
                        Name = reader["Name"].ToString(),
                        Type = reader["Type"].ToString(),
                        Muscle = reader["Muscle"].ToString(),
                        Equipment = reader["Equipment"].ToString(),
                        Difficulty = reader["Difficulty"].ToString()
                    });
                }
                reader.Close();
            }

            return favorites;
        }
        public class Exercise
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Muscle { get; set; }
            public string Equipment { get; set; }
            public string Difficulty { get; set; }
        }
    }
}