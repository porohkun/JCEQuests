using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCEQuests.Quests
{
    public class Quest
    {
        private Dictionary<string, QuestScene> _scenes = new Dictionary<string, QuestScene>();
        private List<string> _marks = new List<string>();
        private Dictionary<string, Dictionary<string, int>> _inventories = new Dictionary<string, Dictionary<string, int>>();

        public QuestScene CurrentScene { get; private set; }

        public Quest(IEnumerable<QuestScene> scenes, string startScene)
        {
            foreach (var scene in scenes)
                _scenes.Add(scene.Name, scene);

            SetCurrentScene(startScene);
        }

        private void SetCurrentScene(string scene)
        {
            if (_scenes.ContainsKey(scene))
                CurrentScene = _scenes[scene];
            else
                throw new QuestException(string.Format("Сцена '{0}' не существует.", scene));
        }

        private void AddMark(string mark)
        {
            if (!_marks.Contains(mark))
                _marks.Add(mark);
        }

        private void RemoveMark(string mark)
        {
            if (_marks.Contains(mark))
                _marks.Remove(mark);
        }

        private void AddItem(string inventory, string item, int count)
        {
            if (!_inventories.ContainsKey(inventory))
                _inventories.Add(inventory, new Dictionary<string, int>());
            var inv = _inventories[inventory];
            if (!inv.ContainsKey(item))
                inv.Add(item, 0);
            //if (inv[item] + count < 0)
            //    throw new QuestException(string.Format("Предмет '{0}.{1}' не может быть меньше нуля ({2}{3}={4}).", inventory, item, inv[item], count, inv[item] + count));
            inv[item] += count;
            if (inv[item] == 0)
                inv.Remove(item);
        }

        public IEnumerable<string> GetMarks()
        {
            return _marks.AsEnumerable<string>();
        }

        public bool InventoryExists(string inventory)
        {
            return _inventories.ContainsKey(inventory);
        }

        public int ItemCount(string inventory,string item)
        {
            if (InventoryExists(inventory))
                if (_inventories[inventory].ContainsKey(item))
                    return _inventories[inventory][item];
            return 0;
        }

        public IEnumerable<QuestItem> GetItems()
        {
            foreach (var inv in _inventories)
                foreach (var item in inv.Value)
                    yield return new QuestItem(inv.Key, item.Key, item.Value);
        }

        public IEnumerable<KeyValuePair<string, string>> GetActualChoices()
        {
            foreach (var choice in CurrentScene.GetChoices())
                if (choice.Value.Check(this))
                    yield return new KeyValuePair<string, string>(choice.Key, choice.Value.Text);
        }

        public void SelectChoice(string name)
        {
            try
            {
                var choice = CurrentScene.GetChoice(name);
                var action = choice.GetAction(this);

                foreach (var mark in action.GetMarksChange())
                    if (mark.Value)
                        AddMark(mark.Key);
                    else
                        RemoveMark(mark.Key);

                foreach (var invitem in action.GetItemsChange())
                {
                    var ii = invitem.Key.Split('.');
                    if (ii.Length != 2)
                        throw new QuestException(string.Format("Предмет '{0}' в неверном формате.", invitem.Key));
                    AddItem(ii[0], ii[1], invitem.Value);
                }

                var nextScene = action.GetNextScene();
                if (nextScene != null)
                    SetCurrentScene(nextScene);
            }
            catch (QuestException e)
            {
                throw new QuestException(string.Format("Не удалось сделать выбор '{0}' в сцене '{1}' по причине:\r\n- {2}", name, CurrentScene.Name, e.Message), e);
            }
        }

        public struct QuestItem
        {
            public string Inventory;
            public string Item;
            public int Count;

            public QuestItem(string inventory, string item, int count)
            {
                Inventory = inventory;
                Item = item;
                Count = count;
            }
        }

        internal static string FormatTextFromJson(string text)
        {
            return text.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t");
        }

        internal static string FormatTextToJson(string text)
        {
            return text.Replace("\r", "\\r").Replace("\n", "\\n").Replace("\t", "\\t");
        }

    }
}
