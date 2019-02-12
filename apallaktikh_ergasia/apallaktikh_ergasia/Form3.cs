using System;
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
    public partial class Form3 : Form
    {
        private string name;
        private int Time, Tries;
        public Form3(int time, int tries)
        {
            InitializeComponent();
            Time = time;
            Tries = tries;
            label5.Text = Time.ToString();
            label6.Text = Tries.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            BinaryFormatter bf = new BinaryFormatter();
            Stream st = new FileStream("players.txt", FileMode.Append, FileAccess.Write);
            bf.Serialize(st, new Player(Time, Tries, name));
            st.Close();
            this.Hide();
    
        }

    }
}
