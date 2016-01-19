using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JsonConfigEditor;
using PNetJson;

namespace JCEQuests
{
    public partial class QuestEditorForm : TemplateForm, ISaveableForm
    {
        #region ISaveableForm

        public bool Edited
        {
            get { return _Edited; }
            protected set
            {
                if (value != _Edited)
                {
                    if (value)
                    {
                        SetText(File.Name + "*");
                    }
                    else
                    {
                        SetText(File.Name);
                    }
                    _Edited = value;
                    ((MainForm)MdiParent).EditedCheck();
                }
            }
        }
        private bool _Edited;
        public FilePath File { get; private set; }
        public bool CanUndo { get; private set; }
        public bool CanRedo { get; private set; }
        public bool WasOpen { get; private set; }
        public void Save() { }

        #endregion

        public QuestEditorForm()
        {
            InitializeComponent();
        }

        public QuestEditorForm(ToolStrip ts, string fileName)
            : base(ts, fileName)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            
        }

        public void Open(string filename)
        {
            File = new FilePath(filename);
            toolItem.Text = File.Name;
            WasOpen = true;
        }

        private void QuestEditorForm_Resize(object sender, EventArgs e)
        {
            if (pictureBox1.Width < panel1.Width) pictureBox1.Width = panel1.Width;
            if (pictureBox1.Height < panel1.Height) pictureBox1.Height = panel1.Height;
        }
        SceneControl scene;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var json = JSONValue.Load(File.FullPath);
            scene = new SceneControl(json[0]);
            scene.DoubleClick += (sender1, e1) => { (new SceneEditorForm(scene)).Show(); };
            pictureBox1.Controls.Add(scene);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

    }
}
