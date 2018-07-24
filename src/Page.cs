using HtmlAgilityPack;
using System.Linq;
using System.Threading.Tasks;

namespace Reader
{
    public class Page
    {
        private int number;

        private string url;

        private string image;

        private HtmlDocument doc;

        public Page(Chapter Chapter, int Number)
        {
            this.number = Number;
            this.image = null;

            url = Chapter.Url + "/" + Number;
            doc = null;
        }

        public string Url
        {
            get
            {
                return url;
            }
        }

        public Task<string> GetImageAsync()
        {
            return Task.Factory.StartNew(() => GetImage());
        }

        public string GetImage()
        {
            if (doc == null)
                doc = Html.GetDoc(url);

            if (image != null)
                return image;

            HtmlNode node = doc.GetElementbyId("img");

            image = node.Attributes.Where(attr => attr.Name == "src").First().Value;
            return image;
        }
    }
}
