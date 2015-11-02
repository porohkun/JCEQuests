using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JsonConfigEditor;

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

        public void Open(string filename)
        {
            textBox1.Text = filename;
            File = new FilePath(filename);
            WasOpen = true;
        }

        public QuestEditorForm()
        {
            InitializeComponent();
        }

        public QuestEditorForm(ToolStrip ts, string fileName)
            : base(ts, fileName)
        {
            InitializeComponent();
            
        }

    }
}
