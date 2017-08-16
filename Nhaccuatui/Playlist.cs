using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nhaccuatui
{
    public class Playlist
    {
        private string url;
        private string name;
        private string singerName;
        private List<string> songUrl;
        private string avatarPath;

       
        public string Url { get => url; set => url = value; }
        public string Name { get => name; set => name = value; }
        public string SingerName { get => singerName; set => singerName = value; }
        public List<string> SongUrl { get => songUrl; set => songUrl = value; }
        public string AvatarPath { get => avatarPath; set => avatarPath = value; }

        public Playlist() { }
        public Playlist(string playlistUrl)
        {
            Url = playlistUrl;


            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(playlistUrl);

            string html = WebUtility.HtmlDecode(httpClient.GetStringAsync("").Result);
            //get avatar:
            AvatarPath = Regex.Match(html, @"src=""http://avatar.nct.nixcdn.com/playlist/(.*?)jpg", RegexOptions.Singleline).Value.Replace(@"src=""", "");

            string info = Regex.Match(html, @"<ul class=""list_song_in_album"">(.*?)/ul>", RegexOptions.Singleline).Value;

            var songsUrl = Regex.Matches(info, @"<meta content=""http://www.nhaccuatui.com/bai-hat/(.*?)html", RegexOptions.Singleline);

            //get name & singerName:
            info = Regex.Match(html, @"<h1 itemprop=""name"">(.*?)</h2>", RegexOptions.Singleline).Value.Replace(@"<h1 itemprop=""name"">", "");
            Name = Regex.Match(info, @"(.*?)</h1>", RegexOptions.Singleline).Value.Replace(@"</h1>", "");
            SingerName = Regex.Match(Regex.Match(info, @"<h2(.*?)</h2>", RegexOptions.Singleline).Value, @">(.*?)<", RegexOptions.Singleline).Value.Replace(">", "").Replace("<", "");

            //get song list:
            SongUrl = new List<string>();
            foreach(var url in songsUrl)
            {
                SongUrl.Add(url.ToString().Replace(@"<meta content=""", ""));
            }
        }

        /// <summary>
        /// Download all song in this Playlist
        /// </summary>
        /// <param name="SavePath"></param>
        /// <returns></returns>
        public bool Download(string SavePath)
        {
            try
            {
                foreach (string songPath in SongUrl)
                {
                    Song song = new Song(songPath);
                    song.Download(SavePath);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
