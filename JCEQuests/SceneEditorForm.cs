using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JCEQuests
{
    public partial class SceneEditorForm : Form
    {
        SceneControl _sceneControl;
        public SceneEditorForm()
        {
            InitializeComponent();
        }

        public SceneEditorForm(SceneControl sceneControl):this()
        {
            _sceneControl = sceneControl;
            headerBox.Text = _sceneControl.Header;
            textBox.Text = _sceneControl.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            choicesListBox.Controls.Add(new ChoiceControl());
        }

    }
}
