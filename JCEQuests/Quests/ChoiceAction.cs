using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace JCEQuests.Quests
{
    class ChoiceAction
    {
        private Condition _condition;
        private Dictionary<string, bool> _marks = new Dictionary<string, bool>();
        private Dictionary<string, int> _items = new Dictionary<string, int>();
        private string _nextScene;

        public ChoiceAction(JSONValue json)
        {
            _condition = Condition.Create(json["condition"]);
            if (json.Obj.ContainsKey("marks"))
                foreach (var mark in json["marks"].Obj)
                    _marks.Add(mark.Key, mark.Value);
            if (json.Obj.ContainsKey("items"))
                foreach (var item in json["items"].Obj)
                    _items.Add(item.Key, item.Value);
            if (json.Obj.ContainsKey("scene"))
                _nextScene = json["scene"];
        }

        internal bool Check(Quest quest)
        {
            return _condition.Check(quest);
        }

        internal IEnumerable<KeyValuePair<string, bool>> GetMarksChange()
        {
            foreach (var mark in _marks) yield return mark;
        }

        internal IEnumerable<KeyValuePair<string, int>> GetItemsChange()
        {
            foreach (var item in _items) yield return item;
        }

        internal string GetNextScene()
        {
            return _nextScene;
        }
    }
}
