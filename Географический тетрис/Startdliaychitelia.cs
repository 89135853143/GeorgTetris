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
    public partial class Start_dlia_ychitelia : Form
    {
        public Start_dlia_ychitelia()
        {
            InitializeComponent();
        }

        private void Start_dlia_ychitelia_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form z = new Registracia_ychenikov();
            Hide();
            z.ShowDialog();
            Show();
        }
    }
}
