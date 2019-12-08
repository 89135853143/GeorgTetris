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

namespace Географический_тетрис
{
    public partial class Registracia_ychenikov : Form
    {
        bool f = false;
        bool n = false;
        bool p = false;
        bool k = false;
        public Registracia_ychenikov()
        {
            InitializeComponent();
        }
        public List<TextBox> list = new List<TextBox>();

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)//для проверки того, чтоб поля были заполнены
            {
                if (control as TextBox != null)
                    if ((control as TextBox).Text == "" || f == false || n == false || p == false || k == false)
                    {
                        MessageBox.Show("Поля заполнены неверно");
                        return;
                    }
            }
            string dannie;
            dannie = Fam.Text + " " + Names.Text + " " + Patron.Text + " " + Klass.Text + "\r\n";
            File.AppendAllText("bazaycheniki.txt", dannie);

            Form z = new Start_dlia_ychitelia();
            Hide();
            z.ShowDialog();
            Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void School_TextChanged(object sender, EventArgs e)
        {
            string A = Klass.Text;
            bool r = false;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < '0' || A[i] > '9')
                {
                    r = true;

                }
            }
            if (r == true)
            {
                label6.Text = "В строке Школа есть буквы";
                k = false;
            }
            else
            {
                label6.Text = "";
                k = true;
            }
        }

        private void Fam_TextChanged(object sender, EventArgs e)
        {
            string A = Fam.Text;
            bool r = false;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] >= '0' && A[i] <= '9')
                {
                    r = true;

                }
            }
            if (r == true)
            {
                label6.Text = "В строке есть цифры";
                f = false;
            }
            else
            {
                label6.Text = "";
                f = true;
            }
        }

        private void Patron_TextChanged(object sender, EventArgs e)
        {
            string A = Patron.Text;
            bool r = false;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] >= '0' && A[i] <= '9')
                {
                    r = true;

                }
            }
            if (r == true)
            {
                label6.Text = "В строке есть цифры";
                p = false;
            }
            else
            {
                label6.Text = "";
                p = true;
            }
        }

        private void Names_TextChanged(object sender, EventArgs e)
        {
            string A = Names.Text;
            bool r = false;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] >= '0' && A[i] <= '9')
                {
                    r = true;

                }
            }
            if (r == true)
            {
                label6.Text = "В строке есть цифры";
                n = false;
            }
            else
            {
                label6.Text = "";
                n = true;
            }
        }
    }
}
