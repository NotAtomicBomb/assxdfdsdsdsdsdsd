using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookworm_Adventures
{
    public partial class Form1 : Form
    {
        //Variables and stuff
        string[] words = System.IO.File.ReadAllLines(@"H:\Profile\Desktop\Bookworm Adventures\Bookworm Adventures\bin\Debug\wordness.txt");
        string[] upletters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string[] rndletters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "QU" };
        string[] lowletters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        double[] weights = new double[] { 1, 1.25, 1.25, 1, 1, 1.25, 1, 1.25, 1, 1.75, 1.75, 1, 1.25, 1, 1, 1.25, 1.75, 1, 1, 1, 1, 1.5, 1.5, 2, 1.5, 2 };
        List<string> wordList = new List<string>();
        public Button[] buttons = new Button[17];
        public Random random = new Random();
        public int rnd, turn = 1;
        public string currentLetter;
        public double p1Health = 20, p2Health = 20, wordWeight = 0, attackStrength;
        public bool[] used = new bool[17];
        public bool[] amethyst = new bool[20];
        public bool[] emerald = new bool[20];
        public bool[] saphire = new bool[20];
        public bool[] garnet = new bool[20];
        public bool[] ruby = new bool[20];
        public bool[] crystal = new bool[20];
        public bool[] diamond = new bool[20];
        public string word;
        public bool attackButtonOnOff = false;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < words.Length; i++)
            {
                wordList.Add(words[i]);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setting up things
            label1.Text = p1Health.ToString();
            label2.Text = p2Health.ToString();
            attackWord.Text = "";
            for (int i = 1; i <= 16; i++)
            {
                used[i] = true;
            }
            buttons[1] = button1;
            buttons[2] = button2;
            buttons[3] = button3;
            buttons[4] = button4;
            buttons[5] = button5;
            buttons[6] = button6;
            buttons[7] = button7;
            buttons[8] = button8;
            buttons[9] = button9;
            buttons[10] = button10;
            buttons[11] = button11;
            buttons[12] = button12;
            buttons[13] = button13;
            buttons[14] = button14;
            buttons[15] = button15;
            buttons[16] = button16;

            Letter_Gen();
        }

        private void Letter_Gen()
        {//Generate letters only for tiles used last turn
            for (int i = 1; i <= 16; i++)
            {
                if (used[i] == true)
                {
                    rnd = random.Next(0, 26);
                    buttons[i].Text = rndletters[rnd];


                }



            }




            wordReset();
        }

        private void wordReset()
        {
            //Resets the word, used very often
            attackWord.Text = "";
            for (int i = 1; i <= 16; i++)
            {
                used[i] = false;
            }
            wordWeight = 0;
            attackButtonOff();
        }

        private void attackButtonOff()
        {
            //Sets the attack button to off
            attackButton.BackColor = Color.Maroon;
            attackButton.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Letter tile 1
            if (used[1] != true)
            {
                attackWord.Text = attackWord.Text + button1.Text;
                used[1] = true;
                wordUpdate();
            }
        }

        private void wordUpdate()
        {
            //Check for a real word
            word = attackWord.Text;
            word = word.ToLower();
            for (int i = 0; i < wordList.Count; i++)
            {
                if (word != wordList[i])
                {
                    attackButtonOff();
                    attackButtonOnOff = false;
                }
                if (word == wordList[i] )
                {
                    if (word.Length > 2)
                    {
                        attackButtonOn();
                        attackButtonOnOff = true;
                        for (int k = 0; k < word.Length; k++)
                        {
                            currentLetter = word.Substring(k, 1);
                            for (int frick = 0; frick < upletters.Length; frick++)
                            {
                                if (currentLetter == upletters[frick] || currentLetter == lowletters[frick])
                                {
                                    wordWeight = wordWeight + weights[frick];
                                    i = 7656119;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void addGemAmethyst()
        {
            //Add amethyst gem to a random tile
            rnd = random.Next(1, 17);
            if (rnd == 1)
            {
                button1.BackColor = Color.Purple;
                amethyst[1] = true;
            }
            if (rnd == 2)
            {
                button2.BackColor = Color.Purple;
                amethyst[2] = true;
            }
            if (rnd == 3)
            {
                button3.BackColor = Color.Purple;
                amethyst[3] = true;
            }
            if (rnd == 4)
            {
                button4.BackColor = Color.Purple;
                amethyst[4] = true;
            }
            if (rnd == 5)
            {
                button5.BackColor = Color.Purple;
                amethyst[5] = true;
            }
            if (rnd == 6)
            {
                button6.BackColor = Color.Purple;
                amethyst[6] = true;
            }
            if (rnd == 7)
            {
                button7.BackColor = Color.Purple;
                amethyst[7] = true;
            }
            if (rnd == 8)
            {
                button8.BackColor = Color.Purple;
                amethyst[8] = true;
            }
            if (rnd == 9)
            {
                button9.BackColor = Color.Purple;
                amethyst[9] = true;
            }
            if (rnd == 10)
            {
                button10.BackColor = Color.Purple;
                amethyst[10] = true;
            }
            if (rnd == 11)
            {
                button11.BackColor = Color.Purple;
                amethyst[11] = true;
            }
            if (rnd == 12)
            {
                button12.BackColor = Color.Purple;
                amethyst[12] = true;
            }
            if (rnd == 13)
            {
                button13.BackColor = Color.Purple;
                amethyst[13] = true;
            }
            if (rnd == 14)
            {
                button14.BackColor = Color.Purple;
                amethyst[14] = true;
            }
            if (rnd == 15)
            {
                button15.BackColor = Color.Purple;
                amethyst[15] = true;
            }
            if (rnd == 16)
            {
                button16.BackColor = Color.Purple;
                amethyst[16] = true;
            }
        }

        private void attackButtonOn()
        {
            //Switch the attack button to on
            wordWeight = 0;
            attackButtonOnOff = false;
            attackButton.BackColor = Color.Lime;
            attackButton.ForeColor = Color.Black;
        }

        private void scramble_Click(object sender, EventArgs e)
        {
            //Change all letters and change the turn
            for (int i = 1; i <= 16; i++)
            {
                used[i] = true;
            }
            Letter_Gen();
            if (turn == 1)
            {
                turn = 2;
            }
            else if (turn == 2)
            {
                turn = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Letter tile 2
            if (used[2] != true)
            {
                attackWord.Text = attackWord.Text + button2.Text;
                used[2] = true;
                wordUpdate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Letter tile 3
            if (used[3] != true)
            {
                attackWord.Text = attackWord.Text + button3.Text;
                used[3] = true;
                wordUpdate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Letter tile 4
            if (used[4] != true)
            {
                attackWord.Text = attackWord.Text + button4.Text;
                used[4] = true;
                wordUpdate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Letter tile 5
            if (used[5] != true)
            {
                attackWord.Text = attackWord.Text + button5.Text;
                used[5] = true;
                wordUpdate();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Letter tile 6
            if (used[6] != true)
            {
                attackWord.Text = attackWord.Text + button6.Text;
                used[6] = true;
                wordUpdate();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Letter tile 7
            if (used[7] != true)
            {
                attackWord.Text = attackWord.Text + button7.Text;
                used[7] = true;
                wordUpdate();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Letter tile 8
            if (used[8] != true)
            {
                attackWord.Text = attackWord.Text + button8.Text;
                used[8] = true;
                wordUpdate();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Letter tile 9
            if (used[9] != true)
            {
                attackWord.Text = attackWord.Text + button9.Text;
                used[9] = true;
                wordUpdate();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Letter tile 10
            if (used[10] != true)
            {
                attackWord.Text = attackWord.Text + button10.Text;
                used[10] = true;
                wordUpdate();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Letter tile 11
            if (used[11] != true)
            {
                attackWord.Text = attackWord.Text + button11.Text;
                used[11] = true;
                wordUpdate();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Letter tile 12
            if (used[12] != true)
            {
                attackWord.Text = attackWord.Text + button12.Text;
                used[12] = true;
                wordUpdate();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Letter tile 13
            if (used[13] != true)
            {
                attackWord.Text = attackWord.Text + button13.Text;
                used[13] = true;
                wordUpdate();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //Letter tile 14
            if (used[14] != true)
            {
                attackWord.Text = attackWord.Text + button14.Text;
                used[14] = true;
                wordUpdate();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Letter tile 15
            if (used[15] != true)
            {
                attackWord.Text = attackWord.Text + button15.Text;
                used[15] = true;
                wordUpdate();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Letter tile 16
            if (used[16] != true)
            {
                attackWord.Text = attackWord.Text + button16.Text;
                used[16] = true;
                wordUpdate();
            }
        }

        private void resetWord_Click(object sender, EventArgs e)
        {
            //Literally just resets the word
            wordReset();
        }

        private void attackButton_Click(object sender, EventArgs e)
        {
            //Check if the word is valid and the attack button is on
            if (attackButtonOnOff == true)
            {
                attackStrength = wordWeight;
                //Amethyst calculations
                if (attackStrength > 0)
                {
                    if (used[1] == true && amethyst[1] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[1] = false;
                        buttons[1].BackColor = Color.Transparent;
                    }
                    if (used[2] == true && amethyst[2] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[2] = false;
                        buttons[2].BackColor = Color.Transparent;
                    }
                    if (used[3] == true && amethyst[3] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[3] = false;
                        buttons[3].BackColor = Color.Transparent;
                    }
                    if (used[4] == true && amethyst[4] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[4] = false;
                        buttons[4].BackColor = Color.Transparent;
                    }
                    if (used[5] == true && amethyst[5] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[5] = false;
                        buttons[5].BackColor = Color.Transparent;
                    }
                    if (used[6] == true && amethyst[6] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[6] = false;
                        buttons[6].BackColor = Color.Transparent;
                    }
                    if (used[7] == true && amethyst[7] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[7] = false;
                        buttons[7].BackColor = Color.Transparent;
                    }
                    if (used[8] == true && amethyst[8] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[8] = false;
                        buttons[8].BackColor = Color.Transparent;
                    }
                    if (used[9] == true && amethyst[9] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[9] = false;
                        buttons[9].BackColor = Color.Transparent;
                    }
                    if (used[10] == true && amethyst[10] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[10] = false;
                        buttons[10].BackColor = Color.Transparent;
                    }
                    if (used[11] == true && amethyst[11] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[11] = false;
                        buttons[11].BackColor = Color.Transparent;
                    }
                    if (used[12] == true && amethyst[12] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[12] = false;
                        buttons[12].BackColor = Color.Transparent;
                    }
                    if (used[13] == true && amethyst[13] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[13] = false;
                        buttons[13].BackColor = Color.Transparent;
                    }
                    if (used[14] == true && amethyst[14] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[14] = false;
                        buttons[14].BackColor = Color.Transparent;
                    }
                    if (used[15] == true && amethyst[15] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[15] = false;
                        buttons[15].BackColor = Color.Transparent;
                    }
                    if (used[16] == true && amethyst[16] == true)
                    {
                        attackStrength = attackStrength * 1.15;
                        amethyst[16] = false;
                        buttons[16].BackColor = Color.Transparent;
                    }
                    //Emerald calculations
                    if (used[1] == true && emerald[1] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[1] = false;
                        buttons[1].BackColor = Color.Transparent;
                    }
                    if (used[2] == true && emerald[2] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[2] = false;
                        buttons[2].BackColor = Color.Transparent;
                    }
                    if (used[3] == true && emerald[3] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[3] = false;
                        buttons[3].BackColor = Color.Transparent;
                    }
                    if (used[4] == true && emerald[4] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[4] = false;
                        buttons[4].BackColor = Color.Transparent;
                    }
                    if (used[5] == true && emerald[5] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[5] = false;
                        buttons[5].BackColor = Color.Transparent;
                    }
                    if (used[6] == true && emerald[6] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[6] = false;
                        buttons[6].BackColor = Color.Transparent;
                    }
                    if (used[7] == true && emerald[7] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[7] = false;
                        buttons[7].BackColor = Color.Transparent;
                    }
                    if (used[8] == true && emerald[8] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[8] = false;
                        buttons[8].BackColor = Color.Transparent;
                    }
                    if (used[9] == true && emerald[9] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[9] = false;
                        buttons[9].BackColor = Color.Transparent;
                    }
                    if (used[10] == true && emerald[10] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[10] = false;
                        buttons[10].BackColor = Color.Transparent;
                    }
                    if (used[11] == true && emerald[11] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[11] = false;
                        buttons[11].BackColor = Color.Transparent;
                    }
                    if (used[12] == true && emerald[12] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[12] = false;
                        buttons[12].BackColor = Color.Transparent;
                    }
                    if (used[13] == true && emerald[13] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[13] = false;
                        buttons[13].BackColor = Color.Transparent;
                    }
                    if (used[14] == true && emerald[14] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[14] = false;
                        buttons[14].BackColor = Color.Transparent;
                    }
                    if (used[15] == true && emerald[15] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[15] = false;
                        buttons[15].BackColor = Color.Transparent;
                    }
                    if (used[16] == true && emerald[16] == true)
                    {
                        attackStrength = attackStrength * 1.20;
                        emerald[16] = false;
                        buttons[16].BackColor = Color.Transparent;
                    }
                    //Saphire calculations
                    if (used[1] == true && saphire[1] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[1] = false;
                        buttons[1].BackColor = Color.Transparent;
                    }
                    if (used[2] == true && saphire[2] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[2] = false;
                        buttons[2].BackColor = Color.Transparent;
                    }
                    if (used[3] == true && saphire[3] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[3] = false;
                        buttons[3].BackColor = Color.Transparent;
                    }
                    if (used[4] == true && saphire[4] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[4] = false;
                        buttons[4].BackColor = Color.Transparent;
                    }
                    if (used[5] == true && saphire[5] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[5] = false;
                        buttons[5].BackColor = Color.Transparent;
                    }
                    if (used[6] == true && saphire[6] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[6] = false;
                        buttons[6].BackColor = Color.Transparent;
                    }
                    if (used[7] == true && saphire[7] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[7] = false;
                        buttons[7].BackColor = Color.Transparent;
                    }
                    if (used[8] == true && saphire[8] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[8] = false;
                        buttons[8].BackColor = Color.Transparent;
                    }
                    if (used[9] == true && saphire[9] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[9] = false;
                        buttons[9].BackColor = Color.Transparent;
                    }
                    if (used[10] == true && saphire[10] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[10] = false;
                        buttons[10].BackColor = Color.Transparent;
                    }
                    if (used[11] == true && saphire[11] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[11] = false;
                        buttons[11].BackColor = Color.Transparent;
                    }
                    if (used[12] == true && saphire[12] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[12] = false;
                        buttons[12].BackColor = Color.Transparent;
                    }
                    if (used[13] == true && saphire[13] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[13] = false;
                        buttons[13].BackColor = Color.Transparent;
                    }
                    if (used[14] == true && saphire[14] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[14] = false;
                        buttons[14].BackColor = Color.Transparent;
                    }
                    if (used[15] == true && saphire[15] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[15] = false;
                        buttons[15].BackColor = Color.Transparent;
                    }
                    if (used[16] == true && saphire[16] == true)
                    {
                        attackStrength = attackStrength * 1.25;
                        saphire[16] = false;
                        buttons[16].BackColor = Color.Transparent;
                    }
                    //Garnet calculations
                    if (used[1] == true && garnet[1] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[1] = false;
                        buttons[1].BackColor = Color.Transparent;
                    }
                    if (used[2] == true && garnet[2] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[2] = false;
                        buttons[2].BackColor = Color.Transparent;
                    }
                    if (used[3] == true && garnet[3] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[3] = false;
                        buttons[3].BackColor = Color.Transparent;
                    }
                    if (used[4] == true && garnet[4] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[4] = false;
                        buttons[4].BackColor = Color.Transparent;
                    }
                    if (used[5] == true && garnet[5] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[5] = false;
                        buttons[5].BackColor = Color.Transparent;
                    }
                    if (used[6] == true && garnet[6] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[6] = false;
                        buttons[6].BackColor = Color.Transparent;
                    }
                    if (used[7] == true && garnet[7] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[7] = false;
                        buttons[7].BackColor = Color.Transparent;
                    }
                    if (used[8] == true && garnet[8] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[8] = false;
                        buttons[8].BackColor = Color.Transparent;
                    }
                    if (used[9] == true && garnet[9] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[9] = false;
                        buttons[9].BackColor = Color.Transparent;
                    }
                    if (used[10] == true && garnet[10] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[10] = false;
                        buttons[10].BackColor = Color.Transparent;
                    }
                    if (used[11] == true && garnet[11] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[11] = false;
                        buttons[11].BackColor = Color.Transparent;
                    }
                    if (used[12] == true && garnet[12] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[12] = false;
                        buttons[12].BackColor = Color.Transparent;
                    }
                    if (used[13] == true && garnet[13] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[13] = false;
                        buttons[13].BackColor = Color.Transparent;
                    }
                    if (used[14] == true && garnet[14] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[14] = false;
                        buttons[14].BackColor = Color.Transparent;
                    }
                    if (used[15] == true && garnet[15] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[15] = false;
                        buttons[15].BackColor = Color.Transparent;
                    }
                    if (used[16] == true && garnet[16] == true)
                    {
                        attackStrength = attackStrength * 1.30;
                        garnet[16] = false;
                        buttons[16].BackColor = Color.Transparent;
                    }
                    //Ruby calculations
                    if (used[1] == true && ruby[1] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[1] = false;
                        buttons[1].BackColor = Color.Transparent;
                    }
                    if (used[2] == true && ruby[2] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[2] = false;
                        buttons[2].BackColor = Color.Transparent;
                    }
                    if (used[3] == true && ruby[3] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[3] = false;
                        buttons[3].BackColor = Color.Transparent;
                    }
                    if (used[4] == true && ruby[4] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[4] = false;
                        buttons[4].BackColor = Color.Transparent;
                    }
                    if (used[5] == true && ruby[5] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[5] = false;
                        buttons[5].BackColor = Color.Transparent;
                    }
                    if (used[6] == true && ruby[6] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[6] = false;
                        buttons[6].BackColor = Color.Transparent;
                    }
                    if (used[7] == true && ruby[7] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[7] = false;
                        buttons[7].BackColor = Color.Transparent;
                    }
                    if (used[8] == true && ruby[8] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[8] = false;
                        buttons[8].BackColor = Color.Transparent;
                    }
                    if (used[9] == true && ruby[9] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[9] = false;
                        buttons[9].BackColor = Color.Transparent;
                    }
                    if (used[10] == true && ruby[10] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[10] = false;
                        buttons[10].BackColor = Color.Transparent;
                    }
                    if (used[11] == true && ruby[11] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[11] = false;
                        buttons[11].BackColor = Color.Transparent;
                    }
                    if (used[12] == true && ruby[12] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[12] = false;
                        buttons[12].BackColor = Color.Transparent;
                    }
                    if (used[13] == true && ruby[13] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[13] = false;
                        buttons[13].BackColor = Color.Transparent;
                    }
                    if (used[14] == true && ruby[14] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[14] = false;
                        buttons[14].BackColor = Color.Transparent;
                    }
                    if (used[15] == true && ruby[15] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[15] = false;
                        buttons[15].BackColor = Color.Transparent;
                    }
                    if (used[16] == true && ruby[16] == true)
                    {
                        attackStrength = attackStrength * 1.35;
                        ruby[16] = false;
                        buttons[16].BackColor = Color.Transparent;
                    }
                    //Crystal calculations
                    if (used[1] == true && crystal[1] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[1] = false;
                        buttons[1].BackColor = Color.Transparent;
                    }
                    if (used[2] == true && crystal[2] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[2] = false;
                        buttons[2].BackColor = Color.Transparent;
                    }
                    if (used[3] == true && crystal[3] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[3] = false;
                        buttons[3].BackColor = Color.Transparent;
                    }
                    if (used[4] == true && crystal[4] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[4] = false;
                        buttons[4].BackColor = Color.Transparent;
                    }
                    if (used[5] == true && crystal[5] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[5] = false;
                        buttons[5].BackColor = Color.Transparent;
                    }
                    if (used[6] == true && crystal[6] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[6] = false;
                        buttons[6].BackColor = Color.Transparent;
                    }
                    if (used[7] == true && crystal[7] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[7] = false;
                        buttons[7].BackColor = Color.Transparent;
                    }
                    if (used[8] == true && crystal[8] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[8] = false;
                        buttons[8].BackColor = Color.Transparent;
                    }
                    if (used[9] == true && crystal[9] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[9] = false;
                        buttons[9].BackColor = Color.Transparent;
                    }
                    if (used[10] == true && crystal[10] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[10] = false;
                        buttons[10].BackColor = Color.Transparent;
                    }
                    if (used[11] == true && crystal[11] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[11] = false;
                        buttons[11].BackColor = Color.Transparent;
                    }
                    if (used[12] == true && crystal[12] == true)
                    {

                        attackStrength = attackStrength * 1.50;
                        crystal[12] = false;
                        buttons[12].BackColor = Color.Transparent;
                    }
                    if (used[13] == true && crystal[13] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[13] = false;
                        buttons[13].BackColor = Color.Transparent;
                    }
                    if (used[14] == true && crystal[14] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[14] = false;
                        buttons[14].BackColor = Color.Transparent;
                    }
                    if (used[15] == true && crystal[15] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[15] = false;
                        buttons[15].BackColor = Color.Transparent;
                    }
                    if (used[16] == true && crystal[16] == true)
                    {
                        attackStrength = attackStrength * 1.50;
                        crystal[16] = false;
                        buttons[16].BackColor = Color.Transparent;
                    }
                    //Diamond calculations
                    if (used[1] == true && diamond[1] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[1] = false;
                        buttons[1].BackColor = Color.Transparent;
                    }
                    if (used[2] == true && diamond[2] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[2] = false;
                        buttons[2].BackColor = Color.Transparent;
                    }
                    if (used[3] == true && diamond[3] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[3] = false;
                        buttons[3].BackColor = Color.Transparent;
                    }
                    if (used[4] == true && diamond[4] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[4] = false;
                        buttons[4].BackColor = Color.Transparent;
                    }
                    if (used[5] == true && diamond[5] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[5] = false;
                        buttons[5].BackColor = Color.Transparent;
                    }
                    if (used[6] == true && diamond[6] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[6] = false;
                        buttons[6].BackColor = Color.Transparent;
                    }
                    if (used[7] == true && diamond[7] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[7] = false;
                        buttons[7].BackColor = Color.Transparent;
                    }
                    if (used[8] == true && diamond[8] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[8] = false;
                        buttons[8].BackColor = Color.Transparent;
                    }
                    if (used[9] == true && diamond[9] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[9] = false;
                        buttons[9].BackColor = Color.Transparent;
                    }
                    if (used[10] == true && diamond[10] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[10] = false;
                        buttons[10].BackColor = Color.Transparent;
                    }
                    if (used[11] == true && diamond[11] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[11] = false;
                        buttons[11].BackColor = Color.Transparent;
                    }
                    if (used[12] == true && diamond[12] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[12] = false;
                        buttons[12].BackColor = Color.Transparent;
                    }
                    if (used[13] == true && diamond[13] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[13] = false;
                        buttons[13].BackColor = Color.Transparent;
                    }
                    if (used[14] == true && diamond[14] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[14] = false;
                        buttons[14].BackColor = Color.Transparent;
                    }
                    if (used[15] == true && diamond[15] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[15] = false;
                        buttons[15].BackColor = Color.Transparent;
                    }
                    if (used[16] == true && diamond[16] == true)
                    {
                        attackStrength = attackStrength * 2;
                        diamond[16] = false;
                        buttons[16].BackColor = Color.Transparent;

                    }
                }
                //Gem addition
                if (attackStrength > 0)
                {
                    if (word.Length == 5)
                    {
                        addGemAmethyst();
                    }
                    if (word.Length == 6)
                    {
                        addGemEmerald();
                    }
                    if (word.Length == 7)
                    {
                        addGemSaphire();
                    }
                    if (word.Length == 8)
                    {
                        addGemGarnet();
                    }
                    if (word.Length == 9)
                    {
                        addGemRuby();
                    }
                    if (word.Length == 10)
                    {
                        addGemCrystal();
                    }
                    if (word.Length >= 11)
                    {
                        addGemDiamond();
                    }
                }
                //Actual damage dealing
                if (turn == 1)
                {
                    p2Health = p2Health - attackStrength;
                    label2.Text = p2Health.ToString();
                    turn = 2;
                }
                else if (turn == 2)
                {
                    p1Health = p1Health - attackStrength;
                    label1.Text = p1Health.ToString();
                    turn = 1;
                }
                Letter_Gen();
            }
        }

        private void addGemDiamond()
        {
            //Add diamond gem to a random tile
            rnd = random.Next(1, 17);
            if (rnd == 1)
            {
                button1.BackColor = Color.Cyan;
                diamond[1] = true;
            }
            if (rnd == 2)
            {
                button2.BackColor = Color.Cyan;
                diamond[2] = true;
            }
            if (rnd == 3)
            {
                button3.BackColor = Color.Cyan;
                diamond[3] = true;
            }
            if (rnd == 4)
            {
                button4.BackColor = Color.Cyan;
                diamond[4] = true;
            }
            if (rnd == 5)
            {
                button5.BackColor = Color.Cyan;
                diamond[5] = true;
            }
            if (rnd == 6)
            {
                button6.BackColor = Color.Cyan;
                diamond[6] = true;
            }
            if (rnd == 7)
            {
                button7.BackColor = Color.Cyan;
                diamond[7] = true;
            }
            if (rnd == 8)
            {
                button8.BackColor = Color.Cyan;
                diamond[8] = true;
            }
            if (rnd == 9)
            {
                button9.BackColor = Color.Cyan;
                diamond[9] = true;
            }
            if (rnd == 10)
            {
                button10.BackColor = Color.Cyan;
                diamond[10] = true;
            }
            if (rnd == 11)
            {
                button11.BackColor = Color.Cyan;
                diamond[11] = true;
            }
            if (rnd == 12)
            {
                button12.BackColor = Color.Cyan;
                diamond[12] = true;
            }
            if (rnd == 13)
            {
                button13.BackColor = Color.Cyan;
                diamond[13] = true;
            }
            if (rnd == 14)
            {
                button14.BackColor = Color.Cyan;
                diamond[14] = true;
            }
            if (rnd == 15)
            {
                button15.BackColor = Color.Cyan;
                diamond[15] = true;
            }
            if (rnd == 16)
            {
                button16.BackColor = Color.Cyan;
                diamond[16] = true;
            }
        }

        private void addGemCrystal()
        {
            //Add crystal gem to a random tile
            rnd = random.Next(1, 17);
            if (rnd == 1)
            {
                button1.BackColor = Color.Pink;
                crystal[1] = true;
            }
            if (rnd == 2)
            {
                button2.BackColor = Color.Pink;
                crystal[2] = true;
            }
            if (rnd == 3)
            {
                button3.BackColor = Color.Pink;
                crystal[3] = true;
            }
            if (rnd == 4)
            {
                button4.BackColor = Color.Pink;
                crystal[4] = true;
            }
            if (rnd == 5)
            {
                button5.BackColor = Color.Pink;
                crystal[5] = true;
            }
            if (rnd == 6)
            {
                button6.BackColor = Color.Pink;
                crystal[6] = true;
            }
            if (rnd == 7)
            {
                button7.BackColor = Color.Pink;
                crystal[7] = true;
            }
            if (rnd == 8)
            {
                button8.BackColor = Color.Pink;
                crystal[8] = true;
            }
            if (rnd == 9)
            {
                button9.BackColor = Color.Pink;
                crystal[9] = true;
            }
            if (rnd == 10)
            {
                button10.BackColor = Color.Pink;
                crystal[10] = true;
            }
            if (rnd == 11)
            {
                button11.BackColor = Color.Pink;
                crystal[11] = true;
            }
            if (rnd == 12)
            {
                button12.BackColor = Color.Pink;
                crystal[12] = true;
            }
            if (rnd == 13)
            {
                button13.BackColor = Color.Pink;
                crystal[13] = true;
            }
            if (rnd == 14)
            {
                button14.BackColor = Color.Pink;
                crystal[14] = true;
            }
            if (rnd == 15)
            {
                button15.BackColor = Color.Pink;
                crystal[15] = true;
            }
            if (rnd == 16)
            {
                button16.BackColor = Color.Pink;
                crystal[16] = true;
            }
        }

        private void addGemRuby()
        {
            //Add ruby gem to a random tile
            rnd = random.Next(1, 17);
            if (rnd == 1)
            {
                button1.BackColor = Color.Red;
                ruby[1] = true;
            }
            if (rnd == 2)
            {
                button2.BackColor = Color.Red;
                ruby[2] = true;
            }
            if (rnd == 3)
            {
                button3.BackColor = Color.Red;
                ruby[3] = true;
            }
            if (rnd == 4)
            {
                button4.BackColor = Color.Red;
                ruby[4] = true;
            }
            if (rnd == 5)
            {
                button5.BackColor = Color.Red;
                ruby[5] = true;
            }
            if (rnd == 6)
            {
                button6.BackColor = Color.Red;
                ruby[6] = true;
            }
            if (rnd == 7)
            {
                button7.BackColor = Color.Red;
                ruby[7] = true;
            }
            if (rnd == 8)
            {
                button8.BackColor = Color.Red;
                ruby[8] = true;
            }
            if (rnd == 9)
            {
                button9.BackColor = Color.Red;
                ruby[9] = true;
            }
            if (rnd == 10)
            {
                button10.BackColor = Color.Red;
                ruby[10] = true;
            }
            if (rnd == 11)
            {
                button11.BackColor = Color.Red;
                ruby[11] = true;
            }
            if (rnd == 12)
            {
                button12.BackColor = Color.Red;
                ruby[12] = true;
            }
            if (rnd == 13)
            {
                button13.BackColor = Color.Red;
                ruby[13] = true;
            }
            if (rnd == 14)
            {
                button14.BackColor = Color.Red;
                ruby[14] = true;
            }
            if (rnd == 15)
            {
                button15.BackColor = Color.Red;
                ruby[15] = true;
            }
            if (rnd == 16)
            {
                button16.BackColor = Color.Red;
                ruby[16] = true;
            }
        }

        private void addGemGarnet()
        {
            //Add garnet gem to a random tile
            rnd = random.Next(1, 17);
            if (rnd == 1)
            {
                button1.BackColor = Color.Orange;
                garnet[1] = true;
            }
            if (rnd == 2)
            {
                button2.BackColor = Color.Orange;
                garnet[2] = true;
            }
            if (rnd == 3)
            {
                button3.BackColor = Color.Orange;
                garnet[3] = true;
            }
            if (rnd == 4)
            {
                button4.BackColor = Color.Orange;
                garnet[4] = true;
            }
            if (rnd == 5)
            {
                button5.BackColor = Color.Orange;
                garnet[5] = true;
            }
            if (rnd == 6)
            {
                button6.BackColor = Color.Orange;
                garnet[6] = true;
            }
            if (rnd == 7)
            {
                button7.BackColor = Color.Orange;
                garnet[7] = true;
            }
            if (rnd == 8)
            {
                button8.BackColor = Color.Orange;
                garnet[8] = true;
            }
            if (rnd == 9)
            {
                button9.BackColor = Color.Orange;
                garnet[9] = true;
            }
            if (rnd == 10)
            {
                button10.BackColor = Color.Orange;
                garnet[10] = true;
            }
            if (rnd == 11)
            {
                button11.BackColor = Color.Orange;
                garnet[11] = true;
            }
            if (rnd == 12)
            {
                button12.BackColor = Color.Orange;
                garnet[12] = true;
            }
            if (rnd == 13)
            {
                button13.BackColor = Color.Orange;
                garnet[13] = true;
            }
            if (rnd == 14)
            {
                button14.BackColor = Color.Orange;
                garnet[14] = true;
            }
            if (rnd == 15)
            {
                button15.BackColor = Color.Orange;
                garnet[15] = true;
            }
            if (rnd == 16)
            {
                button16.BackColor = Color.Orange;
                garnet[16] = true;
            }
        }

        private void addGemSaphire()
        {
            //Add saphire gem to a random tile
            rnd = random.Next(1, 17);
            if (rnd == 1)
            {
                button1.BackColor = Color.Blue;
                saphire[1] = true;
            }
            if (rnd == 2)
            {
                button2.BackColor = Color.Blue;
                saphire[2] = true;
            }
            if (rnd == 3)
            {
                button3.BackColor = Color.Blue;
                saphire[3] = true;
            }
            if (rnd == 4)
            {
                button4.BackColor = Color.Blue;
                saphire[4] = true;
            }
            if (rnd == 5)
            {
                button5.BackColor = Color.Blue;
                saphire[5] = true;
            }
            if (rnd == 6)
            {
                button6.BackColor = Color.Blue;
                saphire[6] = true;
            }
            if (rnd == 7)
            {
                button7.BackColor = Color.Blue;
                saphire[7] = true;
            }
            if (rnd == 8)
            {
                button8.BackColor = Color.Blue;
                saphire[8] = true;
            }
            if (rnd == 9)
            {
                button9.BackColor = Color.Blue;
                saphire[9] = true;
            }
            if (rnd == 10)
            {
                button10.BackColor = Color.Blue;
                saphire[10] = true;
            }
            if (rnd == 11)
            {
                button11.BackColor = Color.Blue;
                saphire[11] = true;
            }
            if (rnd == 12)
            {
                button12.BackColor = Color.Blue;
                saphire[12] = true;
            }
            if (rnd == 13)
            {
                button13.BackColor = Color.Blue;
                saphire[13] = true;
            }
            if (rnd == 14)
            {
                button14.BackColor = Color.Blue;
                saphire[14] = true;
            }
            if (rnd == 15)
            {
                button15.BackColor = Color.Blue;
                saphire[15] = true;
            }
            if (rnd == 16)
            {
                button16.BackColor = Color.Blue;
                saphire[16] = true;
            }
        }

        private void addGemEmerald()
        {
            //Add emerald gem to a random tile
            rnd = random.Next(1, 17);
            if (rnd == 1)
            {
                button1.BackColor = Color.Lime;
                emerald[1] = true;
            }
            if (rnd == 2)
            {
                button2.BackColor = Color.Lime;
                emerald[2] = true;
            }
            if (rnd == 3)
            {
                button3.BackColor = Color.Lime;
                emerald[3] = true;
            }
            if (rnd == 4)
            {
                button4.BackColor = Color.Lime;
                emerald[4] = true;
            }
            if (rnd == 5)
            {
                button5.BackColor = Color.Lime;
                emerald[5] = true;
            }
            if (rnd == 6)
            {
                button6.BackColor = Color.Lime;
                emerald[6] = true;
            }
            if (rnd == 7)
            {
                button7.BackColor = Color.Lime;
                emerald[7] = true;
            }
            if (rnd == 8)
            {
                button8.BackColor = Color.Lime;
                emerald[8] = true;
            }
            if (rnd == 9)
            {
                button9.BackColor = Color.Lime;
                emerald[9] = true;
            }
            if (rnd == 10)
            {
                button10.BackColor = Color.Lime;
                emerald[10] = true;
            }
            if (rnd == 11)
            {
                button11.BackColor = Color.Lime;
                emerald[11] = true;
            }
            if (rnd == 12)
            {
                button12.BackColor = Color.Lime;
                emerald[12] = true;
            }
            if (rnd == 13)
            {
                button13.BackColor = Color.Lime;
                emerald[13] = true;
            }
            if (rnd == 14)
            {
                button14.BackColor = Color.Lime;
                emerald[14] = true;
            }
            if (rnd == 15)
            {
                button15.BackColor = Color.Lime;
                emerald[15] = true;
            }
            if (rnd == 16)
            {
                button16.BackColor = Color.Lime;
                emerald[16] = true;
            }
        }
    }
}
