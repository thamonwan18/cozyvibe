namespace WinFormsApp1
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            flowLayoutPanelCategories = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanelCategories
            // 
            flowLayoutPanelCategories.AutoScroll = true;
            flowLayoutPanelCategories.BackColor = Color.FromArgb(248, 247, 244);
            flowLayoutPanelCategories.Location = new Point(219, 285);
            flowLayoutPanelCategories.Name = "flowLayoutPanelCategories";
            flowLayoutPanelCategories.Size = new Size(1482, 527);
            flowLayoutPanelCategories.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            button1.Location = new Point(1702, 12);
            button1.Name = "button1";
            button1.Size = new Size(188, 57);
            button1.TabIndex = 9;
            button1.Text = "My Account";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(12, 12);
            button2.Name = "button2";
            button2.Size = new Size(187, 57);
            button2.TabIndex = 7;
            button2.Text = "Go Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1902, 1033);
            Controls.Add(flowLayoutPanelCategories);
            Controls.Add(button1);
            Controls.Add(button2);
            Name = "Form7";
            Text = "Category";
            Load += Form7_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private FlowLayoutPanel flowLayoutPanelCategories;
        private Button button1;
    }
}