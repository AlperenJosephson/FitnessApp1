using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using FitnessApp;


/*namespace FitnessApp.Helpers
{*/
    public class ExerciseApiHelper
    {
        private const string ApiUrl = "https://api.api-ninjas.com/v1/exercises?muscle=biceps";
        private const string ApiKey = "dqOSOqDyEDvX/mjtOSnamw==9CWVoGJdRSiPYYDm";
        public List<Exercise> GetExercises()    // apiden json verisini çeker
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("X-Api-Key", ApiKey); // Gerekli kimlik doğrulama
                string jsonResponse = client.DownloadString(ApiUrl); // API'den JSON formatında veri çek
                return JsonConvert.DeserializeObject<List<Exercise>>(jsonResponse); // JSON'u listeye çevir
            }
        }
    }

    public class Exercise
    {
        public string Name { get; set; } // "name" alanı
        public string Type { get; set; } // "type" alanı
        public string Muscle { get; set; } // "muscle" alanı
        public string Equipment { get; set; } // "equipment" alanı
        public string Difficulty { get; set; } // "difficulty" alanı
        public string Instructions { get; set; } // "instructions" alanı
    }
//}