using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int w = 80, h = 80;
        int x = 1, y = 100;
        int dx = 5;
        enum STATUS { Main, Side };
        STATUS flag;

        SolidBrush brush = new SolidBrush(Color.Red); // кисть
        Rectangle rc; //прямоугольная область, в которой находится фигура


        // событие работы таймера с заданным интервалом
        private void timer1_Tick(object sender, EventArgs e)
        {
            rc = new Rectangle(x, y, w, h); // размер прямоугольной области
            this.Invalidate(rc, true); // вызываем прорисовку области
            if (flag == STATUS.Main) // движение влево
                x -= dx;
            if (flag == STATUS.Side) // движение вправо
                x += dx;
            if (x >= (this.ClientSize.Width - w)) // если достигли правогокрая формы
                flag = STATUS.Main; // меняем статус движения на левый
            else if (x >= 1) // если достигли левого края формы
                flag = STATUS.Side; // меняем статус движения на правый
            rc = new Rectangle(x, y, w, h); // новая прямоугольная область
            this.Invalidate(rc, true); // вызываем прорисовку этой области
        }
        private void Form1_Paint(object sender, PaintEventArgs e) // событиеперерисовки формы
        {
            e.Graphics.FillEllipse(brush, rc); // рисуем закрашенный эллипс
        }
    }
}
