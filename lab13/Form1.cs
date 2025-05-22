using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab13
{
    public enum SHAPE_TYPE { Circle, Rhomb, Triangle }
    public enum DIAGONAL_TYPE { Main, Anti }

    public partial class Form1 : Form
    {
        //public enum SHAPE_TYPE { Circle, Rhomb, Triangle }
        //public enum DIAGONAL_TYPE { Main, Anti }
        private int size = 80;
        private int x = 1, y = 1;
        private int dx = 5, dy = 5;
        //public int dx = 5;
        bool isMoving = true;
        private Color currentColor = Color.Red;
        private SHAPE_TYPE currentShape = SHAPE_TYPE.Circle;
        private DIAGONAL_TYPE diagonal = DIAGONAL_TYPE.Main;
        private SolidBrush brush;
        private RectangleF shapeRect = new RectangleF(100f, 100f, 50f, 50f);
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            brush = new SolidBrush(currentColor);
            this.KeyPreview = true;
            timer1.Interval = 100;
            timer1.Start();
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

            var settingsForm = new Form2(this);
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
            MoveShape();
            Invalidate();
        }
        private void DrawShape(Graphics g)
        {
            Brush brush = new SolidBrush(currentColor);
            switch (currentShape)
            {
                case SHAPE_TYPE.Circle:
                    g.FillEllipse(brush, shapeRect);
                    break;
                case SHAPE_TYPE.Rhomb:
                    Point[] rhombPoints =
                    {
                        new Point((int)(shapeRect.Left + shapeRect.Width / 2), (int)shapeRect.Top),
                        new Point((int)shapeRect.Right, (int)(shapeRect.Top + shapeRect.Height / 2)),
                        new Point((int)(shapeRect.Left + shapeRect.Width / 2), (int)shapeRect.Bottom),
                        new Point((int)shapeRect.Left, (int)(shapeRect.Top + shapeRect.Height / 2))
                    };
                    g.FillPolygon(brush, rhombPoints);
                    break;
                case SHAPE_TYPE.Triangle:
                    Point[] trianglePoints =
                    {
                        new Point((int)(shapeRect.Left + shapeRect.Width / 2), (int)shapeRect.Top),
                        new Point((int)shapeRect.Right, (int)shapeRect.Bottom),
                        new Point((int)shapeRect.Left, (int)shapeRect.Bottom)
                    };
                    g.FillPolygon(brush, trianglePoints);
                    break;
            }
        }
        private void ChangeShapeColor()
        {
            Random rnd = new Random();
            currentColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
        private void MoveShape()
        {
            float x = shapeRect.X + dx;
            float y = shapeRect.Y + dy;

            // Проверка столкновения с границами окна
            if ((x <= 0 || x >= ClientSize.Width - shapeRect.Width))
            {
                dx *= -1;          // Меняем направление горизонтально
                ChangeShapeColor(); // Изменяем цвет фигуры
            }
            if ((y <= 0 || y >= ClientSize.Height - shapeRect.Height))
            {
                dy *= -1;           // Меняем направление вертикально
                ChangeShapeColor(); // Изменяем цвет фигуры
            }

            shapeRect.Location = new Point((int)x, (int)y);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
           base.OnPaint(e);
            DrawShape(e.Graphics);
        }

    }
}
