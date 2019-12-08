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
    public partial class игра : Form
    {
        public игра()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form r = new nastroiki();//создание экземпляра формы настройки
            Hide();//скрыть форму которая есть
            r.ShowDialog();//чтобы отобразить следующую форму
            Show();//для отображения формы
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form u = new start();
            Hide();
            u.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form o = new pomosh();
            Hide();
            o.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form y = new rekord();
            Hide();
            y.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
