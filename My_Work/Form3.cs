using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Work
{
    public partial class Form3 : Form
    {
        public Form3(bool filter)
        {
            InitializeComponent();
            try
            {
                int ind;
                if (filter)
                {

                    ind = StaticClass.f5.GetSelectedCells();
                    label6.Text = Convert.ToString(Form5.filtered[ind].GetAdres()) + Convert.ToString(Form5.filtered[ind].GetNumber());
                    label7.Text = Convert.ToString(Form5.filtered[ind].GetS_Obj());
                    label8.Text = Convert.ToString(Form5.filtered[ind].GetRoom());
                    if (Form5.filtered[ind].GetType())
                        label9.Text = "Комерческая";
                    else
                        label9.Text = "Жилая";
                    //label9.Text = Convert.ToString(StaticClass.Based[ind].GetType());
                    label10.Text = Convert.ToString(Form5.filtered[ind].GetCoast());
                }
                else
                {
                    ind = StaticClass.f1.GetSelectedCells();
                    label6.Text = Convert.ToString(StaticClass.Based[ind].GetAdres()) + Convert.ToString(StaticClass.Based[ind].GetNumber());
                    label7.Text = Convert.ToString(StaticClass.Based[ind].GetS_Obj());
                    label8.Text = Convert.ToString(StaticClass.Based[ind].GetRoom());
                    if (StaticClass.Based[ind].GetType())
                        label9.Text = "Комерческая";
                    else
                        label9.Text = "Жилая";
                    //label9.Text = Convert.ToString(StaticClass.Based[ind].GetType());
                    label10.Text = Convert.ToString(StaticClass.Based[ind].GetCoast());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка, выберите объект недвижимости в таблице");
                this.Close();
            }
            StaticClass.Filter = filter;
        }
       
        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaticClass.Agree = true;
            if(StaticClass.Filter==true)
                StaticClass.f5.Rent_Object();
            else
                StaticClass.f1.Rent_Object();
            //можно прописать открытие созданного файла
            this.Close();

        }
    }
}
