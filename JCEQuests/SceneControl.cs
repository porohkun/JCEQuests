using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JCEQuests.Quests;
using PNetJson;

namespace JCEQuests
{
    public partial class SceneControl : UserControl
    {
        private string _header;

        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                headerBox.Text = value;
            }
        }
        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                textBox.Text = value.Replace("\r\n", " ").Replace("\t", " ");
            }
        }

        private bool _collapsed = false;
        public bool Collapsed
        {
            get { return _collapsed; }
            set
            {
                _collapsed = value; 
                if (_collapsed)
                {
                    collapseBtn.Image = global::JCEQuests.Properties.Resources.down;
                    Height = headerBox.Height;
                }
                else
                {
                    collapseBtn.Image = global::JCEQuests.Properties.Resources.up;
                    UpdateSize();
                }
            }
        }

        public SceneControl()
        {
            InitializeComponent();
            headerBox.DoubleClick += base_DoubleClick;
            textBox.DoubleClick += base_DoubleClick;
        }

        void base_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        public SceneControl(JSONValue scene):this()
        {
            Header = scene["name"];
            Text = scene["text"];
            var pos = scene["position"].Str.Split(':');
            Location = new Point(int.Parse(pos[0]), int.Parse(pos[1]));
        }

        private void UpdateSize()
        {
            if (!Collapsed)
                Height = headerBox.Height + textBox.Height ;
        }

        private void collapseBtn_Click(object sender, EventArgs e)
        {
            Collapsed = !Collapsed;
        }

        public void AddChoice()
        {

        }
    }
}
