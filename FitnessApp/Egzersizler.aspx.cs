using System;
using System.Collections.Generic;
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

                List<Exercise> bicepsExercises = apiHelper.GetExercises("biceps");
                List<Exercise> chestExercises = apiHelper.GetExercises("chest");

                ExercisesList = new List<Exercise>();
                ExercisesList.AddRange(bicepsExercises);
                ExercisesList.AddRange(chestExercises);

                //ExercisesList = apiHelper.GetExercises("biceps"); // Egzersizleri al

                ExercisesRepeater.DataSource = ExercisesList; // Repeater kontrolüne bağla
                ExercisesRepeater.DataBind(); // Veriyi bağla

                //ExercisesList = apiHelper.GetExercises("chest"); // Egzersizleri al

            }
        }
    }

    // Yardımcı Sınıf
    public class ExerciseApiHelper
    {
        private const string ApiBaseUrl = "https://api.api-ninjas.com/v1/exercises?muscle=";
        private const string ApiKey = "dqOSOqDyEDvX/mjtOSnamw==9CWVoGJdRSiPYYDm";
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