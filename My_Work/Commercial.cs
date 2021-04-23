using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Work
{
    class Commercial:Realty
    {
        //комерческая == 1 , жилая == 0
        public Commercial(string Adres, int Number, double S_Obj, int Room, double Coast) : base(Adres, Number, S_Obj, Room, true, Coast) { }
        public Commercial() : base() { Type = true; Coast = Math.Round(Coast* 1.5); }

    }
}
