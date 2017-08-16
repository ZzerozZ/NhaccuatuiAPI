using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nhaccuatui.Structure
{
    public class NCTItem
    {
        private string name;
        private List<NCTObject> items;
        
        public string Name { get => name; set => name = value; }
        public List<NCTObject> Items { get => items; set => items = value; }


        public NCTItem(string htmlString)
        {
            string temp = "";
            Items = new List<NCTObject>();
            Name = Regex.Match(htmlString, @"title=""(.*?)""", RegexOptions.Singleline).Value.Replace(@"title=""", "").Replace(@"""", "");
            var list = Regex.Matches(htmlString, @"<li(.*?)/li", RegexOptions.Singleline);
            for(int i = 0; i < list.Count - 1; i++)
            {
                temp = Regex.Match(list[i].ToString(), @"title=""(.*?)""", RegexOptions.Singleline).Value.Replace("title=", "").Replace(@"""", "");
                Items.Add(new NCTObject(temp, Regex.Match(list[i].ToString(), @"http(.*?)html", RegexOptions.Singleline).Value));
            }
        }
    }
}
