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

namespace Географический_тетрис
{
    public partial class rekord : Form
    {
        List<Ycheniki> spisok = new List<Ycheniki>();
        public rekord()
        {
            InitializeComponent();
        }

        private void rekord_Load(object sender, EventArgs e)
        {
            string[] LogPas = System.IO.File.ReadAllLines("statistika.txt");//массив по строчкам 

            string nameGr = " ";
            nameGr = Convert.ToString(1);

            
            List<string> spisokFIO = new List<string>();
            for (int i = 0; i < LogPas.Length; i++)
            {
                
                string[] split = LogPas[i].Split(' ');//массив по словам
                label1.Text += split[4] + "\r\n";
                string fio = split[0] + " " + split[1] + " " + split[2];

                string[] vremia = split[4].Split(':');
                int sek = Convert.ToInt32(vremia[1]);
                int min = Convert.ToInt32(vremia[0]);
                int sekund = min * 60 + sek;
                if(spisokFIO.Contains(fio)==false)
                {
                    spisokFIO.Add(fio);
                    spisok.Add(new Ycheniki());//добавила нового участника
                    spisok[spisok.Count - 1].fio = fio;
                    spisok[spisok.Count-1].vremiasek.Add(sekund);
                }
                else
                {
                    for (int j = 0; j < spisok.Count; j++)
                    {
                        if (fio == spisok[j].fio)
                        {
                            spisok[j].vremiasek.Add(sekund);
                        }
                    }
                }
                

            }
            for (int j = 0; j < spisok.Count; j++)
            {
                comboBox1.Items.Add(spisok[j].fio);
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            string nameGr = comboBox1.Text;
            chart1.Series.Add(nameGr);
            for (int k=0; k < spisok.Count; k++)
            {
                if (spisok[k].fio == nameGr)
                    for (int i = 0; i < spisok[k].vremiasek.Count; i++)
                    {
                        chart1.ChartAreas[0].AxisX.Minimum = 0;
                        chart1.Series[nameGr].BorderWidth = 1;
                        chart1.Series[nameGr].Color = Color.Red;
                        chart1.Series[nameGr].ChartType = SeriesChartType.Spline;
                        chart1.Series[nameGr].Points.AddXY(i + 1, spisok[k].vremiasek[i]);
                    }
            }
        }
    }
}
