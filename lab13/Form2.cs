using System;
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
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //mainForm = (Form1)this.Owner;
            trackBar1.Value = mainForm.Speed;
            linkColor.LinkColor = mainForm.ShapeColor;

            // Установка текущих значений
            rbCircle.Checked = mainForm.ShapeType == SHAPE_TYPE.Circle;
            rbRhomb.Checked = mainForm.ShapeType == SHAPE_TYPE.Rhomb;
            rbTriangle.Checked = mainForm.ShapeType == SHAPE_TYPE.Triangle;

            rbMain.Checked = mainForm.DiagonalType == DIAGONAL_TYPE.Main;
            rbAnti.Checked = mainForm.DiagonalType == DIAGONAL_TYPE.Anti;
        }

        private void linkColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                linkColor.BackColor = dialog.Color;
                mainForm.ShapeColor = dialog.Color;
            }
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            mainForm.Speed = trackBar1.Value;
        }

        private void rbShape_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCircle.Checked) mainForm.ShapeType = SHAPE_TYPE.Circle;
            else if (rbRhomb.Checked) mainForm.ShapeType = SHAPE_TYPE.Rhomb;
            else if (rbTriangle.Checked) mainForm.ShapeType = SHAPE_TYPE.Triangle;
        }

        private void rbDiagonal_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.DiagonalType = rbMain.Checked ? DIAGONAL_TYPE.Main : DIAGONAL_TYPE.Anti;
        }

        private void linkColor_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.Cancel) return;
                mainForm.ShapeColor = dialog.Color;
            }
        }
       
    }
}
