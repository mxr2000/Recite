using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Recite
{
    public partial class Form1 : Form
    {
        List<Word> words = new List<Word>();
        int index = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            words.Clear();
            string input;
            string[] inputs;
            index = -1;
            StreamReader reader = new StreamReader(textBox1.Text);
            while(true)
            {
                input = reader.ReadLine();
                if (input == null || input.Length < 1)
                    break;
                inputs = input.Split(',');
                Word word = new Word(inputs[0], inputs[1]);
                words.Add(word);
            }
            toolStripStatusLabel1.Text = "Index:" + 0 + "/" + words.Count;
            reader.Close();
        }

        bool flag = true;
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!flag)
            {
                switch (e.KeyChar)
                {
                    case 'a': words[index].Extent--; flag = true; break;
                    case 's': words[index].Extent++; flag = true; break;
                    case 'd': words[index].Extent += 2; flag = true; break;
                    default: break;
                }
            }
            else
            {
                index++;
                flag = false;
            }
            if (index == words.Count)
            {
                index = 0;
                for(int i = 0; i < words.Count;)
                {
                    if (words[i].Extent == 0)
                        words.RemoveAt(i);
                    else
                        i++;
                }
            }
            label1.Text = words[index].Name;
            if (flag)
                label2.Text = words[index].Defination;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            words[index].Extent = (words[index].Extent == 0 ? 0 : words[index].Extent - 1);
            label2.Visible = true;
            textBox3.AppendText(label2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox3.AppendText(label2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            words[index].Extent += 1;
            label2.Visible = true;
            textBox3.AppendText(label2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index++;
            if (index == words.Count)
            {
                index = 0;
                for (int i = 0; i < words.Count;)
                {
                    if (words[i].Extent == 0)
                        words.RemoveAt(i);
                    else
                        i++;
                }
            }
            label1.Text = words[index].Name;
            label2.Text = words[index].Defination;
            label2.Visible = false;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox2.AppendText(label1.Text);
            toolStripStatusLabel1.Text = "Index:" + index + "/" + words.Count; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                string name = file.Name;
                string format = name.Split('.')[1];
                if(format == "txt")
                    comboBox1.Items.Add(file.Name);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {/*
            string input;
            string[] inputs;
            index = -1;
            StreamReader reader = new StreamReader(textBox1.Text);
            while (true)
            {
                input = reader.ReadLine();
                if (input == null || input.Length < 1)
                    break;
                inputs = input.Split(',');
                Word word = new Word(inputs[0], inputs[1]);
                words.Add(word);
            }
            reader.Close();*/
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if(index > 0)
            {
                index--;
                label1.Text = words[index].Name;
                label2.Text = words[index].Defination;
                label2.Visible = false;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.AppendText(label1.Text);
                toolStripStatusLabel1.Text = "Index: " + index + "/" + words.Count;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Items[comboBox1.SelectedIndex] as string;
        }
    }
}
