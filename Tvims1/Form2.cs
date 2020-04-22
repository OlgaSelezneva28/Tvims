using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Tvims1
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            dataGridView2.RowCount = dataGridView1.RowCount;
            dataGridView2.ColumnCount = 3;

            for (int i = 0; i < 3; i++)
            {
                dataGridView2.Rows[0].Cells[i].Style.BackColor = System.Drawing.Color.DarkCyan;

            }
            dataGridView2.Rows[0].Cells[0].Value = "yi";
            dataGridView2.Rows[0].Cells[1].Value = "P({η = yj})";
            dataGridView2.Rows[0].Cells[2].Value = "ni/n";

            /*
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView2.Rows[i + 1].Cells[0].Value = dataGridView1.Rows[i + 1].Cells[0];
                //dataGridView2.Rows[i + 1].Cells[1].Value = r.Y;
                dataGridView2.Rows[i + 1].Cells[2].Value = dataGridView1.Rows[i + 1].Cells[2];
            }
              */
        }

        /*
        public void Graphic(double x, double y)
        {
            chart1.Series[0].Points.AddXY(x, y);
        }
         */

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

    }
}
