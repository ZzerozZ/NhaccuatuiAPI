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
        public class TopVideo
        {
            private static string topVN = "http://www.nhaccuatui.com/video/top-20.nhac-viet.html";
            private static string topUS = "http://www.nhaccuatui.com/video/top-20.au-my.html";
            private static string topKR = "http://www.nhaccuatui.com/video/top-20.nhac-han.html";

            private List<string> vPop;
            private List<string> kPop;
            private List<string> uSUK;

            public List<string> VPop { get => vPop; set => vPop = value; }
            public List<string> KPop { get => kPop; set => kPop = value; }
            public List<string> USUK { get => uSUK; set => uSUK = value; }


            public TopVideo()
            {
                VPop = new List<string>();
                KPop = new List<string>();
                USUK = new List<string>();
                
                GetTop.Get(topVN, VPop);
                GetTop.Get(topUS, USUK);
                GetTop.Get(topKR, KPop);
                
            }

            /// <summary>
            /// Get 20 most popular VPop Video for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Video> AllVPopVideo()
            {
                ObservableCollection<Video> list = new ObservableCollection<Video>();

                foreach (string videoUrl in VPop)
                {
                    list.Add(new Video(videoUrl));
                }

                return list;
            }

            /// <summary>
            /// Get 20 most popular USUK Video for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Video> AllUSUKVideo()
            {
                ObservableCollection<Video> list = new ObservableCollection<Video>();

                foreach (string videoUrl in USUK)
                {
                    list.Add(new Video(videoUrl));
                }

                return list;
            }

            /// <summary>
            /// Get 20 most popular KPop Playlist for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Video> AllKPopVideo()
            {
                ObservableCollection<Video> list = new ObservableCollection<Video>();

                foreach (string videoUrl in KPop)
                {
                    list.Add(new Video(videoUrl));
                }

                return list;
            }

        }
    }
}
