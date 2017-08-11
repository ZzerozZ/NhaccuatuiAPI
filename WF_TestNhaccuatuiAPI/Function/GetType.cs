using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TestNhaccuatuiAPI.Function
{
    public enum NCTType
    {
        Song, 
        Playlist,
        Video
    }
    public class GetType
    {
        public static NCTType Get(string url)
        {            
            if (url.IndexOf("playlist") > 0)
                return NCTType.Playlist;
            if (url.IndexOf("video") > 0)
                return NCTType.Video;

            return NCTType.Song;
        }
    }
}
