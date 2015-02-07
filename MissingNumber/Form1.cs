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

namespace MissingNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void scanLine(System.IO.StreamReader file)
        {
            string line;

            while ((line = file.ReadLine()) != null)
            {
                textBox1.AppendText(line);
                textBox1.AppendText("\n");

                if (line != "")
                {
                    string[] chars = line.Split(',');
                    int[] numbers = Array.ConvertAll<string, int>(chars, int.Parse);
                    Array.Sort(numbers);

                    int rangeLength = numbers[numbers.Length - 1] - numbers[0];
                    var lostNumbers = Enumerable.Range(numbers[0], rangeLength).Except(numbers);

                    string result = string.Join(",", lostNumbers);
                    textBox2.AppendText(result);
                    textBox2.AppendText("\n");
                    textBox2.AppendText("\n");
                }
            }//while
        }//scanLine()


        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;

            openFileDialog1.Filter = "txt files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            System.IO.StreamReader file = new System.IO.StreamReader(myStream);
                            
                            scanLine(file);
                            
                            file.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk.\n(Original error: " + ex.Message + ")");
                }
            }
        }
    }
}
