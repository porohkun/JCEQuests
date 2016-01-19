using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JCEQuests
{
    public partial class ControlsListBox : UserControl
    {
        private List<Control> _locked = new List<Control>();
        private Dictionary<Control, int> _collapsedControls = new Dictionary<Control, int>();

        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        public bool FixedChildWidth { get { return _fixedChildWidth; } set { _fixedChildWidth = value; UpdateChildControlsPositions(); } }
        private bool _fixedChildWidth = false;

        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(20)]
        public int ChildWidth { get { return _childWidth; } set { _childWidth = value; UpdateChildControlsPositions(); } }
        private int _childWidth = 20;

        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        public bool EnableAutoHeight { get { return _enableAutoHeight; } set { _enableAutoHeight = value; UpdateChildControlsPositions(); } }
        private bool _enableAutoHeight = false;
        public ControlsListBox()
        {
            InitializeComponent();

        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!IsLocked(e.Control))
                UpdateChildControlsPositions();
            e.Control.VisibleChanged += Control_VisibleChanged;
            e.Control.SizeChanged += Control_SizeChanged;
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            UpdateChildControlsPositions();
            e.Control.VisibleChanged -= Control_VisibleChanged;
            e.Control.SizeChanged -= Control_SizeChanged;
        }

        void Control_SizeChanged(object sender, EventArgs e)
        {
            UpdateChildControlsPositions();
        }

        void Control_VisibleChanged(object sender, EventArgs e)
        {
            var control = ((Control)sender);
            if (control.Visible)
                ExpandControl(control);
            else
                CollapseControl(control);
            UpdateChildControlsPositions();
        }

        internal bool IsLocked(Control item)
        {
            return (_locked.Contains(item));
        }

        internal void LockUpdateFor(Control item)
        {
            if (!IsLocked(item))
                _locked.Add(item);
        }

        internal void UnlockUpdateFor(Control item)
        {
            if (IsLocked(item))
                _locked.Remove(item);
            UpdateChildControlsPositions();
        }

        public void UpdateChildControlsPositions()
        {
            int pos = 0;
            int bottomMargin = 0;
            VerticalScroll.Value = 0;
            for (int i = 0; i < Controls.Count; i++)
            {
                var control = Controls[i];
                if (control.Visible)
                {
                    control.Dock = DockStyle.None;
                    control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    control.Top = pos += Math.Max(bottomMargin, control.Margin.Top);
                    if (FixedChildWidth) control.Height = ChildWidth;
                    pos += control.Height;
                    bottomMargin = control.Margin.Bottom;
                }
                else
                {
                    control.Bounds = new Rectangle(0, 0, 0, 0);
                }
            }
            if (EnableAutoHeight)
            {
                int height = Math.Max(MinimumSize.Height, pos + bottomMargin + (Size.Height - ClientSize.Height) / 2);
                Height = MaximumSize.IsEmpty ? height : Math.Min(MaximumSize.Height, height);
            }
            for (int i = 0; i < Controls.Count; i++)
            {
                var control = Controls[i];
                if (control.Visible)
                {
                    control.Left = control.Margin.Left;
                    control.Width = ClientSize.Width - control.Margin.Horizontal;
                }
            }
        }

        public void CollapseControl(int index)
        {
            CollapseControl(Controls[index]);
        }

        public void CollapseControl(Control control)
        {
            if (!_collapsedControls.ContainsKey(control))
            {
                _collapsedControls.Add(control, control.Height);
                control.Height = 0;
                control.Visible = false;
            }
        }

        public void ExpandControl(int index)
        {
            ExpandControl(Controls[index]);
        }

        public void ExpandControl(Control control)
        {
            if (_collapsedControls.ContainsKey(control))
            {
                control.Height = _collapsedControls[control];
                _collapsedControls.Remove(control);
                control.Visible = true;
            }
        }
    }

    public static class ControlCollectionExtension
    {
        private static Type _controlsListBoxType = typeof(ControlsListBox);
        public static void Insert(this Control.ControlCollection controlCollection, int index, Control item)
        {
            bool isCListBox = _controlsListBoxType.IsAssignableFrom(controlCollection.Owner.GetType());
            if (isCListBox) ((ControlsListBox)controlCollection.Owner).LockUpdateFor(item);

            if (controlCollection.Count < index) throw new IndexOutOfRangeException();
            controlCollection.Add(item);
            controlCollection.SetChildIndex(item, index);

            if (isCListBox) ((ControlsListBox)controlCollection.Owner).UnlockUpdateFor(item);
        }

        public static void InsertRange(this Control.ControlCollection controlCollection, int index, IEnumerable<Control> collection)
        {
            foreach (var control in collection)
                controlCollection.Insert(index++, control);
        }
    }
}
