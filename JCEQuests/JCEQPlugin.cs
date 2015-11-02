using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PNetJson;
using JsonConfigEditor;
using JsonConfigEditor.Plugins;

namespace JCEQuests
{
    public class JCEQPlugin : IPlugin
    {
        public string GetFullName() { return "JCEQuests"; }

        public IEnumerable<ToolStripMenuItem> GetMenuItems()
        {
            ToolStripMenuItem item2 = new ToolStripMenuItem("Отладка") { Tag = "{\"enabled\":\"True\"}" };
            item2.Click += RunQuest;
            yield return item2;
        }

        public IEnumerable<string> GetMasks()
        {
            yield return "qst";
        }

        public TemplateForm OpenFile(string filename)
        {
            if (Path.GetExtension(filename) == ".qst")
            {
                var form = MainForm.Instance.MakeNewChildForm(typeof(QuestEditorForm), "квест") as QuestEditorForm;
                form.Open(filename);
                return form;
            }
            return null;
        }

        private void RunQuest(object sender, EventArgs e)
        {
            RunQuestForm form = new RunQuestForm();
            form.Show(MainForm.Instance);
        }
        //{
        //    bool edited = false;
        //    foreach (ISaveableForm frm in MainForm.Instance.MdiChildren)
        //    {
        //        if (frm.Edited)
        //        {
        //            edited = true;
        //            break;
        //        }
        //    }
        //    if (edited)
        //        if (MessageBox.Show("Для сборки карт все открытые файлы должны быть сохранены. Сохранить открытые файлы?",
        //            "Сборка карт", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            MainForm.Instance.SaveAllFiles(this, new EventArgs());
        //            edited = false;
        //        }
        //    if (!edited)
        //    {
        //        BuildCardsForm f2 = new BuildCardsForm();
        //        f2.ShowDialog(MainForm.Instance);
        //    }
        //}

        //private void SetsEdit(object sender, EventArgs e)
        //{
        //    MainForm.Instance.MakeNewChildForm(typeof(SetsEditForm), "Правка сетов");
        //    //SetsEditForm sef = new SetsEditForm(toolStrip1, "Правка сетов");
        //    //sef.MdiParent = this;
        //    //sef.Show();
        //}

        public ISettings GetEmptySettings()
        {
            return new Settings();
        }

        public void RestoreSettings(ISettings settings)
        {
            Settings.Inst = settings as Settings;
        }
    }
}
