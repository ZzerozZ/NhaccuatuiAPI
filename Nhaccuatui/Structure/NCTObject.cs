using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhaccuatui.Structure
{
    public class NCTObject
    {
        private string name;
        private string path;

        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }

        public NCTObject(string _name, string _path)
        {
            Name = _name;
            Path = _path;
        }
    }
}
