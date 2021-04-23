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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Адрес: ";
            dataGridView1.Columns[1].Name = "Общая площадь: ";
            dataGridView1.Columns[2].Name = "Количество комнат:";
            dataGridView1.Columns[3].Name = "Тип недвижимости: ";
            dataGridView1.Columns[4].Name = "Стоимость: ";
            dataGridView1.RowCount = 1;
            for (int i = 0; i < 5; i++)
                dataGridView1.Columns[i].Width = 100;
                dataGridView1.Rows[0].Height = 30;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(dataGridView1.Rows[0].Cells[3].Value) == "Комерческая")
                    StaticClass.Based.Add(new Commercial(Convert.ToString(dataGridView1.Rows[0].Cells[0].Value), StaticClass.rand.Next(1, 150), Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value), Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[0].Cells[4].Value)));
                else
                    if (Convert.ToString(dataGridView1.Rows[0].Cells[3].Value) == "Жилая")
                        StaticClass.Based.Add(new Housing(Convert.ToString(dataGridView1.Rows[0].Cells[0].Value), StaticClass.rand.Next(1, 150), Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value), Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[0].Cells[4].Value)));
                else
                {
                    throw new Exception();
                }
                StaticClass.f1.Add_To();
                MessageBox.Show("Объект добавлен.");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода, ведите заново");
            }
            
        }
    }
}
