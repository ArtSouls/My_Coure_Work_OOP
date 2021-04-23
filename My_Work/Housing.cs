using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Work
{
    class Housing:Realty
    {
        //комерческая == 1 , жилая == 0
        public Housing(string Adres, int Number, double S_Obj, int Room, double Coast) : base(Adres, Number, S_Obj, Room, false, Coast) { }
        public Housing() : base() { base.Type = false; }
    }
}
