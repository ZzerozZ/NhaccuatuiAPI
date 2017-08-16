using Nhaccuatui.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nhaccuatui.Manipulation
{
    namespace Charts
    {
        public class GetTop
        {
            public static void Get(string baseAddress, List<NCTObject> output)
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseAddress);

                string html = WebUtility.HtmlDecode(httpClient.GetStringAsync("").Result);

                string itemInfo = Regex.Match(html, @"<ul class=""list_show_chart"">(.*?)/ul>", RegexOptions.Singleline).Value;

                var itemList = Regex.Matches(itemInfo, @"<li>(.*?)/div>", RegexOptions.Singleline);

                foreach (var song in itemList)
                {
                    itemInfo = Regex.Match(song.ToString(), @"class=""name_song"" title=""(.*?)""", RegexOptions.Singleline).Value.Replace(@"class=""name_song"" title=", "").Replace(@"""", "");
                    output.Add(new NCTObject(itemInfo, Regex.Match(song.ToString(), "http(.*?)html", RegexOptions.Singleline).Value));
                }
            }
        }
    }

}
