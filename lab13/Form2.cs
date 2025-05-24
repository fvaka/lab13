using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab13
{
    public partial class Form2 : Form
    {
        private Form1 mainForm;

        public Form2(Form1 form)
        {
            InitializeComponent();
            mainForm = form;

            // Настройка элементов управления
            trackBarSpeed.Minimum = 1;
            trackBarSpeed.Maximum = 100;
            trackBarSpeed.TickFrequency = 10;

            // Настройка цветовых кнопок
            btnForwardColor.BackColor = mainForm.ForwardColor;
            btnBackwardColor.BackColor = mainForm.BackwardColor;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            trackBarSpeed.Value = mainForm.Speed;

            // Установка текущей фигуры
            rbCircle.Checked = mainForm.ShapeType == SHAPE_TYPE.Circle;
            rbRhomb.Checked = mainForm.ShapeType == SHAPE_TYPE.Rhomb;
            rbTriangle.Checked = mainForm.ShapeType == SHAPE_TYPE.Triangle;

            rbMain.Checked = mainForm.DiagonalType == DIAGONAL_TYPE.Main;
            rbAnti.Checked = mainForm.DiagonalType == DIAGONAL_TYPE.Anti;
        }

        private void btnForwardColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = mainForm.ForwardColor;
            colorDialog1.ShowDialog();
            btnForwardColor.BackColor = colorDialog1.Color;
            mainForm.ForwardColor = colorDialog1.Color;
        }

        private void btnBackwardColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = mainForm.BackwardColor;
            colorDialog1.ShowDialog();
            btnBackwardColor.BackColor = colorDialog1.Color;
            mainForm.BackwardColor = colorDialog1.Color;

        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            mainForm.Speed = trackBarSpeed.Value;
        }

        private void rbShape_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCircle.Checked) mainForm.ShapeType = SHAPE_TYPE.Circle;
            else if (rbRhomb.Checked) mainForm.ShapeType = SHAPE_TYPE.Rhomb;
            else if (rbTriangle.Checked) mainForm.ShapeType = SHAPE_TYPE.Triangle;
        }

        private void rbDiagonal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMain.Checked)
                mainForm.DiagonalType = DIAGONAL_TYPE.Main;
            else if (rbAnti.Checked)
                mainForm.DiagonalType = DIAGONAL_TYPE.Anti;
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Применяем изменения при закрытии формы
            mainForm.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rbMain.Checked = false;
            rbAnti.Checked = false;
            rbTriangle.Checked = false;
            rbRhomb.Checked = false;
            rbCircle.Checked = false;
            trackBarSpeed.Value = 1;
            btnBackwardColor.BackColor = Color.White;
            btnForwardColor.BackColor = Color.White;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}