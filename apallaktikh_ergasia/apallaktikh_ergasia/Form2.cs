using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apallaktikh_ergasia
{
    public partial class Form2 : Form
    {
        public Form2(int player)
        {
            InitializeComponent();
            
            BinaryFormatter bf = new BinaryFormatter();
            Stream st = new FileStream("players.txt", FileMode.OpenOrCreate);
            int i = 0;
            string tmp2;
            
            int[] array = new int[player];
            string[] name = new string[player];
            try { 
            while (true)
                {
                    Player p = (Player)bf.Deserialize(st);
                    array[i] = p.time;
                    name[i] = p.name;
                    i++;
                }
            }
            catch (Exception exc)
            {
                st.Close();
            }

            int tmp;
            for (i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[i])
                    {
                        tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                        tmp2 = name[i];
                        name[i] = name[j];
                        name[j] = tmp2;
                    }
                }
            }
            //Array.Sort(array);
            //Array.Reverse(array);
            try
            {
                for (int j = 0; j < 10; j++)
                {
                    richTextBox1.AppendText(array[j].ToString() + " " + name[j] + Environment.NewLine);
                }
            } catch(Exception e)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }
    }
}
