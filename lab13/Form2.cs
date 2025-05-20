using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab13
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 owner = (Form1)this.Owner;
            trackBar1.Value = owner.MovementSpeed;
            linkLabel1.ForeColor = owner.ForwardColor;
            switch (owner.CurrentShape)
            {
                case SHAPE_TYPE.Circle: 
                    break;
                case SHAPE_TYPE.Rhomb:
                    break;
                case SHAPE_TYPE.Triangle:
                    break;
                default:
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
