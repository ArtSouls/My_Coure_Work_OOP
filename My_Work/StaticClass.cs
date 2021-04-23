using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Work
{
    public class StaticClass
    {
        public class Street_Class
        {
            public string[] Array = new string[10];
            public Street_Class()
            {
                Array[0] = "Красная, ";
                Array[1] = "Красноармейская, ";
                Array[2] = "Октябрьская, ";
                Array[3] = "Калинина, ";
                Array[4] = "Гоголя, ";
                Array[5] = "Седина, ";
                Array[6] = "Северная, ";
                Array[7] = "Школьная, ";
                Array[8] = "Ленина, ";
                Array[9] = "Базовская, ";
            }
        }
        public static List<Realty> Based = new List<Realty>();//база объектов недвижимости 
        public static Form1 f1;
        public static Form5 f5;
        public static bool Filter;
        public static bool TYPE;
        public static bool Agree;
        public static Street_Class street = new Street_Class();
        public static Random rand = new Random();
    }
}
