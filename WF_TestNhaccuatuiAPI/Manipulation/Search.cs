using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WF_TestNhaccuatuiAPI.Manipulation
{
    public class Search
    {
        private HttpClient httpClient;

        public Search()
        {
            httpClient = new HttpClient();
        }

        public static ObservableCollection<Song> Song(string keyWord)
        {
            ObservableCollection<Song> songs = new ObservableCollection<Song>();



            return songs;
        }
    }
}
