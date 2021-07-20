using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tick_tack_toe
{
    public class User
    {
        public string Move { set; get; }

        public string[] AllMoves { get; private set; }

        public User(string[] moves)
        {
            moves.CopyTo(this.AllMoves, 0);
        }

        public bool IsWin(string move)
        {

        }
    }
}
