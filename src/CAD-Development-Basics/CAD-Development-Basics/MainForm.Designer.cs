
namespace CAD_Development_Basics
{
    partial class MainForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonOpenDrawing = new System.Windows.Forms.Button();
			this.buttonBuild = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.numericVisor = new System.Windows.Forms.NumericUpDown();
			this.numericBody = new System.Windows.Forms.NumericUpDown();
			this.numericArea = new System.Windows.Forms.NumericUpDown();
			this.numericHead = new System.Windows.Forms.NumericUpDown();
			this.numericThread = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numericVisor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericBody)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericArea)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericHead)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericThread)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 14);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Высота козырька:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 40);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(109, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Высота тела тумбы:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 67);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(145, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Диаметр площадки тумбы:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 95);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(208, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Диаметр отверстия для головки болта:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 121);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(202, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Диаметр отверстия под резьбу болта:";
			// 
			// buttonOpenDrawing
			// 
			this.buttonOpenDrawing.Location = new System.Drawing.Point(16, 157);
			this.buttonOpenDrawing.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOpenDrawing.Name = "buttonOpenDrawing";
			this.buttonOpenDrawing.Size = new System.Drawing.Size(126, 28);
			this.buttonOpenDrawing.TabIndex = 10;
			this.buttonOpenDrawing.Text = "Открыть чертеж";
			this.buttonOpenDrawing.UseVisualStyleBackColor = true;
			this.buttonOpenDrawing.Click += new System.EventHandler(this.buttonOpenDrawing_Click);
			// 
			// buttonBuild
			// 
			this.buttonBuild.Location = new System.Drawing.Point(276, 157);
			this.buttonBuild.Margin = new System.Windows.Forms.Padding(2);
			this.buttonBuild.Name = "buttonBuild";
			this.buttonBuild.Size = new System.Drawing.Size(126, 28);
			this.buttonBuild.TabIndex = 11;
			this.buttonBuild.Text = "Построить модель";
			this.buttonBuild.UseVisualStyleBackColor = true;
			this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(295, 11);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(113, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "от 110 мм до 240 мм";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(295, 38);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(113, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "от 350 мм до 780 мм";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(295, 67);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(119, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "от 600 мм до 1350 мм";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(295, 95);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(107, 13);
			this.label9.TabIndex = 15;
			this.label9.Text = "от 72 мм до 114 мм";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(295, 119);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(101, 13);
			this.label10.TabIndex = 16;
			this.label10.Text = "от 34 мм до 76 мм";
			// 
			// numericVisor
			// 
			this.numericVisor.Location = new System.Drawing.Point(215, 10);
			this.numericVisor.Margin = new System.Windows.Forms.Padding(2);
			this.numericVisor.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
			this.numericVisor.Minimum = new decimal(new int[] {
            110,
            0,
            0,
            0});
			this.numericVisor.Name = "numericVisor";
			this.numericVisor.Size = new System.Drawing.Size(75, 20);
			this.numericVisor.TabIndex = 17;
			this.numericVisor.Value = new decimal(new int[] {
            110,
            0,
            0,
            0});
			// 
			// numericBody
			// 
			this.numericBody.Location = new System.Drawing.Point(215, 36);
			this.numericBody.Margin = new System.Windows.Forms.Padding(2);
			this.numericBody.Maximum = new decimal(new int[] {
            780,
            0,
            0,
            0});
			this.numericBody.Minimum = new decimal(new int[] {
            350,
            0,
            0,
            0});
			this.numericBody.Name = "numericBody";
			this.numericBody.Size = new System.Drawing.Size(75, 20);
			this.numericBody.TabIndex = 18;
			this.numericBody.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
			// 
			// numericArea
			// 
			this.numericArea.Location = new System.Drawing.Point(215, 63);
			this.numericArea.Margin = new System.Windows.Forms.Padding(2);
			this.numericArea.Maximum = new decimal(new int[] {
            1350,
            0,
            0,
            0});
			this.numericArea.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.numericArea.Name = "numericArea";
			this.numericArea.Size = new System.Drawing.Size(75, 20);
			this.numericArea.TabIndex = 19;
			this.numericArea.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
			// 
			// numericHead
			// 
			this.numericHead.Location = new System.Drawing.Point(215, 91);
			this.numericHead.Margin = new System.Windows.Forms.Padding(2);
			this.numericHead.Maximum = new decimal(new int[] {
            114,
            0,
            0,
            0});
			this.numericHead.Minimum = new decimal(new int[] {
            72,
            0,
            0,
            0});
			this.numericHead.Name = "numericHead";
			this.numericHead.Size = new System.Drawing.Size(75, 20);
			this.numericHead.TabIndex = 20;
			this.numericHead.Value = new decimal(new int[] {
            72,
            0,
            0,
            0});
			// 
			// numericThread
			// 
			this.numericThread.Location = new System.Drawing.Point(215, 117);
			this.numericThread.Margin = new System.Windows.Forms.Padding(2);
			this.numericThread.Maximum = new decimal(new int[] {
            76,
            0,
            0,
            0});
			this.numericThread.Minimum = new decimal(new int[] {
            34,
            0,
            0,
            0});
			this.numericThread.Name = "numericThread";
			this.numericThread.Size = new System.Drawing.Size(75, 20);
			this.numericThread.TabIndex = 21;
			this.numericThread.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(418, 196);
			this.Controls.Add(this.numericThread);
			this.Controls.Add(this.numericHead);
			this.Controls.Add(this.numericArea);
			this.Controls.Add(this.numericBody);
			this.Controls.Add(this.numericVisor);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.buttonBuild);
			this.Controls.Add(this.buttonOpenDrawing);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Плагин";
			((System.ComponentModel.ISupportInitialize)(this.numericVisor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericBody)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericArea)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericHead)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericThread)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonOpenDrawing;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericVisor;
        private System.Windows.Forms.NumericUpDown numericBody;
        private System.Windows.Forms.NumericUpDown numericArea;
        private System.Windows.Forms.NumericUpDown numericHead;
        private System.Windows.Forms.NumericUpDown numericThread;
    }
}

