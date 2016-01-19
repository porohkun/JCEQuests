namespace JCEQuests
{
    partial class SceneControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.Label();
            this.headerBox = new System.Windows.Forms.Label();
            this.collapseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BackColor = System.Drawing.SystemColors.Info;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textBox.Location = new System.Drawing.Point(0, 15);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(227, 105);
            this.textBox.TabIndex = 1;
            this.textBox.Tag = "";
            // 
            // headerBox
            // 
            this.headerBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerBox.Location = new System.Drawing.Point(-1, -1);
            this.headerBox.Name = "headerBox";
            this.headerBox.Size = new System.Drawing.Size(205, 17);
            this.headerBox.TabIndex = 2;
            // 
            // collapseBtn
            // 
            this.collapseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.collapseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.collapseBtn.Image = global::JCEQuests.Properties.Resources.up;
            this.collapseBtn.Location = new System.Drawing.Point(204, 0);
            this.collapseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.collapseBtn.Name = "collapseBtn";
            this.collapseBtn.Size = new System.Drawing.Size(23, 15);
            this.collapseBtn.TabIndex = 3;
            this.collapseBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.collapseBtn.UseVisualStyleBackColor = true;
            this.collapseBtn.Click += new System.EventHandler(this.collapseBtn_Click);
            // 
            // SceneControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.collapseBtn);
            this.Controls.Add(this.headerBox);
            this.Controls.Add(this.textBox);
            this.Name = "SceneControl";
            this.Size = new System.Drawing.Size(229, 198);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label textBox;
        private System.Windows.Forms.Label headerBox;
        private System.Windows.Forms.Button collapseBtn;

    }
}
