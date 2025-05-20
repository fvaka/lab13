using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab13
{
    public enum SHAPE_TYPE { Circle, Rhomb, Triangle }
    public enum DIAGONAL_TYPE { Main, Anti }

    public partial class Form1 : Form
    {
        private int size = 80;
        private int x = 1, y = 1;
        private int step = 5;
        private Color currentColor = Color.Red;
        private SHAPE_TYPE currentShape = SHAPE_TYPE.Circle;
        private DIAGONAL_TYPE diagonal = DIAGONAL_TYPE.Main;
        private SolidBrush brush;
        private Rectangle shapeRect;
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            brush = new SolidBrush(currentColor);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
        }

        // Свойства для настройки
        public int Speed
        {
            get => 100 - timer1.Interval;
            set => timer1.Interval = Math.Max(1, 100 - value);
        }

        public Color ShapeColor
        {
            get => currentColor;
            set
            {
                currentColor = value;
                brush.Color = value;
                Invalidate();
            }
        }

        public SHAPE_TYPE ShapeType
        {
            get => currentShape;
            set
            {
                currentShape = value;
                Invalidate();
            }
        }

        public DIAGONAL_TYPE DiagonalType
        {
            get => diagonal;
            set
            {
                diagonal = value;
                Invalidate();
            }
        }
        private void btn_Settings_Click(object sender, EventArgs e)
        {
            var settingsForm = new Form2();
            settingsForm.Owner = this;
            settingsForm.Show(); // Не модальное окно для мгновенного применения
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                btn_Stop.Text = "Старт";
            }
            else
            {
                timer1.Start();
                btn_Stop.Text = "Стоп";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Очистка предыдущей позиции
            Invalidate(shapeRect);

            // Движение по выбранной диагонали
            if (diagonal == DIAGONAL_TYPE.Main)
            {
                x += step;
                y += step;
            }
            else
            {
                x += step;
                y -= step;
            }

            // Проверка границ
            bool hitBorder = false;
            if (x >= ClientSize.Width - size || x <= 0)
            {
                step = -step;
                hitBorder = true;
            }
            if (y >= ClientSize.Height - size || y <= 0)
            {
                step = -step;
                hitBorder = true;
            }

            // Смена цвета при касании границы
            if (hitBorder)
            {
                brush.Color = Color.FromArgb(
                    rnd.Next(256),
                    rnd.Next(256),
                    rnd.Next(256));
            }

            // Обновление позиции
            shapeRect = new Rectangle(x, y, size, size);
            Invalidate(shapeRect);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            switch (currentShape)
            {
                case SHAPE_TYPE.Circle:
                    e.Graphics.FillEllipse(brush, shapeRect);
                    break;
                case SHAPE_TYPE.Rhomb:
                    Point[] rhombPoints = {
                        new Point(x + size/2, y),
                        new Point(x + size, y + size/2),
                        new Point(x + size/2, y + size),
                        new Point(x, y + size/2)
                    };
                    e.Graphics.FillPolygon(brush, rhombPoints);
                    break;
                case SHAPE_TYPE.Triangle:
                    Point[] trianglePoints = {
                        new Point(x + size/2, y),
                        new Point(x + size, y + size),
                        new Point(x, y + size)
                    };
                    e.Graphics.FillPolygon(brush, trianglePoints);
                    break;
            }
        }
    }
}
