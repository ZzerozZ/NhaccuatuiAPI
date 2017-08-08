using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TestNhaccuatuiAPI
{
    public class Singer
    {
        private string name;
        private string link;
        private string avatarLink;

        public string AuthorName { get => name; set => name = value; }
        public string AuthorLink { get => link; set => link = value; }
        public string AuthorAvatarLink { get => avatarLink; set => avatarLink = value; }

        public Singer(string _name, string _link, string _avatar)
        {
            name = _name;
            link = _link;
            avatarLink = _avatar;
        }
    }
}
