using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FitnessApp
{
    public partial class BeslenmeDestegiDetay : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int articleId = int.Parse(Request.QueryString["id"] ?? "0");
                var article = GetArticles().FirstOrDefault(a => a.Id == articleId);

                if (article != null)
                {
                    // Başlık ve içerik doldurulur
                    articleTitle.InnerText = article.Title; // Doğrudan erişim
                    articleContent.InnerText = article.Content; // Doğrudan erişim
                }
                else
                {
                    // Yazı bulunamadıysa
                    articleTitle.InnerText = "Yazı Bulunamadı";
                    articleContent.InnerText = "Seçilen yazı bulunamadı veya silinmiş olabilir.";
                }
            }
        }

        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // URL'den gelen "id" parametresini al
                int articleId = int.Parse(Request.QueryString["id"] ?? "0");
                var article = GetArticles().FirstOrDefault(a => a.Id == articleId);

                // HTML elementlerini bul
                var titleElement = FindControl("articleTitle") as System.Web.UI.HtmlControls.HtmlGenericControl;
                var contentElement = FindControl("articleContent") as System.Web.UI.HtmlControls.HtmlGenericControl;


                if (article != null)
                {
                    // Başlık ve içerik doldurulur
                    titleElement.InnerText = article.Title;
                    contentElement.InnerText = article.Content;
                }
                else
                {
                    // Yazı bulunamadıysa
                    titleElement.InnerText = "Yazı Bulunamadı";
                    contentElement.InnerText = "Seçilen yazı bulunamadı veya silinmiş olabilir.";
                }
            }
        }
        */

        // Örnek veri kaynağı
        private List<Article> GetArticles()
        {
            return new List<Article>
            {
                new Article { Id = 1, Title = "Sağlıklı Tavuk Yemeği Tarifi", Content = "Tavuk yemeğini fırında sebzelerle pişirerek sağlıklı bir öğün elde edebilirsiniz..." },
                new Article { Id = 2, Title = "Ev Yapımı Sağlıklı Bar Tarifi", Content = "Yulaf, bal, ve kuru meyvelerle evde kolayca sağlıklı bar yapabilirsiniz..." }
            };
        }
    }

    // Yazı modeli
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

/*
namespace FitnessApp
{
    public partial class Beslenme_Desteği_Detay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // URL'den gelen "id" parametresini al
                int articleId = int.Parse(Request.QueryString["id"] ?? "0");
                var article = GetArticles().FirstOrDefault(a => a.Id == articleId);

                if (article != null)
                {
                    // Yazı bulunduysa başlık ve içerik doldurulur
                    TitleLabel.Text = article.Title;
                    ContentLabel.Text = article.Content;
                }
                else
                {
                    // Yazı bulunamadığında hata mesajı göster
                    TitleLabel.Text = "Yazı Bulunamadı";
                    ContentLabel.Text = "Seçilen yazı bulunamadı veya silinmiş olabilir.";
                }
            }

        }
    }
}*/