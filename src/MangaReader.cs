using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reader
{
    public class MangaReader
    {
        private IList<MangaData> data;

        private string url;

        private HtmlDocument doc;

        public MangaReader ()
        {
            data = null;

            url = "http://www.mangareader.net";
            doc = null;
        }

        public string Url
        {
            get
            {
                return url;
            }
        }

        public Task<IList<MangaData>> GetDataAsync()
        {
            return Task.Factory.StartNew(() => GetData());
        }

        public IList<MangaData> GetData()
        {
            if (doc == null)
                doc = Html.GetDoc(url + "/alphabetical");

            if (data != null)
                return data;

            IList<MangaData> rdata = new List<MangaData>();

            IList<HtmlNode> nodes = doc.DocumentNode.SelectNodes("//div[@class='series_alpha']");

            foreach (HtmlNode div in nodes)
            {
                HtmlNode ul = div.ChildNodes.Where(c => c.Name == "ul").First();

                foreach (HtmlNode li in ul.ChildNodes.Where(c => c.Name == "li"))
                {
                    HtmlNode alink = li.ChildNodes.Where(c => c.Name == "a").First();

                    string name = alink.Attributes.Where(attr => attr.Name == "href").First().Value.Substring(1);
                    string text = alink.InnerText;

                    rdata.Add(new MangaData(name, text));
                }
            }

            data = rdata;
            return data;
        }
    }
}
