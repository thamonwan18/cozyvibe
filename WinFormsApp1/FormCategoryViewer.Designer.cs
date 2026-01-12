namespace WinFormsApp1
{
    partial class FormCategoryViewer
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Leelawadee UI Semilight", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 222);
            label1.Location = new Point(300, 503);
            label1.Name = "label1";
            label1.Size = new Size(70, 31);
            label1.TabIndex = 12;
            label1.Text = "label1";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 64, 64);
            button1.Font = new Font("Goudy Old Style", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(222, 563);
            button1.Name = "button1";
            button1.Size = new Size(232, 58);
            button1.TabIndex = 11;
            button1.Text = "ADD TO CART";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(8, 11);
            button2.Name = "button2";
            button2.Size = new Size(218, 57);
            button2.TabIndex = 10;
            button2.Text = "Go Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(222, 189);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(232, 282);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button4.Location = new Point(1672, 11);
            button4.Name = "button4";
            button4.Size = new Size(218, 57);
            button4.TabIndex = 14;
            button4.Text = "Check Out";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button3.Location = new Point(1448, 11);
            button3.Name = "button3";
            button3.Size = new Size(218, 57);
            button3.TabIndex = 13;
            button3.Text = "View Cart";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FormCategoryViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 247, 244);
            ClientSize = new Size(1902, 1033);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ControlText;
            Name = "FormCategoryViewer";
            Text = "Product";
            Load += FormCategoryViewer_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private Button button4;
        private Button button3;
    }
}