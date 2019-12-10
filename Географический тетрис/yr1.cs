using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Географический_тетрис
{
    public partial class yr1 : Form
    {
        Bitmap fon = new Bitmap(Image.FromFile("Картинки\\Карта.jpg"));//добавила фон
        Bitmap fon2;
        int rv;//переменная для размера фона высота
        int rs;//переменная для размера фона ширина
        int x, y;//переменная вниз и вверх для координаты объекта
        int vusota, shirina;//переменая высота и ширина
        string puthUr = "Картинки\\level1";//путь к уровню картинок
        List<string> l1=new List<string>();//список картинок уровня
        int gen=0;//для индекса картинки
        Random random = new Random();//создала переменную для генерации случайных чисел
        int countP;//переменная для количества объектов, которые будут падать
        int gr;//переменная градус для поворота
        int sdvig = 0;//переменная для сдвига
        int shagRaz = 4;//переменная для изменения размера
        float koef = 0.155f;//коэффициент
        int centrx;//центр координаты по Х, куда должен падать объект
        int centry;//центр координаты по У, куда должен падать объект
        int vo = 0;//высота объекта
        int so = 0;//ширина объекта
        int sdvigPokarteX = 100;//сдвиг по карте по Х
        int sdvigPokarteY = 100;//сдвиг по карте по У
        int kolkartinok=0;//текущее кол-во картинок, которое упало на карту
        int obsheekol = 0;//общее кол-во картинок
        int sek=0;//переменная секунд
        int min=0;//переменная минут
        int xsdvig = 0;
        int ysdvig = 0;
        Graphics g3;
        public yr1()
        {
            InitializeComponent();
            x = 10;
            y = 10;
            vusota = 300;
            shirina = 300;
            rv = fon.Height;
            rs = fon.Width;
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
            obsheekol = l1.Count;
            label1.Text = kolkartinok + "/" + obsheekol;
            string[] LogPas = System.IO.File.ReadAllLines("Картинки\\level1.txt");//массив по строчкам в базе
            for(int i=0; i<LogPas.Length; i++)
            {

                string[] split = LogPas[i].Split(' ');//массив по словам
                if (split[0] == l1[gen])
                {
                    centrx = Convert.ToInt32(Convert.ToInt32(split[1]) * koef);
                    centry = Convert.ToInt32(Convert.ToInt32(split[2]) * koef);
                    Text = centrx + " " + centry;
                }
            }
            fon2 = new Bitmap(fon, Convert.ToInt32(rs * koef), Convert.ToInt32(rv * koef));//добавила фон c koef
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
        int xt;
        int yt;
        private void timer1_Tick(object sender, EventArgs e)
        {

             xt = x + sdvig + so / 2;
             yt = y + sdvig + vo / 2;
            //Text = xt + " " + yt + " " + centrx + " " + centry;
            Refresh();//Таймер для обновления
            if (shirina > 0 && vusota > 0)//происходит уменьшение объекта
            {
                vusota = vusota - shagRaz;//изменение размера картинок по высоте
                shirina = shirina - shagRaz;//изменение размера картинок по ширине
                sdvig += shagRaz/2;//сдвиг в центр
            }
            else
            {

                if (centrx >= xt-20 && centry >= yt-20 && centrx <= xt + 20 && centry <= yt + 20)
                {
                    l1.RemoveAt(gen);//удаляем картинку, которую правильно поставили
                    kolkartinok++;
                    label1.Text = kolkartinok + "/" + obsheekol;
                    countP = l1.Count;//пересчитываем количество картинок
                    if (countP == 0)
                    {
                        timer1.Stop();
                        timer2.Stop();
                        string dannie = Dannue.dan + " "+ label1.Text + " " + label2.Text + "\r\n";
                        File.AppendAllText("statistika.txt", dannie);
                        MessageBox.Show("Молодец");
                    }
                    
                    if (l1.Count != 0)
                    {
                        gen = random.Next(0, countP);//новый индекс картинки
                        string[] LogPas = System.IO.File.ReadAllLines("Картинки\\level1.txt");//массив по строчкам в базе

                       
                        //Graphics g2 = Graphics.FromImage(fon2);//формирование графики для поворота
                        //pictureBox3.Image = fon2;//привязка графики к полю для рисования
                        fon2 = new Bitmap(pictureBox4.Image);//создание программы той картинки

                        for (int i = 0; i < LogPas.Length; i++)
                        {
                            string[] split = LogPas[i].Split(' ');//массив по словам
                            if (split[0] == l1[gen])
                            {
                                centrx = Convert.ToInt32(Convert.ToInt32(split[1]) * koef);
                                centry = Convert.ToInt32(Convert.ToInt32(split[2]) * koef);
                                Text = centrx + " " + centry;
                            }
                        }
                    }
                }
               
                vusota = 300;
                shirina = 300;
                sdvig = 0;
                x = Convert.ToInt32((rs/2)*koef)-shirina;//генерация в центре экрана
                y = Convert.ToInt32((rv / 2) * koef)-vusota;//генерация в центре экрана
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void yr1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            int shagg = 20;
            if (e.KeyCode == Keys.D)//при нажатие на кнопку D двигается вправо 
            {
                //MessageBox.Show("");
                x = x + shagg;
            }
            if(e.KeyCode==Keys.A)//при нажатии на кнопку A двигается влево
            {
                x = x - shagg;
            }
            if (e.KeyCode == Keys.W)//при нажатии на кнопку W двигается вверх
            {
                y = y - shagg;
            }
            if (e.KeyCode == Keys.S)//при нажатии на кнопку S двигается вниз
            {
                y = y + shagg;
            }
            if (e.KeyCode == Keys.Q)//при нажатие на кнопку Q крутится против часовой
            {
                gr = gr + 45;
            }
            if (e.KeyCode == Keys.E)//при нажатие на кнопку E крутится по часовой
            {
                gr = gr - 45;
            }
           
         //   Text = centrx+" "+centry + " "+t+" " + t2;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sek++;
            
            if(sek==60)
            {
                min++;
                sek = 0;
            }
            label2.Text = min.ToString() + ":" + sek.ToString();
        }

        string s = "";
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (l1.Count > 0)
            {
                s = l1[gen];
            }

                Graphics g = e.Graphics;             
                g.DrawImage(fon2, new Rectangle(0, 0, Convert.ToInt32(rs * koef), Convert.ToInt32(rv * koef)));//рисуем картинку на 

                Bitmap play1 = new Bitmap(Image.FromFile(puthUr + "\\" + s));//добавила объекты
                vo = Convert.ToInt32(play1.Height * koef) + vusota;
                so = Convert.ToInt32(play1.Width * koef) + shirina;


                Bitmap play2 = new Bitmap(Image.FromFile(puthUr + "\\" + l1[gen]), so, vo);//добавила объекты

                int sdvigvr = 0;
                if (so > vo)
                {
                    sdvigvr = so;
                }
                else
                {
                    sdvigvr = vo;
                }

                TextureBrush tb = new TextureBrush(play2, System.Drawing.Drawing2D.WrapMode.Clamp);//создаем текстурную кисть

                tb.TranslateTransform(so / 2, vo / 2);//сдвиг объектов
                tb.RotateTransform(gr, System.Drawing.Drawing2D.MatrixOrder.Prepend);//поворот
                tb.TranslateTransform(-so / 2, -vo / 2);//сдвиг объектов

                Bitmap p3 = new Bitmap(sdvigvr, sdvigvr);//картинка для осуществления поворота
                Graphics g2 = Graphics.FromImage(p3);//формирование графики для поворота
                pictureBox3.Image = p3;//привязка графики к полю для рисования
                Bitmap r = new Bitmap(fon2);

                pictureBox4.Image = r;

                g3 = Graphics.FromImage(r);//формирование графики для поворота

                g2.FillRectangle(tb, 0, 0, sdvigvr, sdvigvr);//прорисовка поворота
                Bitmap p1 = new Bitmap(pictureBox3.Image);//создание программы той картинки
            if (centrx >= xt - 20 && centry >= yt - 20 && centrx <= xt + 20 && centry <= yt + 20)
            {
                g.DrawImage(p1, new PointF(centrx - so/2, centry - vo/2));//загружаем объект который падает

                g3.DrawImage(p1, new PointF(centrx - so / 2, centry - vo / 2));
            }
            else
            {
                g.DrawImage(p1, new PointF(x + sdvig, y + sdvig));//загружаем объект который падает

                g3.DrawImage(p1, new PointF(x + sdvig, y + sdvig));
            }

        }
    }
}
