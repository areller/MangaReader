using HtmlAgilityPack;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class Html
    {
        public static Task<HtmlDocument> GetDocAsync(string url)
        {
            return Task.Factory.StartNew(() => GetDoc(url));
        }

        public static HtmlDocument GetDoc(string url)
        {
            HttpClient http = new HttpClient();

            Task<byte[]> task = http.GetByteArrayAsync(url);

            byte[] res = task.Result;

            string src = Encoding.GetEncoding("utf-8").GetString(res, 0, res.Length - 1);
            src = WebUtility.HtmlDecode(src);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(src);

            return doc;
        }
    }
}
