using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Parcheesi
{
    class Piece
    {
        public int location;
        public Boolean onBoard;
        public PictureBox icon;

         public Piece(PictureBox piece)
         {
             icon = piece;
             onBoard = false;
             //tracks whether the piece has been moved onto the board yet
             location = 0;
             //determines place on their gridArray
         }
    }
}
