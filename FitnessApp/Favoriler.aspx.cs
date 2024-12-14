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
        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userMail = Session["UserMail"]?.ToString();

                if (string.IsNullOrEmpty(userMail))
                {
                    Response.Redirect("Login.aspx"); // Giriş yapmamış kullanıcıyı yönlendirin
                    return;
                }

                

                // Kullanıcının favorilerini getir
                string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ExerciseId FROM Favorites WHERE Mail = @Mail";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Mail", userMail);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> favoriteExercises = new List<string>();

                    while (reader.Read())
                    {
                        favoriteExercises.Add(reader["ExerciseId"].ToString());
                    }

                    connection.Close();

                    // Favori egzersizleri Repeater'a bağlayın
                    FavoritesRepeater.DataSource = favoriteExercises;
                    FavoritesRepeater.DataBind();
                }
            }
        }
        */


        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userMail = Session["Kullanici"]?.ToString();

                if (string.IsNullOrEmpty(userMail))
                {
                    Response.Write("<script>alert('Favorilerinizi görmek için giriş yapmalısınız.');</script>");
                    return;
                }

                LoadFavorites(userMail);
            }
        }

        private void LoadFavorites(string userMail)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ExerciseId FROM Favorites WHERE Mail = @Mail";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Mail", userMail);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Response.Write($"<p>{reader["ExerciseId"]}</p>");
                    }
                }
                else
                {
                    Response.Write("<p>Henüz favorilere eklenmiş bir egzersiz yok.</p>");
                }

                reader.Close();
            }
        }
        */



        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFavorites(); // Favorileri yükle
            }
        }

        private void LoadFavorites()
        {
            string userMail = Session["Kullanici"]?.ToString(); // Kullanıcı oturum bilgisini al

            if (!string.IsNullOrEmpty(userMail))
            {
                string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT e.Name, e.Type, e.Muscle, e.Equipment, e.Difficulty
                        FROM Favorites f
                        INNER JOIN TableUsers u ON f.UserId = u.id
                        INNER JOIN Exercises e ON f.ExerciseId = e.Id
                        WHERE u.Mail = @Mail";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Mail", userMail);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    List<Exercise> favorites = new List<Exercise>();
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

                    FavoritesRepeater.DataSource = favorites; // Favorileri repeater'a bağla
                    FavoritesRepeater.DataBind();
                }
            }
        }

        // Egzersiz modeli
        public class Exercise
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Muscle { get; set; }
            public string Equipment { get; set; }
            public string Difficulty { get; set; }
        }
        */

        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFavorites(); // Favori egzersizleri yükle
            }
        }

        private void LoadFavorites()
        {
            // Kullanıcı oturumundaki mail adresini al
            string userMail = Session["Kullanici"]?.ToString();

            if (string.IsNullOrEmpty(userMail))
            {
                // Eğer kullanıcı oturum açmamışsa, favoriler yüklenmez
                FavoritesRepeater.DataSource = null;
                FavoritesRepeater.DataBind();
                return;
            }

            // Veritabanı bağlantısı için connection string
            string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // Favori egzersizleri çekmek için SQL sorgusu
            string query = @"
                SELECT e.Name, e.Type, e.Muscle, e.Equipment, e.Difficulty
                FROM Favorites f
                INNER JOIN TableUsers u ON f.UserId = u.id
                INNER JOIN Exercises e ON f.ExerciseId = e.Id
                WHERE u.Mail = @Mail";

            List<Exercise> favorites = new List<Exercise>();

            // Veritabanı bağlantısı
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Mail", userMail);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Veritabanından favori egzersizleri oku
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

            // Favorileri Repeater kontrolüne bağla
            FavoritesRepeater.DataSource = favorites;
            FavoritesRepeater.DataBind();
        }

        // Egzersiz modeli
        public class Exercise
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Muscle { get; set; }
            public string Equipment { get; set; }
            public string Difficulty { get; set; }
        }

        */

        /*
        protected List<Exercise> FavoritesList { get; set; } // Kullanıcı favorilerini tutar

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userMail = Session["Kullanici"] as string;
                if (string.IsNullOrEmpty(userMail))
                {
                    Response.Redirect("~/Login.aspx"); // Kullanıcı giriş yapmamışsa login sayfasına yönlendirilir
                    return;
                }

                FavoritesList = new List<Exercise>();

                using (SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    string query = @"SELECT e.Id, e.Name, e.Type, e.Muscle, e.Equipment, e.Difficulty
                                     FROM Favorites f
                                     INNER JOIN Exercises e ON f.ExerciseId = e.Id
                                     WHERE f.Mail = @Mail";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Mail", userMail);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FavoritesList.Add(new Exercise
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

                // Favorileri repeater kontrolüne bağla
                FavoritesRepeater.DataSource = FavoritesList;
                FavoritesRepeater.DataBind();
            }
        }
        */

        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userMail = Session["Kullanici"] as string;
                if (string.IsNullOrEmpty(userMail))
                {
                    Response.Redirect("~/Login.aspx"); // Kullanıcı giriş yapmamışsa login sayfasına yönlendirin
                    return;
                }

                using (SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    connection.Open();
                    string query = @"SELECT ExerciseName, Type, Muscle, Equipment, Difficulty 
                             FROM Favoriler
                             WHERE Mail = @Mail";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Mail", userMail);

                    SqlDataReader reader = command.ExecuteReader();
                    List<Exercise> favoriteExercises = new List<Exercise>();
                    while (reader.Read())
                    {
                        favoriteExercises.Add(new Exercise
                        {
                            Name = reader["ExerciseName"].ToString(),
                            Type = reader["Type"].ToString(),
                            Muscle = reader["Muscle"].ToString(),
                            Equipment = reader["Equipment"].ToString(),
                            Difficulty = reader["Difficulty"].ToString()
                        });
                    }

                    if (!favoriteExercises.Any())
                    {
                        Response.Write("<p>Henüz favorilere eklenmiş bir egzersiz yok.</p>");
                        return;
                    }

                    reader.Close();

                    // Favori egzersizleri Repeater kontrolüne bağla
                    FavoritesRepeater.DataSource = favoriteExercises;
                    FavoritesRepeater.DataBind();
                }
            }
        }*/
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