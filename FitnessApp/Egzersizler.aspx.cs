using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessApp;
using Newtonsoft.Json;

namespace FitnessApp
{
    public partial class Egzersizler : System.Web.UI.Page
    {
        protected List<Exercise> ExercisesList {  get; set; }    // egzersiz listesini tutacak
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ExerciseApiHelper apiHelper = new ExerciseApiHelper(); // API yardımıcı sınıfını oluştur

                try
                {
                    // İlgili egzersizleri al
                    List<Exercise> bicepsExercises = apiHelper.GetExercises("biceps");
                    List<Exercise> chestExercises = apiHelper.GetExercises("chest");

                    ExercisesList = new List<Exercise>();
                    ExercisesList.AddRange(bicepsExercises);
                    ExercisesList.AddRange(chestExercises);

                    // Egzersiz listesi dolu mu kontrol edin
                    if (ExercisesList == null || ExercisesList.Count == 0)
                    {
                        throw new Exception("Egzersiz listesi boş.");
                    }

                    // Egzersiz listesini session'a kaydetme
                    Session["ExercisesList"] = ExercisesList;

                    // Repeater kontrolüne bağlama
                    ExercisesRepeater.DataSource = ExercisesList;
                    ExercisesRepeater.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Hata: " + ex.Message + "');</script>");
                }
            }
            else {
                ExercisesList = Session["ExercisesList"] as List<Exercise>;
            }
        }

        protected void AddToFavorites(object sender, CommandEventArgs e)
        {
            // Kullanıcının seçtiği egzersizin adını al
            string exerciseName = e.CommandArgument.ToString();

            // Egzersiz listesini Session'dan alın
            if (ExercisesList == null)
            {
                ExercisesList = Session["ExercisesList"] as List<Exercise>;
                if (ExercisesList == null)
                {
                    Response.Write("<script>alert('Egzersiz listesi boş. Lütfen sayfayı yenileyin.');</script>");
                    return;
                }
            }

            // Egzersiz listesinden seçilen egzersizi bulun
            var exercise = ExercisesList.FirstOrDefault(x => x.Name == exerciseName);

            if (exercise == null)
            {
                Response.Write("<script>alert('Egzersiz bulunamadı.');</script>");
                return;
            }

            // Kullanıcı oturumu alın
            string userMail = Session["Kullanici"]?.ToString();
            if (string.IsNullOrEmpty(userMail))
            {
                Response.Redirect("Login.aspx"); // Giriş yapılmamışsa login sayfasına yönlendir
                return;
            }

            // Favorilere ekleme işlemi
            string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query1 = @"
            IF NOT EXISTS (SELECT 1 FROM Favoriler WHERE Mail = @Mail AND ExerciseName = @ExerciseName)
            BEGIN
                INSERT INTO Favoriler (Mail, ExerciseName, Type, Muscle, Equipment, Difficulty)
                VALUES (@Mail, @ExerciseName, @Type, @Muscle, @Equipment, @Difficulty)
            END";
                string query = @"INSERT INTO Favoriler (Mail, ExerciseName, Type, Muscle, Equipment, Difficulty)
                             VALUES (@Mail, @ExerciseName, @Type, @Muscle, @Equipment, @Difficulty)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Mail", userMail);
                command.Parameters.AddWithValue("@ExerciseName", exercise.Name);
                command.Parameters.AddWithValue("@Type", exercise.Type ?? "Unknown");
                command.Parameters.AddWithValue("@Muscle", exercise.Muscle ?? "Unknown");
                command.Parameters.AddWithValue("@Equipment", exercise.Equipment ?? "Unknown");
                command.Parameters.AddWithValue("@Difficulty", exercise.Difficulty ?? "Unknown");

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            Response.Write("<script>alert('Egzersiz favorilere eklendi.');</script>");
        }
    }

    // Yardımcı Sınıf ile apiler alınır
    public class ExerciseApiHelper
    {
        private const string ApiBaseUrl = "https://api.api-ninjas.com/v1/exercises?muscle=";
        private const string ApiKey = "";   // Güvenlik amacıyla SİLİNMİŞTİR.
        public List<Exercise> GetExercises(string muscleGroup)    // apiden json verisini çeker
        {
            string ApiUrl = ApiBaseUrl + muscleGroup; // Dinamik URL
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("X-Api-Key", ApiKey); // Gerekli kimlik doğrulama
                string jsonResponse = client.DownloadString(ApiUrl); // API'den JSON formatında veri çek
                return JsonConvert.DeserializeObject<List<Exercise>>(jsonResponse); // JSON'u listeye çevir
            }
        }
    }

    // Model Sınıf
    public class Exercise
    {
        public string Name { get; set; } // "name" alanı
        public string Type { get; set; } // "type" alanı
        public string Muscle { get; set; } // "muscle" alanı
        public string Equipment { get; set; } // "equipment" alanı
        public string Difficulty { get; set; } // "difficulty" alanı
        public string Instructions { get; set; } // "instructions" alanı
    }
}

