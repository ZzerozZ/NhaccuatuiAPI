using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WF_TestNhaccuatuiAPI.Manipulation
{
    namespace Charts
    {
        public class TopSong
        {
            private static string topVN = "http://www.nhaccuatui.com/bai-hat/top-20.nhac-viet.html";
            private static string topUS = "http://www.nhaccuatui.com/bai-hat/top-20.au-my.html";
            private static string topKR = "http://www.nhaccuatui.com/bai-hat/top-20.nhac-han.html";

            private List<string> vPop;
            private List<string> kPop;
            private List<string> uSUK;

            public List<string> VPop { get => vPop; set => vPop = value; }
            public List<string> KPop { get => kPop; set => kPop = value; }
            public List<string> USUK { get => uSUK; set => uSUK = value; }

            public TopSong()
            {
                VPop = new List<string>();
                KPop = new List<string>();
                USUK = new List<string>();

                //Get VPop topsong:

                HttpClient VPopHttpClient = new HttpClient();
                VPopHttpClient.BaseAddress = new Uri(topVN);

                string html = WebUtility.HtmlDecode(VPopHttpClient.GetStringAsync("").Result);

                string songInfo = Regex.Match(html, @"<ul class=""list_show_chart"">(.*?)/ul>", RegexOptions.Singleline).Value;

                var songList = Regex.Matches(songInfo, @"<li>(.*?)/div>", RegexOptions.Singleline);

                foreach (var song in songList)
                {
                    VPop.Add(Regex.Match(song.ToString(), "http(.*?)html", RegexOptions.Singleline).Value);
                }


                //Get USUK topsong:
                HttpClient USUKHttpClient = new HttpClient();
                USUKHttpClient.BaseAddress = new Uri(topUS);

                html = WebUtility.HtmlDecode(USUKHttpClient.GetStringAsync("").Result);

                songInfo = Regex.Match(html, @"<ul class=""list_show_chart"">(.*?)/ul>", RegexOptions.Singleline).Value;

                songList = Regex.Matches(songInfo, @"<li>(.*?)/div>", RegexOptions.Singleline);

                foreach (var song in songList)
                {
                    USUK.Add(Regex.Match(song.ToString(), "http(.*?)html", RegexOptions.Singleline).Value);
                }

                //Get KPop topsong:
                HttpClient KPopHttpClient = new HttpClient();
                KPopHttpClient.BaseAddress = new Uri(topKR);

                html = WebUtility.HtmlDecode(KPopHttpClient.GetStringAsync("").Result);

                songInfo = Regex.Match(html, @"<ul class=""list_show_chart"">(.*?)/ul>", RegexOptions.Singleline).Value;

                songList = Regex.Matches(songInfo, @"<li>(.*?)/div>", RegexOptions.Singleline);

                foreach (var song in songList)
                {
                    KPop.Add(Regex.Match(song.ToString(), "http(.*?)html", RegexOptions.Singleline).Value);
                }

                //foreach(var song in songList)
                //{
                //    Songs.Add(new Song(Regex.Match(song.ToString(), "http(.*?)html", RegexOptions.Singleline).Value));
                //}
            }


            /// <summary>
            /// Get 20 most popular VPop song for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Song> AllVPopSong()
            {
                ObservableCollection<Song> list = new ObservableCollection<Song>();

                foreach (string songUrl in VPop)
                {
                    list.Add(new Song(songUrl));
                }

                return list;
            }

            /// <summary>
            /// Get 20 most popular USUK song for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Song> AllUSUKSong()
            {
                ObservableCollection<Song> list = new ObservableCollection<Song>();

                foreach (string songUrl in USUK)
                {
                    list.Add(new Song(songUrl));
                }

                return list;
            }

            /// <summary>
            /// Get 20 most popular KPop song for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Song> AllKPopSong()
            {
                ObservableCollection<Song> list = new ObservableCollection<Song>();

                foreach (string songUrl in KPop)
                {
                    list.Add(new Song(songUrl));
                }

                return list;
            }

        }

    }
}
