using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Drawing;
using PNetJson;
using JsonConfigEditor;
using JsonConfigEditor.Plugins;

namespace JCEQuests
{
    public class Settings:ISettings
    {
        public static Settings Inst;

        static Settings()
        {
            Inst = new Settings();
        }

        //public Dictionary<string, Color> SetsColors { get; private set; }

        public Settings()
        {
            //SetsColors = new Dictionary<string, Color>();
        }

        public void ImportSettings(JSONValue settings)
        {
            //SetsColors = new Dictionary<string, Color>();

            //if (settings.Type == JSONValueType.Object)
            //    if (settings.Obj.ContainsKey("sets_colors"))
            //        foreach (string set in settings["sets_colors"].Obj.Keys)
            //            SetsColors.Add(set, Color.FromArgb(settings["sets_colors"][set]));
        }

        public JSONValue ExportSettings()
        {
            //JSONValue result = new JSONValue(new JSONObject(
            //    new JOPair("sets_colors", new JSONObject())
            //    ));
            //foreach (KeyValuePair<string, Color> pair in SetsColors)
            //    result["sets_colors"].Obj.Add(pair.Key,pair.Value.ToArgb());
            //return result;
            return new JSONValue();
        }
    }
}
