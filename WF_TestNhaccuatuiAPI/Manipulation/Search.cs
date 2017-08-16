using Nhaccuatui.Structure;
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
    public class Search
    {

        public Search()
        {
        }

        /// <summary>
        /// Get a collection song URL
        /// </summary>
        /// <param name="keyWord">Search string</param>
        /// <returns>List<NCTObject> with any ListItem is Name & Url of a song</string></returns>
        public static List<NCTObject> Song(string keyWord)
        {
            //return value:
            List<NCTObject> songs = new List<NCTObject>();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://www.nhaccuatui.com/tim-kiem/bai-hat?q=" + WebUtility.UrlEncode(keyWord));
             
            //Get html code:
            string html = WebUtility.HtmlDecode(httpClient.GetStringAsync("").Result);

            //Get song's Url list:
            var list = Regex.Matches(html, @" <h3 style=""display: inline;(.*?).html"" title=""(.*?)""", RegexOptions.Singleline);
            foreach(var item in list)
            {
                html = Regex.Match(item.ToString(), @" title=""(.*?)""", RegexOptions.Singleline).Value.Replace(" title=", "").Replace(@"""", "");
                songs.Add(new NCTObject(html, Regex.Match(item.ToString(), @"href =""(.*?)""", RegexOptions.Singleline).Value.ToString().Replace("href=", "").Replace(@"""", "")));
            }

            return songs;
        }


        /// <summary>
        /// Get a collection playlist URL
        /// </summary>
        /// <param name="keyWord">Search string</param>
        /// <returns>List<string> with any ListItem is Name & Url of a playlist</returns>
        public static List<NCTObject> PlayList(string keyWord)
        {
            //return value:
            List<NCTObject> playlists = new List<NCTObject>();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://www.nhaccuatui.com/tim-kiem/playlist?q=" + WebUtility.UrlEncode(keyWord));

            //Get html code:
            string html = WebUtility.HtmlDecode(httpClient.GetStringAsync("").Result);

            //get list:
            var info = Regex.Matches(Regex.Match(html, @"<ul class=""search_returns_list"">(.*?)/ul>", RegexOptions.Singleline).Value, @"><a href=""http://www.nhaccuatui.com/playlist/(.*?)html(.*?)title=""(.*?)""", RegexOptions.Singleline);
            foreach(var item in info)
            {
                html = Regex.Match(item.ToString(), @"title=""(.*?)""", RegexOptions.Singleline).Value.Replace("title=", "").Replace(@"""", "");
                playlists.Add(new NCTObject(html, Regex.Match(item.ToString(), @"http(.*?)html", RegexOptions.Singleline).Value));
            }

            return playlists;
        }

        /// <summary>
        /// Get a collection playlist URL
        /// </summary>
        /// <param name="keyWord">Search string</param>
        /// <returns>List<string> with any ListItem is Name & Url of a playlist</returns>
        public static List<string> Video(string keyWord)
        {
            //return value:
            List<string> listVideo = new List<string>();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://www.nhaccuatui.com/tim-kiem/mv?q=" + WebUtility.UrlEncode(keyWord));

            //Get html code:
            string html = WebUtility.HtmlDecode(httpClient.GetStringAsync("").Result);
            string info = Regex.Match(html, @"<ul class=""search_returns_list"">(.*?)/ul>", RegexOptions.Singleline).Value;

            //Get list:
            var videoList = Regex.Matches(info, @"<div class=""box_absolute""> (.*?)html", RegexOptions.Singleline);
            foreach(var video in videoList)
            {
                listVideo.Add(Regex.Match(video.ToString(), @"http(.*?)html", RegexOptions.Singleline).Value);
            }

            return listVideo;
        }
    }
}
