namespace JCEQuests
{
    partial class ChoiceControl
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.conditionBox = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.addActionButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.actionsListBox = new JCEQuests.ControlsListBox();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(27, 3);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(157, 20);
            this.nameBox.TabIndex = 0;
            this.nameBox.Text = "name";
            this.nameBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // conditionBox
            // 
            this.conditionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conditionBox.Location = new System.Drawing.Point(190, 3);
            this.conditionBox.Name = "conditionBox";
            this.conditionBox.Size = new System.Drawing.Size(163, 20);
            this.conditionBox.TabIndex = 1;
            this.conditionBox.Text = "condition";
            this.conditionBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(27, 27);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(326, 20);
            this.textBox.TabIndex = 2;
            this.textBox.Text = "text";
            this.textBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // addActionButton
            // 
            this.addActionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addActionButton.Image = global::JCEQuests.Properties.Resources.plus;
            this.addActionButton.Location = new System.Drawing.Point(356, 26);
            this.addActionButton.Name = "addActionButton";
            this.addActionButton.Size = new System.Drawing.Size(22, 22);
            this.addActionButton.TabIndex = 6;
            this.addActionButton.UseVisualStyleBackColor = true;
            this.addActionButton.Click += new System.EventHandler(this.addActionButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Image = global::JCEQuests.Properties.Resources.cross;
            this.deleteButton.Location = new System.Drawing.Point(356, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(22, 22);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // downButton
            // 
            this.downButton.Image = global::JCEQuests.Properties.Resources.down;
            this.downButton.Location = new System.Drawing.Point(2, 26);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(22, 22);
            this.downButton.TabIndex = 4;
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.Image = global::JCEQuests.Properties.Resources.up;
            this.upButton.Location = new System.Drawing.Point(2, 2);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(22, 22);
            this.upButton.TabIndex = 3;
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // actionsListBox
            // 
            this.actionsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsListBox.AutoScroll = true;
            this.actionsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.actionsListBox.EnableAutoHeight = true;
            this.actionsListBox.FixedChildWidth = true;
            this.actionsListBox.Location = new System.Drawing.Point(27, 50);
            this.actionsListBox.Name = "actionsListBox";
            this.actionsListBox.Size = new System.Drawing.Size(353, 0);
            this.actionsListBox.TabIndex = 7;
            this.actionsListBox.Resize += new System.EventHandler(this.actionsListBox_Resize);
            // 
            // ChoiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.actionsListBox);
            this.Controls.Add(this.addActionButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.conditionBox);
            this.Controls.Add(this.nameBox);
            this.Name = "ChoiceControl";
            this.Size = new System.Drawing.Size(380, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox conditionBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addActionButton;
        private ControlsListBox actionsListBox;
    }
}
