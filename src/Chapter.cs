using HtmlAgilityPack;
using System.Linq;
using System.Threading.Tasks;

namespace Reader
{
    public class Chapter
    {
        private int number;

        private int count;

        private string url;

        private HtmlDocument doc;

        public Chapter(Manga Manga, int Number)
        {
            this.number = Number;
            this.count = -1;

            url = Manga.Url + "/" + Number.ToString();
            doc = null;
        }

        public string Url
        {
            get
            {
                return url;
            }
        }

        public Task<int> GetPagesAsync()
        {
            return Task.Factory.StartNew(() => GetPages());
        }

        public int GetPages()
        {
            if (doc == null)
                doc = Html.GetDoc(url);

            if (count != -1)
                return count;

            HtmlNode node = doc.GetElementbyId("pageMenu");

            count = node.ChildNodes.Where(c => c.Name == "option").Count();
            return count;
        }
    }
}
