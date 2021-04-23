using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Work
{
    public class Filter
    {
        public int Min_Size;
        public int Max_Size;
        public int Min_Coast;
        public int Max_Coast;
        public List<bool> Type;
        public List<int> Room;
        public Filter(int Min_Size, int Max_Size, int Min_Coast, int Max_Coast)
        {
            Filter fil = this;
            fil.Max_Size = Max_Size;
            fil.Min_Size = Min_Size;
            fil.Min_Coast = Min_Coast;
            fil.Max_Coast = Max_Coast;
            Type = new List<bool>();
            Room = new List<int>();
        }
    }
}
