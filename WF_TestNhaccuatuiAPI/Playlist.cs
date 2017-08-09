using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WF_TestNhaccuatuiAPI
{
    public class Playlist
    {
        private string url;
        private string name;
        private string singer;
        private List<string> songUrl;

        public string Url { get => Url; set => Url = value; }
        public string Name { get => name; set => name = value; }
        public string Singer { get => singer; set => singer = value; }
        public List<string> SongUrl { get => songUrl; set => songUrl = value; }


        public Playlist() { }
        public Playlist(string playlistUrl)//Building
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(playlistUrl);

            string html = WebUtility.HtmlDecode(httpClient.GetStringAsync("").Result);
        }
    }
}
