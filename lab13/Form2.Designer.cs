﻿namespace lab13
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTriangle = new System.Windows.Forms.RadioButton();
            this.rbRhomb = new System.Windows.Forms.RadioButton();
            this.rbCircle = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAnti = new System.Windows.Forms.RadioButton();
            this.rbMain = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnForwardColor = new System.Windows.Forms.Button();
            this.btnBackwardColor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBarSpeed);
            this.groupBox1.Location = new System.Drawing.Point(111, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Скорость движения:";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(35, 39);
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(123, 45);
            this.trackBarSpeed.TabIndex = 0;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbTriangle);
            this.groupBox2.Controls.Add(this.rbRhomb);
            this.groupBox2.Controls.Add(this.rbCircle);
            this.groupBox2.Location = new System.Drawing.Point(16, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 127);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вид фигуры:";
            // 
            // rbTriangle
            // 
            this.rbTriangle.AutoSize = true;
            this.rbTriangle.Location = new System.Drawing.Point(30, 104);
            this.rbTriangle.Name = "rbTriangle";
            this.rbTriangle.Size = new System.Drawing.Size(90, 17);
            this.rbTriangle.TabIndex = 2;
            this.rbTriangle.TabStop = true;
            this.rbTriangle.Text = "Треугольник";
            this.rbTriangle.UseVisualStyleBackColor = true;
            this.rbTriangle.CheckedChanged += new System.EventHandler(this.rbShape_CheckedChanged);
            // 
            // rbRhomb
            // 
            this.rbRhomb.AutoSize = true;
            this.rbRhomb.Location = new System.Drawing.Point(30, 68);
            this.rbRhomb.Name = "rbRhomb";
            this.rbRhomb.Size = new System.Drawing.Size(52, 17);
            this.rbRhomb.TabIndex = 1;
            this.rbRhomb.TabStop = true;
            this.rbRhomb.Text = "Ромб";
            this.rbRhomb.UseVisualStyleBackColor = true;
            this.rbRhomb.CheckedChanged += new System.EventHandler(this.rbShape_CheckedChanged);
            // 
            // rbCircle
            // 
            this.rbCircle.AutoSize = true;
            this.rbCircle.Location = new System.Drawing.Point(30, 34);
            this.rbCircle.Name = "rbCircle";
            this.rbCircle.Size = new System.Drawing.Size(48, 17);
            this.rbCircle.TabIndex = 0;
            this.rbCircle.TabStop = true;
            this.rbCircle.Text = "Круг";
            this.rbCircle.UseVisualStyleBackColor = true;
            this.rbCircle.CheckedChanged += new System.EventHandler(this.rbShape_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(79, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 53);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сброс настроек";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbAnti);
            this.groupBox3.Controls.Add(this.rbMain);
            this.groupBox3.Location = new System.Drawing.Point(192, 149);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 127);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Направление фигуры:";
            // 
            // rbAnti
            // 
            this.rbAnti.AutoSize = true;
            this.rbAnti.Location = new System.Drawing.Point(30, 88);
            this.rbAnti.Name = "rbAnti";
            this.rbAnti.Size = new System.Drawing.Size(145, 17);
            this.rbAnti.TabIndex = 1;
            this.rbAnti.TabStop = true;
            this.rbAnti.Text = "По побочной диагонали";
            this.rbAnti.UseVisualStyleBackColor = true;
            this.rbAnti.CheckedChanged += new System.EventHandler(this.rbDiagonal_CheckedChanged);
            // 
            // rbMain
            // 
            this.rbMain.AutoSize = true;
            this.rbMain.Location = new System.Drawing.Point(30, 50);
            this.rbMain.Name = "rbMain";
            this.rbMain.Size = new System.Drawing.Size(139, 17);
            this.rbMain.TabIndex = 0;
            this.rbMain.TabStop = true;
            this.rbMain.Text = "По главное диагонали";
            this.rbMain.UseVisualStyleBackColor = true;
            this.rbMain.CheckedChanged += new System.EventHandler(this.rbDiagonal_CheckedChanged);
            // 
            // btnForwardColor
            // 
            this.btnForwardColor.Location = new System.Drawing.Point(94, 291);
            this.btnForwardColor.Name = "btnForwardColor";
            this.btnForwardColor.Size = new System.Drawing.Size(90, 55);
            this.btnForwardColor.TabIndex = 4;
            this.btnForwardColor.Text = "Цвет для прямого движения ";
            this.btnForwardColor.UseVisualStyleBackColor = true;
            this.btnForwardColor.Click += new System.EventHandler(this.btnForwardColor_Click);
            // 
            // btnBackwardColor
            // 
            this.btnBackwardColor.Location = new System.Drawing.Point(212, 291);
            this.btnBackwardColor.Name = "btnBackwardColor";
            this.btnBackwardColor.Size = new System.Drawing.Size(88, 55);
            this.btnBackwardColor.TabIndex = 5;
            this.btnBackwardColor.Text = "Цвет для обратного движения";
            this.btnBackwardColor.UseVisualStyleBackColor = true;
            this.btnBackwardColor.Click += new System.EventHandler(this.btnBackwardColor_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 449);
            this.Controls.Add(this.btnBackwardColor);
            this.Controls.Add(this.btnForwardColor);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTriangle;
        private System.Windows.Forms.RadioButton rbRhomb;
        private System.Windows.Forms.RadioButton rbCircle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbAnti;
        private System.Windows.Forms.RadioButton rbMain;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnForwardColor;
        private System.Windows.Forms.Button btnBackwardColor;
    }
}