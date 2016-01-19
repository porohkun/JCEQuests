using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace JCEQuests.Quests
{
    public class SceneChoice
    {
        private Condition _condition;
        public string Text { get; private set; }
        private List<ChoiceAction> _actions = new List<ChoiceAction>();

        public SceneChoice(JSONValue json)
        {
            _condition = Condition.Create(json["condition"]);
            Text = Quest.FormatTextFromJson(json["text"]);
            foreach (var action in json["actions"].Array)
                _actions.Add(new ChoiceAction(action));
        }

        internal bool Check(Quest quest)
        {
            return _condition.Check(quest);
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
