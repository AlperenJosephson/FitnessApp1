using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.WebSockets;
using System.Reflection.Emit;

namespace FitnessApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            baglanti.Open();
            
            // aynı mailden var mı?
            SqlCommand kontrolKomut = new SqlCommand("select count(*) from TableUsers where Mail=@Mail", baglanti);
            kontrolKomut.Parameters.AddWithValue("@Mail", txtMail.Text.ToString());
            int kayitliKullanici = (int)kontrolKomut.ExecuteScalar();

            if (kayitliKullanici > 0)
            {
                Label1.Text = "Bu mail adresi zaten kayıtlı.";
            }
            else
            {
                // Yeni kullanıcı kaydet
                SqlCommand komut = new SqlCommand("INSERT INTO TableUsers (UserName, Mail, Password) VALUES (@UserName, @Mail, @Password)", baglanti);
                komut.Parameters.AddWithValue("@UserName", txtKullaniciAdi.Text.ToString());
                komut.Parameters.AddWithValue("@Mail", txtMail.Text.ToString());
                komut.Parameters.AddWithValue("@Password", txtSifre.Text.ToString());

                int sonuc = komut.ExecuteNonQuery(); // Veritabanına kaydet

                if (sonuc > 0)
                {
                    // Kayıt başarılı, kullanıcıyı giriş sayfasına yönlendir
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Label1.Text = "Kayıt işlemi sırasında bir hata oluştu.";
                }
            }

            baglanti.Close();
            baglanti.Dispose();
        }

    }
}
