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
            Form s = new игра();//создание экземпляра формы настройки
            Hide();//скрыть форму которая есть
            s.ShowDialog();//чтобы отобразить следующую форму
            Show();//для отображения формы
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
    }
}
