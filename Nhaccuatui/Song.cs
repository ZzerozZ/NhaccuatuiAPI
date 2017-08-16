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
    public class Song
    {
        //Instance:
        private Song instance;
        public Song Instance
        {
            get
            {
                if (instance == null)
                    instance = new Song();
                return instance;
            }

            private set => instance = value;
        }

        //Properties:
        public string ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public string SourceUrl { get => sourceUrl; set => sourceUrl = value; }
        public Singer Singer { get => singer; set => singer = value; }
        public string Lyric { get => lyric; set => lyric = value; }

        private string iD;//
        private string name;//
        private string path;//
        private string sourceUrl;//
        private Singer singer;//
        private string lyric;//

        //Constructor:
        public Song() { }

        public Song(string URL)
        {
            Path = URL;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            string html = WebUtility.HtmlDecode(client.GetStringAsync("").Result);

            string temp = Regex.Match(html, @"<p id=""divLyric""(.*?)/p>", RegexOptions.Singleline).Value.ToString();
       
            Lyric = Regex.Match(temp, @"<br />(.*?)</p>", RegexOptions.Singleline).Value.Replace("<br />", "\n").Replace("</p>", "");

            temp = Regex.Match(html, @"player.peConfig.xmlURL = ""(.*?)""", RegexOptions.Singleline).Value.Replace("player.peConfig.xmlURL = ", "").Replace(@"""","");

            HttpClient newclient = new HttpClient();
            newclient.BaseAddress = new Uri(temp);
            temp = newclient.GetStringAsync("").Result;

            var infoList = Regex.Matches(temp, @"CDATA(.*?)>", RegexOptions.Singleline);

            Name = infoList[0].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
            
            string name = infoList[2].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
            string avatarLink = infoList[9].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
            string link = infoList[10].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
            Singer = new Singer(name, link, avatarLink);

            SourceUrl = infoList[3].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
            ID = infoList[12].ToString().Replace("CDATA[", "").Replace(@"]]>", "");
        }
        //Method:

        
        public bool Download(string SavePath)
        {
            try
            {
                string songname = SavePath + "\\" + Name + ".mp3";
                if (!File.Exists(songname))
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(SourceUrl, songname);
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
