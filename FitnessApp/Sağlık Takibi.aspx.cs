using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;



namespace FitnessApp
{
    public partial class Sağlık_Takibi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadHealthData();
            }
        }

        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string userMail = Session["Kullanici"] as string;
            if (string.IsNullOrEmpty(userMail))
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            try
            {
                // Kullanıcıdan gelen değerler
                /*if (!float.TryParse(txtKilo.Text, out float kilo) ||
                !float.TryParse(txtBoy.Text, out float boy) ||
                !int.TryParse(txtAdimSayisi.Text, out int adimSayisi) ||
                !int.TryParse(txtEgzersizSuresi.Text, out int egzersizSuresi))
                {
                    lblGeriBildirim.Text = "Lütfen geçerli sayısal değerler girin.";
                    return;
                }*/

                float kilo = float.Parse(txtKilo.Text);
                int boyCm = int.Parse(txtBoy.Text); // Kullanıcıdan cm cinsinden tam sayı bekleniyor
                float boyM = boyCm / 100.0f; // Santimetreyi metreye çeviriyoruz
                int adimSayisi = int.Parse(txtAdimSayisi.Text);
                int egzersizSuresi = int.Parse(txtEgzersizSuresi.Text);
                string egzersizAdi = txtEgzersizAdi.Text;

                decimal kilo2 = decimal.Parse(txtKilo.Text);
                decimal boyCm2 = decimal.Parse(txtBoy.Text);
                decimal boyM2 = boyCm2 / 100;
                decimal vke2 = Math.Round(kilo2 / (boyM2 * boyM2), 2);

                // VKE Hesaplama
                //float vke = kilo / (boyM * boyM);

                //float vke = (float)kilo / (boyM * boyM); // VKE hesaplanır ve yuvarlanır
                //vke = (float)Math.Round(vke, 2); // 2 ondalık basamağa yuvarlanır

                float vke = (float)Math.Round(kilo / (boyM * boyM), 2);

                string geriBildirim = "";
                if (vke < 18.5)
                    geriBildirim = "Zayıf kategorisindesiniz.";
                else if (vke >= 18.5 && vke < 24.9)
                    geriBildirim = "Normal kilodasınız.";
                else if (vke >= 25 && vke < 29.9)
                    geriBildirim = "Fazla kilolu kategorisindesiniz.";
                else
                    geriBildirim = "Obezite kategorisindesiniz. Dikkat!";

                // Geri bildirim oluştur
                //string geriBildirim = GetHealthFeedback(vke, adimSayisi);


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    /*string query = @"INSERT INTO SaglikTakibi (Mail, Tarih, Kilo, Boy, AdimSayisi, EgzersizAdi, EgzersizSuresi) 
                                     VALUES (@Mail, @Tarih, @Kilo, @Boy, @AdimSayisi, @EgzersizAdi, @EgzersizSuresi)";*/
                    string query = @"INSERT INTO SaglikTakibi (Mail, Tarih, Kilo, Boy, AdimSayisi, EgzersizAdi, EgzersizSuresi, VucutKitleEndeksi) 
                                         VALUES (@Mail, @Tarih, @Kilo, @Boy, @AdimSayisi, @EgzersizAdi, @EgzersizSuresi, @VKE)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Mail", userMail);
                    command.Parameters.AddWithValue("@Tarih", DateTime.Now);
                    command.Parameters.AddWithValue("@Kilo", kilo);
                    command.Parameters.AddWithValue("@Boy", boyCm);
                    command.Parameters.AddWithValue("@AdimSayisi", adimSayisi);
                    command.Parameters.AddWithValue("@EgzersizAdi", egzersizAdi);
                    command.Parameters.AddWithValue("@EgzersizSuresi", egzersizSuresi);
                    command.Parameters.AddWithValue("@VKE", vke2);

                    connection.Open();
                    command.ExecuteNonQuery();
                    //connection.Close();
                }

                // Veriyi kaydettikten sonra listeyi yeniden yükle
                LoadHealthData();
                ClearFields();
                Response.Write($"<script>alert('{geriBildirim}');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Hata oluştu: {ex.Message}');</script>");
            }

        }
        private void LoadHealthData()
        {
            string userMail = Session["Kullanici"] as string;
            if (string.IsNullOrEmpty(userMail)) return;

            List<HealthData> healthDataList = new List<HealthData>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Tarih, Kilo, Boy, AdimSayisi, EgzersizAdi, EgzersizSuresi, VucutKitleEndeksi FROM SaglikTakibi WHERE Mail = @Mail";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Mail", userMail);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    healthDataList.Add(new HealthData
                    {
                        Tarih = Convert.ToDateTime(reader["Tarih"]).ToString("dd/MM/yyyy"),
                        Kilo = reader["Kilo"].ToString(),
                        Boy = reader["Boy"].ToString(),
                        AdimSayisi = reader["AdimSayisi"].ToString(),
                        EgzersizAdi = reader["EgzersizAdi"].ToString(),
                        EgzersizSuresi = reader["EgzersizSuresi"].ToString(),
                        VKE = reader["VucutKitleEndeksi"].ToString()
                    });
                }
            }

            RepeaterSaglikTakibi.DataSource = healthDataList;
            RepeaterSaglikTakibi.DataBind();
        }

        private void ClearFields()
        {
            txtKilo.Text = "";
            txtBoy.Text = "";
            txtAdimSayisi.Text = "";
            txtEgzersizAdi.Text = "";
            txtEgzersizSuresi.Text = "";
        }

        private string GetHealthFeedback(float vke, int adimSayisi)
        {
            string feedback = "Sağlık Durumu: ";
            if (vke < 18.5)
                feedback += "Zayıf. Sağlıklı kilo alımı önerilir.";
            else if (vke >= 18.5 && vke < 24.9)
                feedback += "Normal. Kilonuz sağlıklı aralıkta.";
            else if (vke >= 25 && vke < 29.9)
                feedback += "Fazla kilolu. Dikkat edilmesi önerilir.";
            else
                feedback += "Obez. Sağlık risklerinizi azaltmak için önlem alın.";

            if (adimSayisi < 5000)
                feedback += " Ayrıca günlük adım sayınız 5000'den az. Daha aktif olun!";
            else
                feedback += " Tebrikler! Adım hedefinizi tamamladınız.";

            return feedback;
        }

        public class HealthData
        {
            public string Tarih { get; set; }
            public string Kilo { get; set; }
            public string Boy { get; set; }
            public string AdimSayisi { get; set; }
            public string EgzersizAdi { get; set; }
            public string EgzersizSuresi { get; set; }
            public string VKE { get; set; }
        }
    }
}