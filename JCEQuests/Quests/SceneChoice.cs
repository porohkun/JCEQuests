using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace JCEQuests.Quests
{
    public class SceneChoice
    {
        public string Text { get; private set; }
        private List<ChoiceAction> _actions = new List<ChoiceAction>();

        public SceneChoice(JSONValue json)
        {
            Text = json["text"];
            foreach (var action in json["actions"].Array)
                _actions.Add(new ChoiceAction(action));
        }

        internal ChoiceAction GetAction(Quest quest)
        {
            if (_actions.Count == 0) throw new QuestException("В списке нет действий.");
            foreach (var action in _actions)
                if (action.Check(quest))
                    return action;
            throw new QuestException("Не найдено подходящего действия.");

        }
    }
}
