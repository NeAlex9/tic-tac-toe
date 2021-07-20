using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tick_tack_toe
{
    public class User
    {
        private Random rand = new Random();

        public string Name { get; set; }

        public string Move { set; get; }

        public User(string name)
        {
            Name = name;
        }

        public void GenerateMove(string[] moves)
        {
            int len = moves.Length;
            Move = moves[rand.Next(len)];
        }

        public void ChooseMove(int index, string[] moves)
        {
            Move = moves[index - 1];
        }
    }
}
