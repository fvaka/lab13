namespace lab13
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Stop.ForeColor = System.Drawing.Color.Brown;
            this.btn_Stop.Location = new System.Drawing.Point(143, 280);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(122, 45);
            this.btn_Stop.TabIndex = 0;
            this.btn_Stop.Text = "Стоп";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Settings
            // 
            this.btn_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Settings.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Settings.Location = new System.Drawing.Point(291, 282);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(121, 43);
            this.btn_Settings.TabIndex = 1;
            this.btn_Settings.Text = "Настройки";
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 367);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.btn_Stop);
            this.Name = "Form1";
            this.Text = "Движение фигуры";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Settings;
    }
}

