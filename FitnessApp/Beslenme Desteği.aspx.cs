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
                new Article { Id = 1, Title = "Sağlıklı Tavuk Yemeği Tarifi", Content = "Tavuk yemeğini fırında sebzelerle pişirerek sağlıklı bir öğün elde edebilirsiniz..." },
                new Article { Id = 2, Title = "Ev Yapımı Sağlıklı Bar Tarifi", Content = "Yulaf, bal, ve kuru meyvelerle evde kolayca sağlıklı bar yapabilirsiniz..." }
            };
        }
        public class Article
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
        }
    }
}