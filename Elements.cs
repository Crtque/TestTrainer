using System.Drawing;
using System.Windows.Forms;

namespace TrainerSpace
{
    class Elements
    {
        public static TextBox AddTb(string name, string text, int x, int y, bool enabled,bool show, Form form)
        {
            TextBox tb = new TextBox
            {
                Text = text,
                Name = name,
                Location = new Point(x, y),
                Enabled = enabled
            };
            if (show)
                form.Controls.Add(tb);
            return tb;
        }

        public static Button AddBtn(string name, string text, string tag, int x, int y, int size_x, int size_y, bool enabled, bool visible, bool show, Form form)
        {
            Button btn = new Button
            {
                Text = text,
                Width = size_x,
                Height = size_y,
                Tag = tag,
                Name = name,
                Visible = visible,
                Location = new Point(x, y),
                Enabled = enabled
            };
            if (show)
                form.Controls.Add(btn);
            return btn;
        }

        public static CheckBox AddCheckBox(string name, string tag, int x, int y, bool enabled, bool visible, bool show, Form form)
        {
            CheckBox ckbx = new CheckBox
            {
                Tag = tag,
                Name = name,
                Visible = visible,
                Location = new Point(x, y),
                Enabled = enabled
            };
            if (show)
                form.Controls.Add(ckbx);
            return ckbx;
        }
        public static Label AddLabel(string name, string text, int x, int y, bool show, bool autosize, Form form)
        {
            Label label = new Label
            {
                Text = text,
                Name = name,
                Location = new Point(x, y),
                AutoSize = autosize,
            };
            if (show)
                form.Controls.Add(label);
            return label;
        }

    }
}
