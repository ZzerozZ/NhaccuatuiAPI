﻿using System;
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
            public static void Get(string baseAddress, List<string> output)
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseAddress);

                string html = WebUtility.HtmlDecode(httpClient.GetStringAsync("").Result);

                string itemInfo = Regex.Match(html, @"<ul class=""list_show_chart"">(.*?)/ul>", RegexOptions.Singleline).Value;

                var itemList = Regex.Matches(itemInfo, @"<li>(.*?)/div>", RegexOptions.Singleline);

                foreach (var song in itemList)
                {
                    output.Add(Regex.Match(song.ToString(), "http(.*?)html", RegexOptions.Singleline).Value);
                }
            }
        }
    }

}
