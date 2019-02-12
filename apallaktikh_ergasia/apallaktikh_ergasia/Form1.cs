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
    public partial class Form1 : Form
    {
        Random random = new Random();
        int counter = 0;
        PictureBox control1, control2 = null;
        Card card1 = new Card();    Card card13 = new Card();
        Card card2 = new Card();    Card card14 = new Card();
        Card card3 = new Card();    Card card15 = new Card();
        Card card4 = new Card();    Card card16 = new Card();
        Card card5 = new Card();    Card card17 = new Card();
        Card card6 = new Card();    Card card18 = new Card();
        Card card7 = new Card();    Card card19 = new Card();
        Card card8 = new Card();    Card card20 = new Card();
        Card card9 = new Card();    Card card21 = new Card();
        Card card10 = new Card();   Card card22 = new Card();
        Card card11 = new Card();   Card card23 = new Card();
        Card card12 = new Card();   Card card24 = new Card();
        List<int> num = new List<int>();
        List<string> controls = new List<string>();
        List<string> filesToShow = new List<string>();
        List<string> filesToShow2 = new List<string>();
        List<PictureBox> pictureBoxes;
        string path = Environment.CurrentDirectory; // auto deixnei to current working directory px (i.e. \bin\Debug) h alliws Directory.GetParent(workingDirectory).Parent.FullName; gia to current project directory
        Dictionary<PictureBox, Card> dictionary = new Dictionary<PictureBox, Card>();
        Dictionary<int, Player> players = new Dictionary<int, Player>();
        public int time = 0;
        public int player = 0;
        int matches = 0;
        public int tries = 0;

        public Form1()
        {
            InitializeComponent();

            pictureBoxes = new List<PictureBox> {
            pictureBox1,pictureBox9,pictureBox17,
            pictureBox2,pictureBox10,pictureBox18,
            pictureBox3,pictureBox11,pictureBox19,
            pictureBox4,pictureBox12,pictureBox20,
            pictureBox5,pictureBox13,pictureBox21,
            pictureBox6,pictureBox14,pictureBox22,
            pictureBox7,pictureBox15,pictureBox23,
            pictureBox8,pictureBox16,pictureBox24
            };
        }

        private void FlipCard(object sender)
        {
            try
            {
                if (control1 == null || counter % 2 == 0)
                {
                    control1 = (PictureBox)sender;
                    control1.ImageLocation = dictionary[control1].image;
                }
                else
                {
                if (control2 == null || counter % 2 != 0)
                    {
                        control2 = (PictureBox)sender;
                        control2.ImageLocation = dictionary[control2].image;
                    }
                }
            }catch(Exception exce)
            {
                MessageBox.Show("Please press the start button to play.");
            }
        }
       
        private void ShowRandomImages()
        {
            foreach (var pictureBox in pictureBoxes)
            {
                if (!filesToShow.Any())
                    filesToShow = GetFilesToShow();

                    int index = random.Next(0, filesToShow.Count);
                    string fileToShow = filesToShow[index];
                    filesToShow2.Add(fileToShow);
                    filesToShow.RemoveAt(index); // avoid duplicates
            }
            
        }
        private List<string> GetFilesToShow()
        {
            return Directory.GetFiles(path, "*.png" , SearchOption.TopDirectoryOnly)
                            .ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dictionary[control1].image == dictionary[control2].image)
            {
                control1.ImageLocation = dictionary[control1].image;
                control2.ImageLocation = dictionary[control2].image;
                control1.Enabled = false;
                control2.Enabled = false;
                tries += 1;
                matches += 1;
                if(matches == 12)
                {
                    this.Hide();
                    Form3 form3 = new Form3(time, tries);
                    form3.Show();
                }
            }
            else
            {
                control1.Image = null;
                control2.Image = null;
                tries += 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ShowRandomImages();
                card1.addImage(filesToShow2[0]);
                card2.addImage(filesToShow2[1]);
                card3.addImage(filesToShow2[2]);
                card4.addImage(filesToShow2[3]);
                card5.addImage(filesToShow2[4]);
                card6.addImage(filesToShow2[5]);
                card7.addImage(filesToShow2[6]);
                card8.addImage(filesToShow2[7]);
                card9.addImage(filesToShow2[8]);
                card10.addImage(filesToShow2[9]);
                card11.addImage(filesToShow2[10]);
                card12.addImage(filesToShow2[11]);
                card13.addImage(filesToShow2[12]);
                card14.addImage(filesToShow2[13]);
                card15.addImage(filesToShow2[14]);
                card16.addImage(filesToShow2[15]);
                card17.addImage(filesToShow2[16]);
                card18.addImage(filesToShow2[17]);
                card19.addImage(filesToShow2[18]);
                card20.addImage(filesToShow2[19]);
                card21.addImage(filesToShow2[20]);
                card22.addImage(filesToShow2[21]);
                card23.addImage(filesToShow2[22]);
                card24.addImage(filesToShow2[23]);

                dictionary.Add(pictureBox1, card1); dictionary.Add(pictureBox9, card9); dictionary.Add(pictureBox17, card17);
                dictionary.Add(pictureBox2, card2); dictionary.Add(pictureBox10, card10); dictionary.Add(pictureBox18, card18);
                dictionary.Add(pictureBox3, card3); dictionary.Add(pictureBox11, card11); dictionary.Add(pictureBox19, card19);
                dictionary.Add(pictureBox4, card4); dictionary.Add(pictureBox12, card12); dictionary.Add(pictureBox20, card20);
                dictionary.Add(pictureBox5, card5); dictionary.Add(pictureBox13, card13); dictionary.Add(pictureBox21, card21);
                dictionary.Add(pictureBox6, card6); dictionary.Add(pictureBox14, card14); dictionary.Add(pictureBox22, card22);
                dictionary.Add(pictureBox7, card7); dictionary.Add(pictureBox15, card15); dictionary.Add(pictureBox23, card23);
                dictionary.Add(pictureBox8, card8); dictionary.Add(pictureBox16, card16); dictionary.Add(pictureBox24, card24);
                timer1.Start();
            }
            catch(Exception excep)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }
        
        private void pictureBox23_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }
        private void pictureBox24_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
            counter += 1;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time += 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog b = new FolderBrowserDialog();

            if (b.ShowDialog() == DialogResult.OK)
            {
                path = b.SelectedPath;
                if (Directory.GetFiles(path, "*.png", SearchOption.TopDirectoryOnly)
                            .ToList().Capacity < 12)

                    MessageBox.Show("Images less than 12");
                else if (Directory.GetFiles(path, "*.png", SearchOption.TopDirectoryOnly)
                                .ToList().Capacity > 12)
                    MessageBox.Show("Images more than 12");
            }
            else
            {

            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf2 = new BinaryFormatter();
            Stream st2 = new FileStream("players.txt", FileMode.OpenOrCreate);
            try
            {
                while (true)
                {
                    Player p = (Player)bf2.Deserialize(st2);

                   //MessageBox.Show(p.time + " " + p.tries + " " + p.name);
                    player++;

                }
            }
            catch (Exception exc)
            {
                st2.Close();
            }

            this.Hide();
            Form2 form2 = new Form2(player);
            form2.Show();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void topScorersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.PerformClick();
        }

        private void imagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }
    }
}
