using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PNetJson;
using JsonConfigEditor;
using JsonConfigEditor.Plugins;
using JCEQuests.Quests;

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
            var scenes = new List<QuestScene>();

            foreach (var file in Directory.GetFiles(Car.Glob.Set.WS.ConfigJsonPath, "*.qst", SearchOption.AllDirectories))
                foreach (var json in JSONValue.Load(file).Array)
                    scenes.Add(new QuestScene(json));
            string startScene = "start";//scenes[0].Name;
            Quest quest = new Quest(scenes, startScene);

            RunQuestForm form = new RunQuestForm(quest);
            form.Show();
        }

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
