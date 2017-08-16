using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Nhaccuatui.Structure;

namespace Nhaccuatui.Function
{
    public class HomePage
    {
        private static string home = "http://www.nhaccuatui.com";
        public static List<NCTItem> ItemList()
        {
            List<NCTItem> list = new List<NCTItem>();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(home);

            string html = WebUtility.HtmlDecode(httpClient.GetStringAsync("").Result);

            var info = Regex.Matches(html, @"<div class=""tile_box_key"">(.*?)/ul>", RegexOptions.Singleline);
            foreach(var item in info)
            {
                list.Add(new NCTItem(item.ToString()));   
            }
            return list;
        }
    }
}
