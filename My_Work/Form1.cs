using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace My_Work
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            StaticClass.f1 = this;
            InitializeComponent();
        }
        public int GetSelectedCells()
        {
            return dataGridView1.SelectedCells[0].RowIndex;
        }
        public DataGridView GetGrid()
        {
            return dataGridView1;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;//заполнение заголовков таблицы
            dataGridView1.Columns[0].Name = "Адрес: ";
            dataGridView1.Columns[1].Name = "Общая площадь: ";
            dataGridView1.Columns[2].Name = "Количество комнат: ";
            dataGridView1.Columns[3].Name = "Тип недвижимости: ";
            dataGridView1.Columns[4].Name = "Стоимость: ";
            for (int i = 0; i < 5; i++)
                dataGridView1.Columns[i].Width = 93;
            dataGridView1.Columns[0].Width = 130;
            dataGridView1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//снять объект недвижимости
        {
            Form3 F3 = new Form3(false);
            try
            {
                F3.Show();
            }
            catch (Exception)
            {

            }
            
        }
        private void button1_Click(object sender, EventArgs e)//выставить объявление
        {
            Form2 F2 = new Form2();
            F2.Show();
        }

        private void button3_Click(object sender, EventArgs e)//фильтр
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button4_Click(object sender, EventArgs e)//housing click
        {
            dataGridView1.Visible = button1.Visible = button2.Visible = button3.Visible = true;
            label1.Visible = button4.Visible = button5.Visible = false;
            //Static
            StaticClass.TYPE = false;
            for (int i = 0; i < 10; i++)
            {
                StaticClass.Based.Add(new Housing());
                StaticClass.f1.Add_To();
            }
        }

        private void button5_Click(object sender, EventArgs e)//Commercial click
        {
            dataGridView1.Visible = button1.Visible = button2.Visible = button3.Visible = true;
            label1.Visible = button4.Visible = button5.Visible = false;
            StaticClass.TYPE = true;
            for (int i = 0; i < 10; i++)
            {
                StaticClass.Based.Add(new Commercial());
                StaticClass.f1.Add_To();
            }
        }
        public void Add_To()//функция добавления в таблицу
        {
            Random rand = new Random();
            ++dataGridView1.RowCount;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = StaticClass.Based[i].GetAdres() + Convert.ToString(StaticClass.Based[i].GetNumber());
                dataGridView1.Rows[i].Cells[1].Value = StaticClass.Based[i].GetS_Obj();
                dataGridView1.Rows[i].Cells[2].Value = StaticClass.Based[i].GetRoom();
                if (StaticClass.Based[i].GetType())
                    dataGridView1.Rows[i].Cells[3].Value = "Коммерчекая";
                else
                    dataGridView1.Rows[i].Cells[3].Value = "Жилая";
                dataGridView1.Rows[i].Cells[4].Value = StaticClass.Based[i].GetCoast();
            }
        }
        public void Rent_Object()//функция удаления объекта и записи чека
        {
            if (StaticClass.Agree)
            {
                FileStream fs = new FileStream(@"D:\Check.txt", FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fs);
                try
                {
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        for (int i = 0; i < dataGridView1.Rows[j].Cells.Count; i++)
                        {
                            if (j == dataGridView1.SelectedCells[0].RowIndex)
                            {
                                streamWriter.Write(dataGridView1.Columns[i].Name + ":       ");
                                streamWriter.Write(dataGridView1.Rows[j].Cells[i].Value + "\n");
                            }
                        }
                    }
                    StaticClass.Agree = false;
                    streamWriter.Close();
                    fs.Close();
                    MessageBox.Show("Чек успешно сохранен");
                }
                catch
                {
                    MessageBox.Show("Ошибка при сохранении файла!");
                }

                StaticClass.Based.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
            }

        }
    }
    
}
