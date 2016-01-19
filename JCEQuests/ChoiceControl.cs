using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JCEQuests
{
    public partial class ChoiceControl : UserControl
    {
        public ChoiceControl()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void upButton_Click(object sender, EventArgs e)
        {
            var parent = ((ControlsListBox)Parent);
            int index = parent.Controls.IndexOf(this) - 1;
            if (index >= 0)
            {
                parent.Controls.SetChildIndex(this, index);
                parent.UpdateChildControlsPositions();
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            var parent = ((ControlsListBox)Parent);
            int index = parent.Controls.IndexOf(this) + 1;
            if (index < parent.Controls.Count)
            {
                parent.Controls.SetChildIndex(this, index);
                parent.UpdateChildControlsPositions();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ((ControlsListBox)Parent).Controls.Remove(this);
        }

        private void addActionButton_Click(object sender, EventArgs e)
        {
            actionsListBox.Controls.Add(new Button());
        }

        private void actionsListBox_Resize(object sender, EventArgs e)
        {
            Height = 51 + actionsListBox.Height;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

    }
}
