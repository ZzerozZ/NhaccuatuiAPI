using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WF_TestNhaccuatuiAPI
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
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public string SourceUrl { get => sourceUrl; set => sourceUrl = value; }
        public string Author { get => author; set => author = value; }
        public string Lyric { get => lyric; set => lyric = value; }
        public string CoverPhotoLink { get => coverPhotoLink; set => coverPhotoLink = value; }
        public string AlbumName { get => albumName; set => albumName = value; }
        public int TotalTime { get => totalTime; set => totalTime = value; }

        private string name;
        private string path;
        private string sourceUrl;
        private string author;
        private string lyric;
        private string coverPhotoLink;
        private string albumName;
        private int totalTime;


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
