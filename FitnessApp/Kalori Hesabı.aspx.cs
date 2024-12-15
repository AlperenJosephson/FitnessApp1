using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitnessApp
{
    public partial class Kalori_Hesabı : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                int yas = int.Parse(txtYas.Text);
                double kilo = double.Parse(txtKilo.Text);
                double boy = double.Parse(txtBoy.Text);
                double aktivite = double.Parse(ddlAktivite.SelectedValue);
                string cinsiyet = ddlCinsiyet.SelectedValue;

                // BMR Hesaplama (Harris-Benedict Denklemi)
                double bmr;
                if (cinsiyet == "Erkek")
                {
                    bmr = 88.362 + (13.397 * kilo) + (4.799 * boy) - (5.677 * yas);
                }
                else
                {
                    bmr = 447.593 + (9.247 * kilo) + (3.098 * boy) - (4.330 * yas);
                }

                // Günlük kalori ihtiyacı (Aktivite seviyesine göre)
                double toplamKalori = bmr * aktivite;

                // kcal ve cal hesaplama
                double toplamKcal = toplamKalori / 1000;          // kcal değeri
                double toplamCal = toplamKalori;    // cal değeri (1 kcal = 1000 cal)

                // Sonucu ekrana yazdır (binlik ayraçlı)
                lblSonuc.Text = $"Günlük kalori ihtiyacınız: {toplamKcal:N2} kcal ({toplamCal:N0} cal)";
                lblSonuc.CssClass = "alert alert-info";
                lblSonuc.Visible = true;
            }
            catch (Exception ex)
            {
                lblSonuc.Text = "Bir hata oluştu. Lütfen girdiğiniz değerleri kontrol edin.";
                lblSonuc.CssClass = "alert alert-danger";
                lblSonuc.Visible = true;
            }
        }


    }
}