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

namespace Dacanvas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
         //Select Images From Path
        private void button1_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openF = new OpenFileDialog())
            {
                openF.InitialDirectory = "c:\\";
                openF.Filter = "All formats (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.gif) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.gif | SVG(*.svg) | *.svg";
                openF.FilterIndex = 1;
                openF.RestoreDirectory = true;
                openF.Multiselect = true;
                openF.Title = "Select a file";
                openF.ShowHelp = true;
                
                
                
                //Adds selected images to the ListBox
                if (openF.ShowDialog() == DialogResult.OK)
                {
                    listBox1.Items.AddRange(openF.FileNames);
                   
                }
            }   
        }

        //Selects Images from ListBox
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {

                textBox1.Text = listBox1.SelectedItem.ToString();
                var result = listBox1.SelectedItem.ToString();
                pictureBox1.Image = Image.FromFile(result);
            }
           
        }

        //Clear Image From Main View
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            textBox1.Clear();
        }

        //Clear Image List
        private void button3_Click(object sender, EventArgs e)
        {
            const string message = "Do you want to remove all items from the list?";
            const string caption = "Removing Items...";
            var result = MessageBox.Show(message, caption,MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                
            }
            else
            {
                listBox1.Items.Clear();
                pictureBox1.Image = null;
                textBox1.Clear();
                if (listBox1.Items.Count == 0)
                {
                     MessageBox.Show("List Cleared!");
                }
            } 
        }

        //Clear Selected Image From The ListBox
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            pictureBox1.Image = null;
            textBox1.Clear();
        }

        // Sort List (not final)
        private void button5_Click(object sender, EventArgs e)
        {
            int caseSwitch = 1;
            switch(caseSwitch){
                case 1:
                    listBox1.Sorted = true;
                    break;
                case 2:
                    listBox1.Sorted = false;
                    break;
            }
           
        }
    }
}


