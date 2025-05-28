using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab13
{
    public enum SHAPE_TYPE { Circle, Rhomb, Triangle }
    public enum DIAGONAL_TYPE { Main, Anti }

    public partial class Form1 : Form
    {
        private const int SHAPE_SIZE = 40;
        private PointF position;
        private Color forwardColor = Color.Red;
        private Color backwardColor = Color.Blue;
        private SHAPE_TYPE currentShape = SHAPE_TYPE.Circle;
        private DIAGONAL_TYPE currentDiagonal = DIAGONAL_TYPE.Main;
        private SolidBrush brush;
        private int speed = 50;
        private bool isMovingForward = true;

        public Form1()
        {
            InitializeComponent();
            position = new PointF(10, 50);
            brush = new SolidBrush(forwardColor);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            timer1.Interval = 50;
            timer1.Start();
        }

        public int Speed
        {
            get => speed;
            set => timer1.Interval = Math.Max(1, 100 - value);
        }

        private void MoveShape()
        {
            float step = 2.5f * (speed / 50f); // Масштабируем шаг в зависимости от скорости

            if (isMovingForward)
            {
                // Движение вперед (вправо-вниз)
                if (currentDiagonal == DIAGONAL_TYPE.Main)
                {
                    position.X += step;
                    position.Y += step;
                }
                else // Побочная диагональ
                {
                    position.X += step;
                    position.Y -= step;
                }
            }
            else
            {
                // Движение назад (влево-вверх)
                if (currentDiagonal == DIAGONAL_TYPE.Main)
                {
                    position.X -= step;
                    position.Y -= step;
                }
                else // Побочная диагональ
                {
                    position.X -= step;
                    position.Y += step;
                }
            }

            // Проверка достижения границ формы
            bool hitBoundary = false;

            if (currentDiagonal == DIAGONAL_TYPE.Main)
            {
                if (position.X >= ClientSize.Width - 20 - SHAPE_SIZE || position.Y >= ClientSize.Height - 20 - SHAPE_SIZE ||
                    position.X <= 0 || position.Y <= 0)
                {
                    hitBoundary = true;
                }
            }
            else
            {
                if (position.X >= ClientSize.Width - 20 - SHAPE_SIZE || position.Y <= 0 ||
                    position.X <= 0 || position.Y >= ClientSize.Height - 20 - SHAPE_SIZE)
                {
                    hitBoundary = true;
                }
            }

            if (hitBoundary)
            {
                isMovingForward = !isMovingForward;
                brush.Color = isMovingForward ? forwardColor : backwardColor;

                // Корректировка позиции, чтобы фигура не выходила за границы
                position.X = Math.Max(0, Math.Min(position.X, ClientSize.Width - SHAPE_SIZE));
                position.Y = Math.Max(0, Math.Min(position.Y, ClientSize.Height - SHAPE_SIZE));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var shapeRect = new RectangleF(position.X, position.Y, SHAPE_SIZE, SHAPE_SIZE);

            switch (currentShape)
            {
                case SHAPE_TYPE.Circle:
                    e.Graphics.FillEllipse(brush, shapeRect);
                    break;
                case SHAPE_TYPE.Rhomb:
                    PointF[] rhombPoints = {
                        new PointF(shapeRect.X + shapeRect.Width / 2, shapeRect.Y),
                        new PointF(shapeRect.Right, shapeRect.Y + shapeRect.Height / 2),
                        new PointF(shapeRect.X + shapeRect.Width / 2, shapeRect.Bottom),
                        new PointF(shapeRect.X, shapeRect.Y + shapeRect.Height / 2)
                    };
                    e.Graphics.FillPolygon(brush, rhombPoints);
                    break;
                case SHAPE_TYPE.Triangle:
                    PointF[] trianglePoints = {
                        new PointF(shapeRect.X + shapeRect.Width / 2, shapeRect.Y),
                        new PointF(shapeRect.Right, shapeRect.Bottom),
                        new PointF(shapeRect.X, shapeRect.Bottom)
                    };
                    e.Graphics.FillPolygon(brush, trianglePoints);
                    break;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        public Color ForwardColor
        {
            get => forwardColor;
            set
            {
                forwardColor = value;
                if (isMovingForward) brush.Color = value;
                Invalidate();
            }
        }

        public Color BackwardColor
        {
            get => backwardColor;
            set
            {
                backwardColor = value;
                if (!isMovingForward) brush.Color = value;
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
            get => currentDiagonal;
            set
            {
                currentDiagonal = value;
                Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveShape();
            Invalidate();
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                new Form2(this).Show();
            };
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}