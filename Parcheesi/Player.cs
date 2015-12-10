using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Parcheesi
{
    class Player
    {
        public int pieces = 4;
        public string name = "";
        public int finished = 0;
        public Piece pieceOne, pieceTwo, pieceThree, pieceFour;
        public Piece[] pieceArray = new Piece[4];

        public Player(string id, PictureBox one, PictureBox two, PictureBox three, PictureBox four)
        {
            name = id;
            pieceOne = new Piece(one);
            pieceTwo = new Piece(two);
            pieceThree = new Piece(three);
            pieceFour = new Piece(four);
            //Sets the pieces based off the players given pictureBoxes

            pieceArray[0] = pieceOne;
            pieceArray[1] = pieceTwo;
            pieceArray[2] = pieceThree;
            pieceArray[3] = pieceFour;
            //pieceArray is for easy access
        }

        public Boolean hasWon()
        {
            if (this.finished == 4)
            //If four pieces have finished
            {
                MessageBox.Show(name + " has won!!");
                //Congrats!
                Application.Exit();
                //Game ends
                return true;
            }
            else
            {
                return false;
                //Game continues
            }
        }
    }
}
