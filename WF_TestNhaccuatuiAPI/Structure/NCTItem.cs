using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WF_TestNhaccuatuiAPI.Structure
{
    public class NCTItem
    {
        private string name;
        private List<string> itemsPath;
        
        public string Name { get => name; set => name = value; }
        public List<string> ItemsPath { get => itemsPath; set => itemsPath = value; }


        public NCTItem(string htmlString)
        {
            ItemsPath = new List<string>();
            Name = Regex.Match(htmlString, @"title=""(.*?)""", RegexOptions.Singleline).Value.Replace(@"title=""", "").Replace(@"""", "");
            var list = Regex.Matches(htmlString, @"<li(.*?)/li", RegexOptions.Singleline);
           for(int i = 0; i < list.Count - 1; i++)
            {
                ItemsPath.Add(Regex.Match(list[i].ToString(), @"http(.*?)html", RegexOptions.Singleline).Value);
            }
        }
    }
}
