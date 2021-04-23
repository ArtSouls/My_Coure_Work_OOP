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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(textBox1.Text)> Convert.ToInt32(textBox2.Text))
                    throw new Exception();
                if (Convert.ToInt32(textBox8.Text) > Convert.ToInt32(textBox7.Text))
                    throw new Exception();
                Filter filter = new Filter(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox7.Text));
                if (checkBox1.Checked == true)
                    filter.Room.Add(1);
                if (checkBox2.Checked == true)
                    filter.Room.Add(2);
                if (checkBox3.Checked == true)
                    filter.Room.Add(3);
                if (checkBox4.Checked == true)
                    filter.Room.Add(4);
                if (checkBox5.Checked == true)
                    filter.Room.Add(5);
                if (checkBox6.Checked == true)
                    filter.Room.Add(6);
                if (checkBox7.Checked == true)
                    filter.Room.Add(7);
                if (checkBox8.Checked == true)
                    filter.Type.Add(false);
                if (checkBox9.Checked == true)
                    filter.Type.Add(true);
                Form5 f5 = new Form5(filter);
                f5.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода, введите заново");
            }
            
        }
    }
}
