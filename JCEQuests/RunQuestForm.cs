using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JCEQuests.Quests;

namespace JCEQuests
{
    public partial class RunQuestForm : Form
    {
        private Quest _quest;

        public RunQuestForm(Quest quest)
        {
            InitializeComponent();
            _quest = quest;

            ShowCurrentScene();
        }

        private void ShowCurrentScene()
        {
            sceneNameBox.Text = _quest.CurrentScene.Name;
            sceneTextBox.Text = _quest.CurrentScene.Text;

            choicesGrid.Rows.Clear();
            foreach (var choice in _quest.GetActualChoices())
            {
                int i = choicesGrid.Rows.Add();
                var button = (DataGridViewButtonCell)choicesGrid.Rows[i].Cells[0];
                button.Tag = choice.Key;
                button.Value = choice.Value;
            }
            ShowCurrentMarks();
            ShowCurrentItems();
        }

        private void ShowCurrentMarks()
        {
            marksList.Items.Clear();
            foreach (var mark in _quest.GetMarks())
                marksList.Items.Add(mark);
        }

        private void ShowCurrentItems()
        {
            List<TreeNode> forDelete = new List<TreeNode>();
            foreach (TreeNode node in itemsTree.Nodes)
            {
                if (!_quest.InventoryExists(node.Text))
                    forDelete.Add(node);
                else
                    node.Nodes.Clear();
            }
            foreach (var node in forDelete) node.Remove();

            foreach (var item in _quest.GetItems())
            {
                if (!itemsTree.Nodes.ContainsKey(item.Inventory))
                    itemsTree.Nodes.Add(item.Inventory, item.Inventory);
                itemsTree.Nodes[item.Inventory].Nodes.Add(item.Item + ": " + item.Count);
            }
        }

        private void SelectChoice(string choice)
        {
            try
            {
                _quest.SelectChoice(choice);
            }
            catch (QuestException e)
            {
                MessageBox.Show(this,e.Message,"Ошибка");
            }
            ShowCurrentScene();
        }

        private void choicesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectChoice((string)choicesGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag);
        }
    }
}
