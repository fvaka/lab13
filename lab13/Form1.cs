using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab13
{
    public enum STATUS { Main, Side };
    public enum SHAPE_TYPE { Circle, Rhomb, Triangle }
    public enum MOVEMENT { Forward, Backward }
    public partial class Form1 : Form
    {
        int size = 80;
        int x = 1, y = 1;
        int dx = 5, dy = 5;
        Color forwardColor = Color.Red;
        Color backwardColor = Color.Red;
        SHAPE_TYPE currentShape = SHAPE_TYPE.Circle;
        STATUS currentDirection = STATUS.Main;
        MOVEMENT movement = MOVEMENT.Forward;
        SolidBrush brush;
        Rectangle shapeRect;

        public Form1()
        {
            InitializeComponent();
            brush = new SolidBrush(forwardColor);
            this.DoubleBuffered = true;
            this.KeyPreview = true;

        }

        public int MovementSpeed
        {
            get { return 100 - timer1.Interval; }
            set { timer1.Interval = Math.Max(1, 100 - value); }
        }

        public Color ForwardColor
        {
            get => forwardColor;
            set
            {
                forwardColor = value;
                if (movement == MOVEMENT.Forward) { brush.Color = value; }
            }
        }

        public Color BackwardColor
        {
            get => backwardColor;
            set
            {
                backwardColor = value;
                if (movement == MOVEMENT.Backward) { brush.Color = value; }
            }
        }

        public SHAPE_TYPE CurrentShape
        {
            get => currentShape;
            set => currentShape = value;
        }

        public STATUS CurrentDirection
        {
            get => currentDirection;
            set => currentDirection = value;
        }

        // событие работы таймера с заданным интервалом
        private void timer1_Tick(object sender, EventArgs e)
        {
            shapeRect = new Rectangle(x, y, size, size);
            this.Invalidate(shapeRect);
            if (currentDirection == STATUS.Main)
            {
                if (movement == MOVEMENT.Forward)
                {
                    x += dx;
                    y += dy;
                }
                else
                {
                    x -= dx;
                    y -= dy;
                }
            }
            else
            {
                if (movement == MOVEMENT.Backward)
                {
                    x += dx;
                    y -= dy;
                }
                else
                {
                    x -= dx;
                    y += dy;
                }
            }

            bool hitBorders = false;
            if (currentDirection == STATUS.Main)
            {
                if (movement == MOVEMENT.Forward)
                {
                    if (x >= ClientSize.Width - size || y >= ClientSize.Height - size)
                    {
                        hitBorders = true;
                    }
                }
                else
                {
                    if (x <= 0 || y <= 0)
                    {
                        hitBorders = true;
                    }
                }
            }
            else
            {
                if (movement == MOVEMENT.Forward)
                {
                    // Проверяем правую и верхнюю границы
                    if (x >= ClientSize.Width - size || y <= 0)
                        hitBorders = true;
                }
                else
                {
                    // Проверяем левую и нижнюю границы
                    if (x <= 0 || y >= ClientSize.Height - size)
                        hitBorders = true;
                }
            }
            if (hitBorders)
            {
                // Меняем направление движения
                movement = movement == MOVEMENT.Forward ? MOVEMENT.Backward : MOVEMENT.Forward;
                // Меняем цвет в соответствии с направлением
                brush.Color = movement == MOVEMENT.Forward ?
                    forwardColor : backwardColor;
            }

            shapeRect = new Rectangle(x, y, size, size);
            this.Invalidate(shapeRect);
        }
        private void Form1_Paint(object sender, PaintEventArgs e) // событиеперерисовки формы
        {
            // Рисуем фигуру в зависимости от выбранного типа
            switch (currentShape)
            {
                case SHAPE_TYPE.Circle:
                    // Рисуем круг
                    e.Graphics.FillEllipse(brush, shapeRect);
                    break;
                case SHAPE_TYPE.Rhomb:
                    // Создаем точки для ромба
                    Point[] diamondPoints = {
                        new Point(x + size/2, y),               // Верхняя точка
                        new Point(x + size, y + size/2),        // Правая точка
                        new Point(x + size/2, y + size),        // Нижняя точка
                        new Point(x, y + size/2)                // Левая точка
                    };
                    // Рисуем ромб
                    e.Graphics.FillPolygon(brush, diamondPoints);
                    break;
                case SHAPE_TYPE.Triangle:
                    // Создаем точки для треугольника
                    Point[] trianglePoints = {
                        new Point(x + size/2, y),              // Верхняя точка
                        new Point(x + size, y + size),          // Правая нижняя
                        new Point(x, y + size)                  // Левая нижняя
                    };
                    e.Graphics.FillPolygon(brush, trianglePoints);
                    break;
            }
        }
    }
}
