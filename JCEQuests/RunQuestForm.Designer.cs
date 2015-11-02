namespace JCEQuests
{
    partial class RunQuestForm
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
            this.sceneTextBox = new System.Windows.Forms.TextBox();
            this.sceneNameBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ChoicesList = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.marksList = new System.Windows.Forms.ListBox();
            this.itemsTree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // sceneTextBox
            // 
            this.sceneTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sceneTextBox.Location = new System.Drawing.Point(3, 29);
            this.sceneTextBox.Multiline = true;
            this.sceneTextBox.Name = "sceneTextBox";
            this.sceneTextBox.ReadOnly = true;
            this.sceneTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sceneTextBox.Size = new System.Drawing.Size(369, 215);
            this.sceneTextBox.TabIndex = 0;
            // 
            // sceneNameBox
            // 
            this.sceneNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sceneNameBox.Location = new System.Drawing.Point(3, 3);
            this.sceneNameBox.Name = "sceneNameBox";
            this.sceneNameBox.ReadOnly = true;
            this.sceneNameBox.Size = new System.Drawing.Size(369, 20);
            this.sceneNameBox.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(586, 500);
            this.splitContainer1.SplitterDistance = 375;
            this.splitContainer1.TabIndex = 2;
            // 
            // ChoicesList
            // 
            this.ChoicesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChoicesList.FormattingEnabled = true;
            this.ChoicesList.IntegralHeight = false;
            this.ChoicesList.Location = new System.Drawing.Point(3, 3);
            this.ChoicesList.Name = "ChoicesList";
            this.ChoicesList.Size = new System.Drawing.Size(369, 243);
            this.ChoicesList.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.sceneNameBox);
            this.splitContainer2.Panel1.Controls.Add(this.sceneTextBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ChoicesList);
            this.splitContainer2.Size = new System.Drawing.Size(375, 500);
            this.splitContainer2.SplitterDistance = 247;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.marksList);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Panel2.Controls.Add(this.itemsTree);
            this.splitContainer3.Size = new System.Drawing.Size(207, 500);
            this.splitContainer3.SplitterDistance = 247;
            this.splitContainer3.TabIndex = 0;
            // 
            // marksList
            // 
            this.marksList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marksList.FormattingEnabled = true;
            this.marksList.IntegralHeight = false;
            this.marksList.Location = new System.Drawing.Point(3, 29);
            this.marksList.Name = "marksList";
            this.marksList.Size = new System.Drawing.Size(201, 215);
            this.marksList.TabIndex = 3;
            // 
            // itemsTree
            // 
            this.itemsTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsTree.Location = new System.Drawing.Point(3, 29);
            this.itemsTree.Name = "itemsTree";
            this.itemsTree.Size = new System.Drawing.Size(201, 217);
            this.itemsTree.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Текущие метки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Предметы в инвентарях";
            // 
            // RunQuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 524);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RunQuestForm";
            this.Text = "RunQuestForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox sceneTextBox;
        private System.Windows.Forms.TextBox sceneNameBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox ChoicesList;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox marksList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView itemsTree;
    }
}