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
    public partial class Form5 : Form
    {
        public Form5(Filter filter)
        {
            InitializeComponent();
            StaticClass.f5 = this;
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Адрес: ";
            dataGridView1.Columns[1].Name = "Общая площадь: ";
            dataGridView1.Columns[2].Name = "Количество комнат: ";
            dataGridView1.Columns[3].Name = "Тип недвижимости: ";
            dataGridView1.Columns[4].Name = "Стоимость: ";
            for (int i = 0; i < 5; i++)
                dataGridView1.Columns[i].Width = 93;
            dataGridView1.Columns[0].Width = 130;
            int k = 0;
            for (int i = 0; i < StaticClass.Based.Count; i++)
            {
                bool room=false;
                bool type = false;
                for (int j = 0; j < filter.Room.Count; j++)
                    if (StaticClass.Based[i].GetRoom() == filter.Room[j])
                        room = true;
                for (int j = 0; j < filter.Type.Count; j++)
                    if (StaticClass.Based[i].GetType() == filter.Type[j])
                        type = true;
                if (StaticClass.Based[i].GetS_Obj() > filter.Min_Size && StaticClass.Based[i].GetS_Obj() < filter.Max_Size && StaticClass.Based[i].GetCoast() > filter.Min_Coast && StaticClass.Based[i].GetCoast() < filter.Max_Coast && room == true && type == true)
                {
                    filtered.Add(StaticClass.Based[i]);
                }
            }
            if (filtered.Count == 0)
            { 
                MessageBox.Show("Ничего не найдено");
                //this.Close();
            }
            else
            {
                for (int i = 0; i < filtered.Count; i++)
                {
                    ++dataGridView1.RowCount;
                    dataGridView1.Rows[i].Cells[0].Value = filtered[i].GetAdres() + Convert.ToString(filtered[i].GetNumber());
                    dataGridView1.Rows[i].Cells[1].Value = filtered[i].GetS_Obj();
                    dataGridView1.Rows[i].Cells[2].Value = filtered[i].GetRoom();
                    if (filtered[i].GetType())
                        dataGridView1.Rows[i].Cells[3].Value = "Коммерчекая";
                    else
                        dataGridView1.Rows[i].Cells[3].Value = "Жилая";
                    dataGridView1.Rows[i].Cells[4].Value = filtered[i].GetCoast();
                }
            }
        }
        public int GetSelectedCells()
        {
            return dataGridView1.SelectedCells[0].RowIndex;
        }
        public static List<Realty> filtered = new List<Realty>();
        private void Form5_Load(object sender, EventArgs e)
        {

        }
        public void Rent_Object()
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
                int current = dataGridView1.SelectedCells[0].RowIndex;
                for (int j = 0; j < StaticClass.Based.Count; j++)
                {
                        if (StaticClass.Based[j] == filtered[current])
                        {
                            StaticClass.Based.RemoveAt(j);
                            StaticClass.f1.GetGrid().Rows.RemoveAt(j);
                            //StaticClass.f1.dataGridView1.Rows.RemoveAt(j);
                        }
                }
                dataGridView1.Rows.RemoveAt(current);

                //++dataGridView1.RowCount;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3(true);
            try
            {
                F3.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
