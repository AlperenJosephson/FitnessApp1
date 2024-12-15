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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO SaglikTakibi (Mail, Tarih, Kilo, Boy, AdimSayisi, EgzersizAdi, EgzersizSuresi) 
                                 VALUES (@Mail, @Tarih, @Kilo, @Boy, @AdimSayisi, @EgzersizAdi, @EgzersizSuresi)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Mail", userMail);
                command.Parameters.AddWithValue("@Tarih", DateTime.Now);
                command.Parameters.AddWithValue("@Kilo", txtKilo.Text);
                command.Parameters.AddWithValue("@Boy", txtBoy.Text);
                command.Parameters.AddWithValue("@AdimSayisi", txtAdimSayisi.Text);
                command.Parameters.AddWithValue("@EgzersizAdi", txtEgzersizAdi.Text);
                command.Parameters.AddWithValue("@EgzersizSuresi", txtEgzersizSuresi.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            // Veriyi kaydettikten sonra listeyi yeniden yükle
            LoadHealthData();
            ClearFields();
        }


        private void LoadHealthData()
        {
            string userMail = Session["Kullanici"] as string;
            if (string.IsNullOrEmpty(userMail)) return;

            List<HealthData> healthDataList = new List<HealthData>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Tarih, Kilo, Boy, AdimSayisi, EgzersizAdi, EgzersizSuresi FROM SaglikTakibi WHERE Mail = @Mail";

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
                        EgzersizSuresi = reader["EgzersizSuresi"].ToString()
                    });
                }
                reader.Close();
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

        public class HealthData
        {
            public string Tarih { get; set; }
            public string Kilo { get; set; }
            public string Boy { get; set; }
            public string AdimSayisi { get; set; }
            public string EgzersizAdi { get; set; }
            public string EgzersizSuresi { get; set; }
        }
    }
}