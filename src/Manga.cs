using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reader
{
    public class Manga
    {
        private string name;

        private int count;

        private string url;

        private HtmlDocument doc;

        public Manga(MangaReader Reader, string Name)
        {
            this.name = Name;
            this.count = -1;

            url = Reader.Url + "/" + name;
            doc = null;
        }

        public string Url
        {
            get
            {
                return url;
            }
        }

        public Task<int> GetChaptersAsync()
        {
            return Task.Factory.StartNew(() => GetChapters());
        }

        public int GetChapters()
        {
            if (doc == null)
                doc = Html.GetDoc(url);

            if (count != -1)
                return count;

            HtmlNode node = doc.GetElementbyId("chapterlist").ChildNodes.Where(c => c.Name == "table").First();

            count = node.ChildNodes.Where(c => c.Name == "tr").Count() - 1;
            return count;
        }
    }
}
