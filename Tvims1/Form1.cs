using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tvims1
{

    public partial class Form1 : Form
    {
        int N;//Количество экспериментов 
        double P; // Вероятность 

        Form2 f2 = new Form2();
        List<Point> U = new List<Point>();
        

        public Form1()
        {
            InitializeComponent();
        }

        //
        Point fun(int i, Random rnd)
        {
            Point rez = new Point();
            double u;

            u = rnd.NextDouble() ;

            double sump;
            double p0 = 1.0 - P; //Самая первая вероятность 
            
            int nn = 0; // Для подсчета количества ответов
            sump = p0; 

            double ppred = p0; // Вероятность предыдущего ответа 
            
            if (u < sump)
            {
                rez.X = 0; // Ответил на 0 вопросов 
                rez.Y = 1; // Сколько раз ответили 
  
                return rez;
            }
            while (u > sump) // Пока этта не принадлежин какому-то отрезку
            {
                double pnew = P * ppred;
                ppred = pnew;
                sump += ppred;

                nn++; // 
            }
            
            rez.X = nn; // Сколько ответов было получено 
            rez.Y = 1; // сколько раз встретился этот ответ 
            return rez;
            
        }

        // Для сортировки списка точек 
        void bubbleSort(List<Point> arr)
        {
            Point tmp;

            for (int i = 0; i < arr.Count - 1; ++i) 
            {
                for (int j = 0; j < arr.Count - 1; ++j) 
                {
                    if (arr.ElementAt(j + 1).X < arr.ElementAt(j).X)
                    {
                        tmp = arr.ElementAt(j + 1);
                        arr.RemoveAt(j + 1);
                        arr.Insert(j + 1, arr.ElementAt(j));
                        arr.RemoveAt(j);
                        arr.Insert(j, tmp);
                    }
                }
            }
        }

        /*-----------------------1---------------------------------*/
        private void button1_Click(object sender, EventArgs e)
        {
            N = int.Parse(textBox1.Text);
            P = double.Parse(textBox2.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            Random rnd = new Random(1);

            if (P == 1)
            {
                MessageBox.Show("All 0");
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                return;
            }
            if (P > 1)
            {
                MessageBox.Show("Incorrect");
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                return;
            }

            
            List<Point> Unic;
            Unic = new List<Point>(); // Список точек, где X - количество ответов, Y - сколько раз был получен данный ответ 

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            Point result = new Point();

            for (int i = 1; i <= N; i++)
            {
                // Функция для получения ответов
                result = fun(i, rnd);

                if (Unic.Count == 0)
                {
                    Unic.Add(result);
                }
                else 
                {
                    bool flag = false;
                    for (int j = 0; (j < Unic.Count) && (flag == false); j++)
                    {
                        if (Unic.ElementAt(j).X == result.X) // Если такой ответ уже был
                       {
                           Point t = new Point();
                           t.X = Unic.ElementAt(j).X;
                           t.Y = Unic.ElementAt(j).Y + 1; // Увеличиваем количество такого ответа на 1 
                           Unic.RemoveAt(j);
                           Unic.Add(t); // Заносим новые значения 
                           
                          flag = true;
                      }
                    }
                    if (flag == false) // если такой ответ впервые встретился 
                    {
                        Unic.Add(result); // Заносим его в список 
                    }
                }
            }

            bubbleSort(Unic); // Сортируем список 
            U = Unic;

            dataGridView1.RowCount = Unic.Count + 1;
            dataGridView1.ColumnCount = 3;


            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Rows[0].Cells[i].Style.BackColor = System.Drawing.Color.DarkCyan;

            }
            dataGridView1.Rows[0].Cells[0].Value = "yi";
            dataGridView1.Rows[0].Cells[1].Value = "ni";
            dataGridView1.Rows[0].Cells[2].Value = "ni/N";


            for (int i = 0; i < Unic.Count; i++)
            {
                Point r = new Point();
                r = Unic.ElementAt(i);
                dataGridView1.Rows[i+1].Cells[0].Value = r.X;
                dataGridView1.Rows[i+1].Cells[1].Value = r.Y;
                dataGridView1.Rows[i+1].Cells[2].Value = r.Y /(double)N;
            }

            
            double p = 0.0;
            for (int i = 0; i < Unic.Count - 1; i++)
            {
                Point r = new Point();
                Point r2 = new Point();
                r = Unic.ElementAt(i);
                r2 = Unic.ElementAt(i + 1);
                p += r.Y / (double)N;

                double j = (double)r.X;
                while(j <= (double)r2.X)
                {
                    f2.chart1.Series[0].Points.AddXY(j, p);
                    j++;
                }
            }
        }

        public List<Point> ListPoint()
        {
            return U;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void характеристикиСлучайныхВеличинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2.Update();
            f2.Show();
        }


    }
}
