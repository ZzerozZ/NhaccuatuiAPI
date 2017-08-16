using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nhaccuatui
{
    public class Video
    {
        private string key;
        private string path;
        private string name;
        private string authorLink;
        private string source;
        private string sourceLowQuality;
        private string sourceHighQuality;
        private string previewPhotoUrl;
        private string nextVideoPath;

        public string Key { get => key; set => key = value; }
        public string Path { get => path; set => path = value; }
        public string Name { get => name; set => name = value; }
        public string AuthorLink { get => authorLink; set => authorLink = value; }
        public string Source { get => source; set => source = value; }
        public string SourceLowQuality { get => sourceLowQuality; set => sourceLowQuality = value; }
        public string SourceHighQuality { get => sourceHighQuality; set => sourceHighQuality = value; }
        public string PreviewPhotoUrl { get => previewPhotoUrl; set => previewPhotoUrl = value; }
        public string NextVideoPath { get => nextVideoPath; set => nextVideoPath = value; }

        public Video() { }
        public Video(string videourl)
        {
            Path = videourl;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(videourl);

            string html = WebUtility.HtmlDecode(client.GetStringAsync("").Result);

            //Get author link:
            AuthorLink = Regex.Match(Regex.Match(html, @"<h2 class=""name-singer""(.*?)html", RegexOptions.Singleline).Value, @"http(.*?)html", RegexOptions.Singleline).Value;

            string info = Regex.Match(html, @" player.peConfig.xmlURL = ""(.*?)"";", RegexOptions.Singleline).Value.Replace(@" player.peConfig.xmlURL = """, "").Replace(@""";", "");

            HttpClient newClient = new HttpClient();
            newClient.BaseAddress = new Uri(info);

            html = WebUtility.HtmlDecode(newClient.GetStringAsync("").Result);

            var infoList = Regex.Matches(html, @"CDATA(.*?)>", RegexOptions.Singleline);

            //Get others info:
            PreviewPhotoUrl = infoList[0].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
            Name = infoList[1].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
            Key = infoList[4].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
            Source = infoList[5].ToString().Replace("CDATA[", "").Replace(@"]]>", ""); 
            SourceLowQuality = infoList[6].ToString().Replace("CDATA[", "").Replace(@"]]>", ""); 
            SourceHighQuality = infoList[7].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
            NextVideoPath = infoList[27].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
        }

        public bool Download(string SavePath)
        {
            try
            {
                string videoname = SavePath + "\\" + Name + ".mp4";
                if (!File.Exists(videoname))
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(Path, videoname);
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
