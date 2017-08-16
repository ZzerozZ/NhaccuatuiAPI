using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhaccuatui
{
    public class Singer
    {
        private string name;
        private string path;
        private string avatarLink;

        public string AuthorName { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public string AvatarLink { get => avatarLink; set => avatarLink = value; }

        public Singer(string _name, string _link, string _avatar)
        {
            name = _name;
            path = _link;
            avatarLink = _avatar;
        }
    }
}
