using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitnessApp
{
    public partial class Beslenme_Desteği : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var articles = GetArticles(); // Yazıları al
                ArticlesRepeater.DataSource = articles; // Repeater'a bağla
                ArticlesRepeater.DataBind(); // Verileri göster
            }
        }

        private List<Article> GetArticles()
        { 
            return new List<Article>
            {
                new Article { Id = 1, Title = "Protein Deposu Sağlıklı Omlet Tarifi", Content = "Kahvaltıda hem lezzetli hem de sağlıklı bir alternatif arıyorsanız, bu protein deposu omlet tam size göre! İhtiyacınız olan malzemeler: 3 adet yumurta, 1 tatlı kaşığı zeytinyağı, 1 tutam ıspanak, 50 gram beyaz peynir, ve 1 adet kırmızı biber. Tüm malzemeleri bir kapta karıştırın ve kısık ateşte pişirin. Afiyet olsun!", ImageURL = "assets/images/omlet.jpg" },
                new Article { Id = 2, Title = "Ev Yapımı Sağlıklı Smoothie Tarifi", Content = "Spor sonrası enerji almak ve ferahlamak için bu smoothie tam ihtiyacınız olan şey! 1 adet muz, 1 su bardağı süt (veya badem sütü), 1 tatlı kaşığı bal ve 1 tatlı kaşığı chia tohumunu blenderda karıştırın. Üzerine birkaç buz ekleyerek servis edebilirsiniz. Hem sağlıklı hem de lezzetli!", ImageURL = "assets/images/smoothie.jpg" },
                new Article { Id = 3, Title = "Fırında Sebzeli Tavuk Tarifi", Content = "Akşam yemeğinde hem besleyici hem de pratik bir yemek arıyorsanız, fırında sebzeli tavuk tam size göre! 300 gram tavuk göğsü, 1 adet kabak, 1 adet havuç, 1 adet patates, 1 yemek kaşığı zeytinyağı ve çeşitli baharatlar (kekik, pul biber, karabiber) ile lezzetli bir tarif hazırlayabilirsiniz. Sebzeleri doğrayın, baharatlarla harmanlayın ve tavuklarla birlikte 180 derecede 30 dakika fırında pişirin.", ImageURL = "assets/images/Tavuk.jpg" }
            };
        }
        public class Article
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public string ImageURL { get; set; }
        }
    }
}