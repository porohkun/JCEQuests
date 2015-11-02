using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace JCEQuests.Quests
{
    public class QuestScene
    {
        public string Name { get; private set; }
        public string Text { get; private set; }

        private Dictionary<string, SceneChoice> _choices = new Dictionary<string, SceneChoice>();

        public QuestScene(JSONValue json)
        {
            Name = json["name"];
            Text = json["text"];
            foreach (var choice in json["choices"].Obj)
                _choices.Add(choice.Key, new SceneChoice(choice.Value));
        }

        internal SceneChoice GetChoice(string name)
        {
            if (_choices.ContainsKey(name))
                return _choices[name];
            else
                throw new QuestException(string.Format("Отсутствует переход '{0}'.", name));
        }
    }
}
