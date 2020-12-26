using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr4v1
{
    public partial class Form1 : Form
    {
        bool f_open { get; set; }
        bool f_save {get; set; }
        private string Line { get; set; }
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f_open == false && f_save == false)
            {
                string line = null;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    label1.Text = openFileDialog1.FileName;
                f_open = true;
                f_save = false;
                richTextBox1.Clear();
                StreamReader sr = File.OpenText(openFileDialog1.FileName);
                line = sr.ReadLine();
                while (line != null)
                {
                    Line += line;
                    richTextBox1.AppendText(line);
                    richTextBox1.AppendText("\r\n");
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f_save = true;
            Count.CountSequences(richTextBox1.Text);
            int count = Count.counter;
            StreamWriter sw = File.CreateText($"{openFileDialog1.FileName}.out");
            sw.WriteLine(count);
            sw.Close();
            richTextBox1.Text = count.ToString();
        }

        private void Form1_Load()
        {
            f_open = false; 
            f_save = false;
            label1.Text = "-";
            richTextBox1.Text = "";
        }
    }
}

