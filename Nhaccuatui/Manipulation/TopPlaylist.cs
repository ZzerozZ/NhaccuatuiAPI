using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public class TopPlaylist
        {
            private static string topVN = "http://www.nhaccuatui.com/playlist/top-20.nhac-viet.html";
            private static string topUS = "http://www.nhaccuatui.com/playlist/top-20.au-my.html";
            private static string topKR = "http://www.nhaccuatui.com/playlist/top-20.nhac-han.html";

            private List<string> vPop;
            private List<string> kPop;
            private List<string> uSUK;

            public List<string> VPop { get => vPop; set => vPop = value; }
            public List<string> KPop { get => kPop; set => kPop = value; }
            public List<string> USUK { get => uSUK; set => uSUK = value; }


            public TopPlaylist()
            {
                VPop = new List<string>();
                KPop = new List<string>();
                USUK = new List<string>();

                GetTop.Get(topVN, VPop);
                GetTop.Get(topUS, USUK);
                GetTop.Get(topKR, KPop);
            }


            /// <summary>
            /// Get 20 most popular VPop playlist for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Playlist> AllVPopPlaylist()
            {
                ObservableCollection<Playlist> list = new ObservableCollection<Playlist>();

                foreach (string playlistUrl in VPop)
                {
                    list.Add(new Playlist(playlistUrl));
                }

                return list;
            }

            /// <summary>
            /// Get 20 most popular USUK playlist for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Playlist> AllUSUKPlaylist()
            {
                ObservableCollection<Playlist> list = new ObservableCollection<Playlist>();

                foreach (string playlistUrl in USUK)
                {
                    list.Add(new Playlist(playlistUrl));
                }

                return list;
            }

            /// <summary>
            /// Get 20 most popular KPop Playlist for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Playlist> AllKPopPlaylist()
            {
                ObservableCollection<Playlist> list = new ObservableCollection<Playlist>();

                foreach (string playlistUrl in KPop)
                {
                    list.Add(new Playlist(playlistUrl));
                }

                return list;
            }

        }
    }

}

