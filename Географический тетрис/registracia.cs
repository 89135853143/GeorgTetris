﻿using System;
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
    public partial class registracia : Form
    {
        bool f=false;
        bool n = false;
        bool p = false;
        bool s = false;
        public registracia()
        {
            InitializeComponent();

        }
        public List<TextBox> list = new List<TextBox>();

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)//для проверки того, чтоб поля были заполнены
            {
                if (control as TextBox != null)
                    if ((control as TextBox).Text == "" || f==false || n == false || p == false || s == false)
                    {
                        MessageBox.Show("Поля заполнены неверно");
                        return;
                    }
            }
            string dannie;
            dannie = Fam.Text + " " + Names.Text + " " + Patron.Text + " " + School.Text + " " + Pass.Text + "\r\n";
            File.AppendAllText("baza.txt", dannie);

            Form m = new Start_dlia_ychitelia();
            Hide();
            m.ShowDialog();
            Show();
        }

        private void registracia_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
            if(r==true)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
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

        private void School_TextChanged(object sender, EventArgs e)
        {
            string A = School.Text;
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
                s = false;
            }
            else
            {
                label6.Text = "";
                s = true;
            }
        }
    }
}
