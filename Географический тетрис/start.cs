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
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form w = new yr1();
            Hide();
            w.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form t = new yr2();
            Hide();
            t.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form q = new yr3();
            Hide();
            q.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form s = new yr4();
            Hide();
            s.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
