using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Text_Reader
{
    public partial class Form1 : Form
    {
        string str;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text Files(*.txt)|*.txt||";
            open.FilterIndex = 1;
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(open.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
           
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                writer.WriteLine(richTextBox1.Text);
                writer.Close();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_text_format_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.SelectionFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void bt_color_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor =  colorDialog1.Color;
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != null)
            {
                str = "";
                Clipboard.SetText(richTextBox1.Text);
                str = Clipboard.GetText();
            }
        }

        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != null)
            {
                str = "";
                Clipboard.SetText(richTextBox1.Text);
                str = Clipboard.GetText();
                richTextBox1.Clear();
            }
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }


        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Text = str;
        }


    }
}
