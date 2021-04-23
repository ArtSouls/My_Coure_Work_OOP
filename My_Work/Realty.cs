using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace My_Work
{
    abstract public class Realty
    {
        protected string Adres;
        protected int Number;
        protected double S_Obj;
        protected int Room;
        protected bool Type;
        protected double Coast;
        public Realty(string Adres,int Number, double S_Obj, int Room, bool Type, double Coast)
            {
                Realty realty = this;
                realty.Adres = Adres;
                realty.Number = Number;
                realty.S_Obj = S_Obj;
                realty.Room = Room;
                realty.Type = Type;
                realty.Coast = Coast;
            }
        public Realty()
        {
            Realty realty = this;
            int r_value = StaticClass.rand.Next(0, 10);
            realty.Adres = StaticClass.street.Array[r_value];
            realty.Number = StaticClass.rand.Next(1, 150);
            realty.Room = StaticClass.rand.Next(1, 7);
            realty.S_Obj = StaticClass.rand.Next(realty.Room*16, realty.Room*30);
            realty.Type = StaticClass.TYPE;//здесь можно прописать рандомные типы недвижимости
            realty.Coast = StaticClass.rand.Next(6000,14000)*realty.Room;

        }
        public int GetNumber()
        {
            return Number;
        }
        public string GetAdres()
        {
            return Adres;
        }
        public double GetS_Obj()
        {
            return S_Obj;
        }
        public int GetRoom()
        {
            return Room;
        }
        public bool GetType()
        {
            return Type;
        }
        public double GetCoast()
        {
            return Coast;
        }

    }

}
