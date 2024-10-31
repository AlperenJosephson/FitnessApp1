using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FitnessApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //SqlConnection baglanti = new SqlConnection(conf_baglanti);
            SqlConnection baglanti = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Deneme_Login;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            baglanti.Open();  
            SqlCommand komut = new SqlCommand("select * from TableUsers where Mail=@Mail and Password=@Password",baglanti);
            komut.Parameters.AddWithValue("@Mail", txtMail.Text.ToString());
            komut.Parameters.AddWithValue("@Password", txtSifre.Text.ToString());
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Session["Kullanici"] = oku["Mail"].ToString();
                Response.Redirect("~/Default.aspx");
            }
            else {
                Label1.Text = "Mail adresi veya Şifre Hatalı";
            }
            oku.Close();
            baglanti.Close();
            baglanti.Dispose();
        }
    }
}