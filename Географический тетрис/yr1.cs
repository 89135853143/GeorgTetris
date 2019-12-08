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
    public partial class yr1 : Form
    {
        Bitmap play1 = new Bitmap(Image.FromFile("Картинки\\Карта.jpg"), 700, 450);//добавила фон
        int x, y;
        int vusota, shirina;
        string puthUr = "Картинки\\level1";//путь к уровню картинок
        List<string> l1=new List<string>();//список картинок уровня
        int gen;//для индекса картинки
        Random random = new Random();//создала переменную для генерации случайных чисел
        int countP;//переменная для количества объектов, которые будут падать
        int gr;
        public yr1()
        {
            InitializeComponent();
            x = 10;
            y = 10;
            vusota = 300;
            shirina = 300;
            //button5.Focus();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
            UpdateStyles();//для плавности прорисовки
            countP = new DirectoryInfo("Картинки\\level1").GetFiles().Length;//количество картинок

            DirectoryInfo dir = new DirectoryInfo(puthUr);//считываю названия картинок
            foreach (var item in dir.GetFiles())
            {
                l1.Add(item.Name);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();//Таймер для обновления
            if (shirina > 50 && vusota > 50)
            {
                vusota = vusota - 5;//изменение размера картинок по высоте
                shirina = shirina - 5;//изменение размера картинок по ширине
            }
            else
            {
                gen = random.Next(0, countP);//новый индекс картинки
                vusota = 300;
                shirina = 300;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.D)//при нажатие на кнопку D двигается вправо 
            {
                //MessageBox.Show("");
                x = x + 10;
            }
            if(e.KeyCode==Keys.A)//при нажатии на кнопку A двигается влево
            {
                x = x - 10;
            }
            if (e.KeyCode == Keys.W)//при нажатии на кнопку W двигается вверх
            {
                y = y - 10;
            }
            if (e.KeyCode == Keys.S)//при нажатии на кнопку S двигается вниз
            {
                y = y + 10;
            }
            if (e.KeyCode == Keys.Q)//при нажатие на кнопку Q крутится 
            {
                gr = gr + 45;
            }
            if (e.KeyCode == Keys.E)//при нажатие на кнопку E крутится 
            {
                gr = gr - 45;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(play1, new Rectangle(0, 0, 700, 450));//загружаем фон
            Bitmap play2 = new Bitmap(Image.FromFile(puthUr+"\\"+l1[gen]), shirina, vusota);//добавила первый объект
            TextureBrush tb = new TextureBrush(play2, System.Drawing.Drawing2D.WrapMode.Clamp);//создаем текстурную кисть
            tb.TranslateTransform(vusota / 2, shirina / 2);//сдвиг объектов
            tb.RotateTransform(gr, System.Drawing.Drawing2D.MatrixOrder.Prepend);//поворот
            tb.TranslateTransform(-vusota / 2, -shirina / 2);//сдвиг объектов
            tb.TranslateTransform(x, y);//сдвиг объектов
            //g.FillRectangle(tb, 0, 0, pictureBox1.Width, pictureBox1.Height);
            Graphics g2 = Graphics.FromImage(play2);
            g2.FillRectangle(tb, 0, 0, vusota, shirina);
            Bitmap p1 = new Bitmap(shirina, vusota, g2);
            g.DrawImage(play2, new PointF(x, y));//загружаем объект который падает
        }
    }
}
