namespace WinFormsApp1
{
    partial class FormSlipReview
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(98, 121);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(381, 512);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.Location = new Point(706, 602);
            button1.Name = "button1";
            button1.Size = new Size(259, 59);
            button1.TabIndex = 8;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(794, 526);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(248, 36);
            comboBox1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Leelawadee UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(640, 528);
            label1.Name = "label1";
            label1.Size = new Size(115, 28);
            label1.TabIndex = 11;
            label1.Text = "อัพเดทสถานะ";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(577, 53);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(502, 442);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // FormSlipReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 247, 244);
            ClientSize = new Size(1182, 710);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "FormSlipReview";
            Text = "FormSlipReview";
            Load += FormSlipReview_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Button button1;
        private ComboBox comboBox1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}