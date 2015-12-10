using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcheesi
{
    public partial class Form1 : Form
    {
        int counter = 1;
        int diceRoll = 0;
        int diceRoll2 = 0;
        int moves1, moves2, moves3, chosenMove, finisher, turn;
        PictureBox[] sharedGrid = new PictureBox[52];
        PictureBox[] redGrid = new PictureBox[49];
        PictureBox[] blueGrid = new PictureBox[49];
        PictureBox[] yellowGrid = new PictureBox[49];
        PictureBox[] greenGrid = new PictureBox[49];
        Player red, blue, green, yellow;
        string[] playerArray;

        public Form1()
        {
            InitializeComponent();

            //Store pictureboxs in a generalGrid
            //The purpose of a shared grid is for easy access when creating other grids
            sharedGrid[0] = this.pictureBox3;
            sharedGrid[1] = this.pictureBox4;
            sharedGrid[2] = this.pictureBox5;
            sharedGrid[3] = this.pictureBox6;
            sharedGrid[4] = this.pictureBox7;
            sharedGrid[5] = this.pictureBox8;
            sharedGrid[6] = this.pictureBox9;
            sharedGrid[7] = this.pictureBox10;
            sharedGrid[8] = this.pictureBox11;
            sharedGrid[9] = this.pictureBox12;
            sharedGrid[10] = this.pictureBox13;
            sharedGrid[11] = this.pictureBox14;
            sharedGrid[12] = this.pictureBox15;
            sharedGrid[13] = this.pictureBox16;
            sharedGrid[14] = this.pictureBox17;
            sharedGrid[15] = this.pictureBox18;
            sharedGrid[16] = this.pictureBox19;
            sharedGrid[17] = this.pictureBox20;
            sharedGrid[18] = this.pictureBox21;
            sharedGrid[19] = this.pictureBox22;
            sharedGrid[20] = this.pictureBox23;
            sharedGrid[21] = this.pictureBox24;
            sharedGrid[22] = this.pictureBox25;
            sharedGrid[23] = this.pictureBox26;
            sharedGrid[24] = this.pictureBox27;
            sharedGrid[25] = this.pictureBox28;
            sharedGrid[26] = this.pictureBox29;
            sharedGrid[27] = this.pictureBox30;
            sharedGrid[28] = this.pictureBox31;
            sharedGrid[29] = this.pictureBox32;
            sharedGrid[30] = this.pictureBox33;
            sharedGrid[31] = this.pictureBox34;
            sharedGrid[32] = this.pictureBox35;
            sharedGrid[33] = this.pictureBox36;
            sharedGrid[34] = this.pictureBox37;
            sharedGrid[35] = this.pictureBox38;
            sharedGrid[36] = this.pictureBox39;
            sharedGrid[37] = this.pictureBox40;
            sharedGrid[38] = this.pictureBox41;
            sharedGrid[39] = this.pictureBox42;
            sharedGrid[40] = this.pictureBox43;
            sharedGrid[41] = this.pictureBox44;
            sharedGrid[42] = this.pictureBox45;
            sharedGrid[43] = this.pictureBox46;
            sharedGrid[44] = this.pictureBox47;
            sharedGrid[45] = this.pictureBox48;
            sharedGrid[46] = this.pictureBox49;
            sharedGrid[47] = this.pictureBox50;
            sharedGrid[48] = this.pictureBox51;
            sharedGrid[49] = this.pictureBox52;
            sharedGrid[50] = this.pictureBox53;
            sharedGrid[51] = this.pictureBox54;

            //Start the grid for red piece to move on
            for (int i = 0; i < 44; i++)
            {
                    redGrid[i] = sharedGrid[i];
            }
            redGrid[44] = this.pictureBox55;
            redGrid[45] = this.pictureBox56;
            redGrid[46] = this.pictureBox57;
            redGrid[47] = this.pictureBox58;
            redGrid[48] = this.pictureBox59;

            red = new Player("Red", pictureBox61, pictureBox62, pictureBox63, pictureBox64);

            label4.Text = red.finished.ToString();

            //Invisible grid with zoom box mode
            for (int i = 0; i < redGrid.Length; i++)
            {
                redGrid[i].BackColor = Color.Transparent;
                redGrid[i].SizeMode = PictureBoxSizeMode.Zoom;
            }


            //Start the grid for blue piece to move on
            for (int i = 13, j = 0; i < 52; i++, j++)
            {
                blueGrid[j] = sharedGrid[i];
            }
            for (int i = 0, j = 39; i < 5; i++, j++)
            {
                blueGrid[j] = sharedGrid[i];
            }
            blueGrid[44] = this.pictureBox77;
            blueGrid[45] = this.pictureBox78;
            blueGrid[46] = this.pictureBox79;
            blueGrid[47] = this.pictureBox80;
            blueGrid[48] = this.pictureBox81;

            blue = new Player("Blue", pictureBox76, pictureBox75, pictureBox74, pictureBox73);

            label5.Text = blue.finished.ToString();

            //Invisible grid with zoom box mode
            for (int i = 0; i < blueGrid.Length; i++)
            {
                blueGrid[i].BackColor = Color.Transparent;
                blueGrid[i].SizeMode = PictureBoxSizeMode.Zoom;
            }


            //Start the grid for green piece to move on
            for (int i = 39, j = 0; i < 52; i++, j++)
            {
                greenGrid[j] = sharedGrid[i];
            }
            for (int i = 0, j = 13; i < 31; i++, j++)
            {
                greenGrid[j] = sharedGrid[i];
            }
            greenGrid[44] = this.pictureBox86;
            greenGrid[45] = this.pictureBox85;
            greenGrid[46] = this.pictureBox84;
            greenGrid[47] = this.pictureBox83;
            greenGrid[48] = this.pictureBox82;

            green = new Player("Green", pictureBox68, pictureBox67, pictureBox66, pictureBox65);

            label7.Text = green.finished.ToString();

            //Invisible grid with zoom box mode
            for (int i = 0; i < greenGrid.Length; i++)
            {
                greenGrid[i].BackColor = Color.Transparent;
                greenGrid[i].SizeMode = PictureBoxSizeMode.Zoom;
            }


            //Start the grid for yellow piece to move on
            for (int i = 26, j = 0; i < 52; i++, j++)
            {
                yellowGrid[j] = sharedGrid[i];
            }
            for (int i = 0, j = 25; i < 18; i++, j++)
            {
                yellowGrid[j] = sharedGrid[i];
            }
            yellowGrid[44] = this.pictureBox87;
            yellowGrid[45] = this.pictureBox88;
            yellowGrid[46] = this.pictureBox89;
            yellowGrid[47] = this.pictureBox90;
            yellowGrid[48] = this.pictureBox91;

            yellow = new Player("Yellow", pictureBox72, pictureBox71, pictureBox70, pictureBox69);

            label6.Text = yellow.finished.ToString();

            //Invisible grid with zoom box mode
            for (int i = 0; i < greenGrid.Length; i++)
            {
                greenGrid[i].BackColor = Color.Transparent;
                greenGrid[i].SizeMode = PictureBoxSizeMode.Zoom;
            }


            //Invisible grid with zoom box mode
            for (int i = 0; i < sharedGrid.Length; i++)
            {
                sharedGrid[i].BackColor = Color.Transparent;
                sharedGrid[i].SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            diceRoll = r.Next(1, 7);
            //Die roll 1-6
            label1.Text = diceRoll.ToString();
            //Displays it
            diceRoll2 = r.Next(1, 7);
            label2.Text = diceRoll2.ToString();

            moves1 = diceRoll;
            moves2 = diceRoll2;
            moves3 = diceRoll + diceRoll2;
            //Stores possible moves

            button3.Text = moves1.ToString();
            //One option to move a piece

            button4.Text = moves2.ToString();
            button5.Text = moves3.ToString();

            //Disables re-rolling
            button1.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Starts the next turn
            button1.Enabled = true;

            //Makes the move choser 0 so nobody can cheat
            chosenMove = 0;

            button2.Enabled = false;
            finisher = 0;

            //Purpose of turn is to use the player array to decide turns
            turn++;
            if (turn == playerArray.Length)
            {
                turn = 0;
            }


            if (playerArray[turn] == "Red")
            {
                //If player is red
                pictureBox2.BackColor = Color.Red;
                pictureBox60.BackColor = Color.Red;
                label1.BackColor = Color.Red;
                label2.BackColor = Color.Red;
                //Make everything red!

                for (int i = 0; i < 4; i++)
                {
                    //Since its red's turn
                    red.pieceArray[i].icon.Enabled = true;
                    //Reds pieces are enabled
                    blue.pieceArray[i].icon.Enabled = false;
                    green.pieceArray[i].icon.Enabled = false;
                    yellow.pieceArray[i].icon.Enabled = false;
                    //The rest are disabled
                }
            }
            else if (playerArray[turn] == "Blue")
            {
                //Same idea as red
                pictureBox2.BackColor = Color.Blue;
                pictureBox60.BackColor = Color.Blue;
                label1.BackColor = Color.Blue;
                label2.BackColor = Color.Blue;

                for (int i = 0; i < 4; i++)
                {
                    //Same idea as red
                    red.pieceArray[i].icon.Enabled = false;
                    blue.pieceArray[i].icon.Enabled = true;
                    green.pieceArray[i].icon.Enabled = false;
                    yellow.pieceArray[i].icon.Enabled = false;
                }
            }
            else if (playerArray[turn] == "Green")
            {
                //Same idea as red
                pictureBox2.BackColor = Color.Green;
                pictureBox60.BackColor = Color.Green;
                label1.BackColor = Color.Green;
                label2.BackColor = Color.Green;

                for (int i = 0; i < 4; i++)
                {
                    //Same idea as red
                    red.pieceArray[i].icon.Enabled = false;
                    blue.pieceArray[i].icon.Enabled = false;
                    green.pieceArray[i].icon.Enabled = true;
                    yellow.pieceArray[i].icon.Enabled = false;
                }
            }
            else if (playerArray[turn] == "Yellow")
            {
                //Same idea as red
                pictureBox2.BackColor = Color.Yellow;
                pictureBox60.BackColor = Color.Yellow;
                label1.BackColor = Color.Yellow;
                label2.BackColor = Color.Yellow;

                for (int i = 0; i < 4; i++)
                {
                    //Same idea as red
                    red.pieceArray[i].icon.Enabled = false;
                    blue.pieceArray[i].icon.Enabled = false;
                    green.pieceArray[i].icon.Enabled = false;
                    yellow.pieceArray[i].icon.Enabled = true;
                }
            }
            //Lets users know who is up
            label8.Text = playerArray[turn] + "'s turn!";
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            //All of my piece clicking methods are exactly the same with only changes to
            //the pieces used and the player permissions. Understanding this button will
            //be sufficient for understanding the rest

            if (red.pieceTwo.onBoard == false)
            //If piece is not already on board...
            {
                if (chosenMove == 5)
                //and the selected move is 5...
                {
                    red.pieceTwo.location += 0;
                    red.pieceTwo.icon.Left = redGrid[red.pieceTwo.location].Left;
                    red.pieceTwo.icon.Top = redGrid[red.pieceTwo.location].Top;
                    //place the piece on the board!
                    chosenMove = 0;
                    red.pieceTwo.onBoard = true;
                    //From now on the piece is on the board and can accept movements
                }
            }
            else
            {
            //If it is on the board
                try
                {
                    red.pieceTwo.location += chosenMove;
                    //Adds to the pieces location attribute
                    red.pieceTwo.icon.Left = redGrid[red.pieceTwo.location].Left;
                    red.pieceTwo.icon.Top = redGrid[red.pieceTwo.location].Top;
                    //Moves the piece visually
                    chosenMove = 0;
                    //Chosen move is set to zero so that no more incriments can be made
                }
                catch (IndexOutOfRangeException)
                //If there is an index out of range exception on the grid...
                {
                    red.pieceTwo.icon.BackgroundImage = null;
                    red.finished++;
                    //that just means the piece has finished!
                    //Add to the finished and delete the piece
                    label4.Text = red.finished.ToString();
                    //updates the on-board text
                    red.pieceTwo.icon.Enabled = false;
                    red.pieceTwo.icon.Left = 2000;
                    //Just to make sure, the piece is moved off screen and disabled
                    //No cheating!!

                    red.hasWon();
                    //Checks if piece has caused the teams victory
                }
            } 
        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {
            if (red.pieceOne.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    red.pieceOne.location += 0;
                    red.pieceOne.icon.Left = redGrid[red.pieceOne.location].Left;
                    red.pieceOne.icon.Top = redGrid[red.pieceOne.location].Top;
                    chosenMove = 0;
                    red.pieceOne.onBoard = true;
                }
            }
            else
            {
                try
                {
                    red.pieceOne.location += chosenMove;
                    red.pieceOne.icon.Left = redGrid[red.pieceOne.location].Left;
                    red.pieceOne.icon.Top = redGrid[red.pieceOne.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    red.pieceOne.icon.BackgroundImage = null;
                    red.finished++;
                    label4.Text = red.finished.ToString();
                    red.pieceOne.icon.Enabled = false;
                    red.pieceOne.icon.Left = 2000;

                    red.hasWon();
                }
            }
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            if (red.pieceThree.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    red.pieceThree.location += 0;
                    red.pieceThree.icon.Left = redGrid[red.pieceThree.location].Left;
                    red.pieceThree.icon.Top = redGrid[red.pieceThree.location].Top;
                    chosenMove = 0;
                    red.pieceThree.onBoard = true;
                }
            }
            else
            {
                try
                {
                    red.pieceThree.location += chosenMove;
                    red.pieceThree.icon.Left = redGrid[red.pieceThree.location].Left;
                    red.pieceThree.icon.Top = redGrid[red.pieceThree.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    red.pieceThree.icon.BackgroundImage = null;
                    red.finished++;
                    label4.Text = red.finished.ToString();
                    red.pieceThree.icon.Enabled = false;
                    red.pieceThree.icon.Left = 2000;

                    red.hasWon();
                }
            }
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            if (red.pieceFour.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    red.pieceFour.location += 0;
                    red.pieceFour.icon.Left = redGrid[red.pieceFour.location].Left;
                    red.pieceFour.icon.Top = redGrid[red.pieceFour.location].Top;
                    chosenMove = 0;
                    red.pieceFour.onBoard = true;
                }
            }
            else
            {
                try
                {
                    red.pieceFour.location += chosenMove;
                    red.pieceFour.icon.Left = redGrid[red.pieceFour.location].Left;
                    red.pieceFour.icon.Top = redGrid[red.pieceFour.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    red.pieceFour.icon.BackgroundImage = null;
                    red.finished++;
                    label4.Text = red.finished.ToString();
                    red.pieceFour.icon.Enabled = false;
                    red.pieceFour.icon.Left = 2000;

                    red.hasWon();
                }
            }
        }

        private void pictureBox76_Click(object sender, EventArgs e)
        {
            if (blue.pieceOne.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    blue.pieceOne.location += 0;
                    blue.pieceOne.icon.Left = blueGrid[blue.pieceOne.location].Left;
                    blue.pieceOne.icon.Top = blueGrid[blue.pieceOne.location].Top;
                    chosenMove = 0;
                    blue.pieceOne.onBoard = true;
                }
            }
            else
            {
                try
                {
                    blue.pieceOne.location += chosenMove;
                    blue.pieceOne.icon.Left = blueGrid[blue.pieceOne.location].Left;
                    blue.pieceOne.icon.Top = blueGrid[blue.pieceOne.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    blue.pieceOne.icon.BackgroundImage = null;
                    blue.finished++;
                    label5.Text = blue.finished.ToString();
                    blue.pieceOne.icon.Enabled = false;
                    blue.pieceOne.icon.Left = 2000;

                    blue.hasWon();
                }
            }
        }

        private void pictureBox75_Click(object sender, EventArgs e)
        {
            if (blue.pieceTwo.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    blue.pieceTwo.location += 0;
                    blue.pieceTwo.icon.Left = blueGrid[blue.pieceTwo.location].Left;
                    blue.pieceTwo.icon.Top = blueGrid[blue.pieceTwo.location].Top;
                    chosenMove = 0;
                    blue.pieceTwo.onBoard = true;
                }
            }
            else
            {
                try
                {
                    blue.pieceTwo.location += chosenMove;
                    blue.pieceTwo.icon.Left = blueGrid[blue.pieceTwo.location].Left;
                    blue.pieceTwo.icon.Top = blueGrid[blue.pieceTwo.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    blue.pieceTwo.icon.BackgroundImage = null;
                    blue.finished++;
                    label5.Text = blue.finished.ToString();
                    blue.pieceTwo.icon.Enabled = false;
                    blue.pieceTwo.icon.Left = 2000;

                    blue.hasWon();
                }
            }
        }

        private void pictureBox74_Click(object sender, EventArgs e)
        {
            if (blue.pieceThree.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    blue.pieceThree.location += 0;
                    blue.pieceThree.icon.Left = blueGrid[blue.pieceThree.location].Left;
                    blue.pieceThree.icon.Top = blueGrid[blue.pieceThree.location].Top;
                    chosenMove = 0;
                    blue.pieceThree.onBoard = true;
                }
            }
            else
            {
                try
                {
                    blue.pieceThree.location += chosenMove;
                    blue.pieceThree.icon.Left = blueGrid[blue.pieceThree.location].Left;
                    blue.pieceThree.icon.Top = blueGrid[blue.pieceThree.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    blue.pieceThree.icon.BackgroundImage = null;
                    blue.finished++;
                    label5.Text = blue.finished.ToString();
                    blue.pieceThree.icon.Enabled = false;
                    blue.pieceThree.icon.Left = 2000;

                    blue.hasWon();
                }
            }
        }

        private void pictureBox73_Click(object sender, EventArgs e)
        {
            if (blue.pieceFour.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    blue.pieceFour.location += 0;
                    blue.pieceFour.icon.Left = blueGrid[blue.pieceFour.location].Left;
                    blue.pieceFour.icon.Top = blueGrid[blue.pieceFour.location].Top;
                    chosenMove = 0;
                    blue.pieceFour.onBoard = true;
                }
            }
            else
            {
                try
                {
                    blue.pieceFour.location += chosenMove;
                    blue.pieceFour.icon.Left = blueGrid[blue.pieceFour.location].Left;
                    blue.pieceFour.icon.Top = blueGrid[blue.pieceFour.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    blue.pieceFour.icon.BackgroundImage = null;
                    blue.finished++;
                    label5.Text = blue.finished.ToString();
                    blue.pieceFour.icon.Enabled = false;
                    blue.pieceFour.icon.Left = 2000;

                    blue.hasWon();
                }
            }
        }

        private void pictureBox68_Click(object sender, EventArgs e)
        {
            if (green.pieceOne.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    green.pieceOne.location += 0;
                    green.pieceOne.icon.Left = greenGrid[green.pieceOne.location].Left;
                    green.pieceOne.icon.Top = greenGrid[green.pieceOne.location].Top;
                    chosenMove = 0;
                    green.pieceOne.onBoard = true;
                }
            }
            else
            {
                try
                {
                    green.pieceOne.location += chosenMove;
                    green.pieceOne.icon.Left = greenGrid[green.pieceOne.location].Left;
                    green.pieceOne.icon.Top = greenGrid[green.pieceOne.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    green.pieceOne.icon.BackgroundImage = null;
                    green.finished++;
                    label7.Text = green.finished.ToString();
                    green.pieceOne.icon.Enabled = false;
                    green.pieceOne.icon.Left = 2000;

                    green.hasWon();
                }
            }
        }

        private void pictureBox67_Click(object sender, EventArgs e)
        {
            if (green.pieceTwo.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    green.pieceTwo.location += 0;
                    green.pieceTwo.icon.Left = greenGrid[green.pieceTwo.location].Left;
                    green.pieceTwo.icon.Top = greenGrid[green.pieceTwo.location].Top;
                    chosenMove = 0;
                    green.pieceTwo.onBoard = true;
                }
            }
            else
            {
                try
                {
                    green.pieceTwo.location += chosenMove;
                    green.pieceTwo.icon.Left = greenGrid[green.pieceTwo.location].Left;
                    green.pieceTwo.icon.Top = greenGrid[green.pieceTwo.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    green.pieceTwo.icon.BackgroundImage = null;
                    green.finished++;
                    label7.Text = green.finished.ToString();
                    green.pieceTwo.icon.Enabled = false;
                    green.pieceTwo.icon.Left = 2000;

                    green.hasWon();
                }
            }
        }

        private void pictureBox66_Click(object sender, EventArgs e)
        {
            if (green.pieceThree.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    green.pieceThree.location += 0;
                    green.pieceThree.icon.Left = greenGrid[green.pieceThree.location].Left;
                    green.pieceThree.icon.Top = greenGrid[green.pieceThree.location].Top;
                    chosenMove = 0;
                    green.pieceThree.onBoard = true;
                }
            }
            else
            {
                try
                {
                    green.pieceThree.location += chosenMove;
                    green.pieceThree.icon.Left = greenGrid[green.pieceThree.location].Left;
                    green.pieceThree.icon.Top = greenGrid[green.pieceThree.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    green.pieceThree.icon.BackgroundImage = null;
                    green.finished++;
                    label7.Text = green.finished.ToString();
                    green.pieceThree.icon.Enabled = false;
                    green.pieceThree.icon.Left = 2000;

                    green.hasWon();
                }
            }
        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {
            if (green.pieceFour.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    green.pieceFour.location += 0;
                    green.pieceFour.icon.Left = greenGrid[green.pieceFour.location].Left;
                    green.pieceFour.icon.Top = greenGrid[green.pieceFour.location].Top;
                    chosenMove = 0;
                    green.pieceFour.onBoard = true;
                }
            }
            else
            {
                try
                {
                    green.pieceFour.location += chosenMove;
                    green.pieceFour.icon.Left = greenGrid[green.pieceFour.location].Left;
                    green.pieceFour.icon.Top = greenGrid[green.pieceFour.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    green.pieceFour.icon.BackgroundImage = null;
                    green.finished++;
                    label7.Text = green.finished.ToString();
                    green.pieceFour.icon.Enabled = false;
                    green.pieceFour.icon.Left = 2000;

                    green.hasWon();
                }
            }
        }

        private void pictureBox72_Click(object sender, EventArgs e)
        {
            if (yellow.pieceOne.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    yellow.pieceOne.location += 0;
                    yellow.pieceOne.icon.Left = yellowGrid[yellow.pieceOne.location].Left;
                    yellow.pieceOne.icon.Top = yellowGrid[yellow.pieceOne.location].Top;
                    chosenMove = 0;
                    yellow.pieceOne.onBoard = true;
                }
            }
            else
            {
                try
                {
                    yellow.pieceOne.location += chosenMove;
                    yellow.pieceOne.icon.Left = yellowGrid[yellow.pieceOne.location].Left;
                    yellow.pieceOne.icon.Top = yellowGrid[yellow.pieceOne.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    yellow.pieceOne.icon.BackgroundImage = null;
                    yellow.finished++;
                    label6.Text = yellow.finished.ToString();
                    yellow.pieceOne.icon.Enabled = false;
                    yellow.pieceOne.icon.Left = 2000;

                    yellow.hasWon();
                }
            }
        }

        private void pictureBox71_Click(object sender, EventArgs e)
        {
            if (yellow.pieceTwo.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    yellow.pieceTwo.location += 0;
                    yellow.pieceTwo.icon.Left = yellowGrid[yellow.pieceTwo.location].Left;
                    yellow.pieceTwo.icon.Top = yellowGrid[yellow.pieceTwo.location].Top;
                    chosenMove = 0;
                    yellow.pieceTwo.onBoard = true;
                }
            }
            else
            {
                try
                {
                    yellow.pieceTwo.location += chosenMove;
                    yellow.pieceTwo.icon.Left = yellowGrid[yellow.pieceTwo.location].Left;
                    yellow.pieceTwo.icon.Top = yellowGrid[yellow.pieceTwo.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    yellow.pieceTwo.icon.BackgroundImage = null;
                    yellow.finished++;
                    label6.Text = yellow.finished.ToString();
                    yellow.pieceTwo.icon.Enabled = false;
                    yellow.pieceTwo.icon.Left = 2000;

                    yellow.hasWon();
                }
            }
        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {
            if (yellow.pieceThree.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    yellow.pieceThree.location += 0;
                    yellow.pieceThree.icon.Left = yellowGrid[yellow.pieceThree.location].Left;
                    yellow.pieceThree.icon.Top = yellowGrid[yellow.pieceThree.location].Top;
                    chosenMove = 0;
                    yellow.pieceThree.onBoard = true;
                }
            }
            else
            {
                try
                {
                    yellow.pieceThree.location += chosenMove;
                    yellow.pieceThree.icon.Left = yellowGrid[yellow.pieceThree.location].Left;
                    yellow.pieceThree.icon.Top = yellowGrid[yellow.pieceThree.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    yellow.pieceThree.icon.BackgroundImage = null;
                    yellow.finished++;
                    label6.Text = yellow.finished.ToString();
                    yellow.pieceThree.icon.Enabled = false;
                    yellow.pieceThree.icon.Left = 2000;

                    yellow.hasWon();
                }
            }
        }

        private void pictureBox69_Click(object sender, EventArgs e)
        {
            if (yellow.pieceFour.onBoard == false)
            {
                if (chosenMove == 5)
                {
                    yellow.pieceFour.location += 0;
                    yellow.pieceFour.icon.Left = yellowGrid[yellow.pieceFour.location].Left;
                    yellow.pieceFour.icon.Top = yellowGrid[yellow.pieceFour.location].Top;
                    chosenMove = 0;
                    yellow.pieceFour.onBoard = true;
                }
            }
            else
            {
                try
                {
                    yellow.pieceFour.location += chosenMove;
                    yellow.pieceFour.icon.Left = yellowGrid[yellow.pieceFour.location].Left;
                    yellow.pieceFour.icon.Top = yellowGrid[yellow.pieceFour.location].Top;
                    chosenMove = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    yellow.pieceFour.icon.BackgroundImage = null;
                    yellow.finished++;
                    label6.Text = yellow.finished.ToString();
                    yellow.pieceFour.icon.Enabled = false;
                    yellow.pieceFour.icon.Left = 2000;

                    yellow.hasWon();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1st move choice
            button5.Enabled = false;
            //Since the third move choice is 1st + 2nd
            //Disable it if 1st or 2nd are chosen

            chosenMove = moves1;
            //Sets the chosen moves so that the player can now move their piece

            button3.Enabled = false;
            finisher++;
            if (finisher == 2)
            {
                button2.Enabled = true;
            }
            //The finisher will add up to two for every move choice
            //This exists to enable the finish turn button
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //2nd move
            //Same concept as 1st move
            button5.Enabled = false;

            chosenMove = moves2;

            button4.Enabled = false;
            finisher++;
            if (finisher == 2)
            {
                button2.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //3rd move
            button3.Enabled = false;
            button4.Enabled = false;
            //Disables first two since it combines them

            chosenMove = moves3;

            button5.Enabled = false;
            button2.Enabled = true;
            //Enables finish turn button
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //This is the Ready button on the start-up screen
            int counter = 0;
            string[] tempArray = new string[4];

            if (checkBox1.Checked == true)
            {
                //If red is chosen
                tempArray[counter] = "Red";
                counter++;
                //Add red to the tempArray
            }
            else
            {
                //If red is not chosen
                for (int i = 0; i < 4; i++)
                {
                    red.pieceArray[i].icon.Visible = false;
                    red.pieceArray[i].icon.Enabled = false;
                    //Delete his players from the board
                }
            }
            if (checkBox2.Checked == true)
            {
                tempArray[counter] = "Blue";
                counter++;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    blue.pieceArray[i].icon.Visible = false;
                    blue.pieceArray[i].icon.Enabled = false;
                }
            }
            if (checkBox3.Checked == true)
            {
                tempArray[counter] = "Yellow";
                counter++;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    yellow.pieceArray[i].icon.Visible = false;
                    yellow.pieceArray[i].icon.Enabled = false;
                }
            }
            if (checkBox4.Checked == true)
            {
                tempArray[counter] = "Green";
                counter++;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    green.pieceArray[i].icon.Visible = false;
                    green.pieceArray[i].icon.Enabled = false;
                }
            }

            playerArray = new string[counter];
            for (int i = 0; i < counter; i++)
            {
                playerArray[i] = tempArray[i];
                //stores into the playerArray so it can be accessed
            }

            MessageBox.Show("Roll a 5 and then click your piece to move it out of the base! Good luck!!");

            label9.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            button6.Visible = false;
            panel1.Visible = false;
            //Deletes everything from the start-up

            label8.Text = playerArray[turn] + "'s Turn!";

            if (playerArray[turn] == "Red")
            {
                //If player is red
                pictureBox2.BackColor = Color.Red;
                pictureBox60.BackColor = Color.Red;
                label1.BackColor = Color.Red;
                label2.BackColor = Color.Red;
                //Design becomes red

                for (int i = 0; i < 4; i++)
                {
                    //Red pieces are enabled
                    red.pieceArray[i].icon.Enabled = true;
                    //Other pieces do not need to be disabled here since they are by default
                }
            }
            else if (playerArray[turn] == "Blue")
            {
                //Same concept as red
                pictureBox2.BackColor = Color.Blue;
                pictureBox60.BackColor = Color.Blue;
                label1.BackColor = Color.Blue;
                label2.BackColor = Color.Blue;

                for (int i = 0; i < 4; i++)
                {
                    blue.pieceArray[i].icon.Enabled = true;
                }
            }
            else if (playerArray[turn] == "Green")
            {
                //Same concept as red
                pictureBox2.BackColor = Color.Green;
                pictureBox60.BackColor = Color.Green;
                label1.BackColor = Color.Green;
                label2.BackColor = Color.Green;

                for (int i = 0; i < 4; i++)
                {
                    green.pieceArray[i].icon.Enabled = true;
                }
            }
            else if (playerArray[turn] == "Yellow")
            {
                //Same concept as red
                pictureBox2.BackColor = Color.Yellow;
                pictureBox60.BackColor = Color.Yellow;
                label1.BackColor = Color.Yellow;
                label2.BackColor = Color.Yellow;

                for (int i = 0; i < 4; i++)
                {
                    yellow.pieceArray[i].icon.Enabled = true;
                }
            }
        }
    }
}
