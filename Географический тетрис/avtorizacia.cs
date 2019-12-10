using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Географический_тетрис
{
    public partial class avtorizacia : Form
    {
        public avtorizacia()
        {
            InitializeComponent();
        }

        private void avtorizacia_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                string[] LogPas = System.IO.File.ReadAllLines("bazaycheniki.txt");//массив по строчкам в базе
                for(int i=0; i< LogPas.Length;i++)
                {
                    string[] split = LogPas[i].Split(' ');//массив по словам
                    if (textBox2.Text==split[0] + " " + split[1] + " " + split[2])
                    {
                        Dannue.dan = textBox2.Text;

                        Form s = new игра();//создание экземпляра формы настройки
                        Hide();//скрыть форму которая есть
                        s.ShowDialog();//чтобы отобразить следующую форму
                        Close();//для отображения формы
                        break;
                    }
                }
                
            }
            else
            {
                string[] LogPas = System.IO.File.ReadAllLines("baza.txt");//массив по строчкам в базе
                for (int i = 0; i < LogPas.Length; i++)
                {
                    string[] split = LogPas[i].Split(' ');//массив по словам
                    if (textBox2.Text == split[4])
                    {
                        Form p = new Start_dlia_ychitelia();
                        Hide();
                        p.ShowDialog();
                        Show();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form l = new registracia();
            Hide();
            l.ShowDialog();
            Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //выбираем кем войти
            if (radioButton1.Checked == true)
            {
                label2.Text = "Пароль";
                button2.Visible = true;
            }
            if (radioButton2.Checked == true)
            {
                label2.Text = "ФИО";
                button2.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
