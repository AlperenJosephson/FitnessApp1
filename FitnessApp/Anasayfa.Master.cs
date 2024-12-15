using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitnessApp
{
    public partial class Anasayfa : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            baglanti.Open();

            if (!IsPostBack)
            {
                if (Session["KullaniciAdi"] != null) // Kullanıcı giriş yapmışsa
                {
                    lblKullaniciAdi.InnerText = "Hoşgeldin, " + Session["KullaniciAdi"].ToString(); // İsmi göster
                    //btnGirisYap.Visible = false; // Giriş yap butonunu gizle
                }
                else
                {
                    lblKullaniciAdi.InnerText = ""; // Boş bırak
                    //btnGirisYap.Visible = true; // Butonu göster
                }
            }

        }

        protected void btnGirisYap_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

    }
}