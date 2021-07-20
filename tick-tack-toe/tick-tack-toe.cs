using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Numerics;

namespace tick_tack_toe
{
    public class tick_tack_toe
    {
        public User Computer { get; set; }

        public User Player { get; set; }

        public string[] Moves { get; set; }

        public tick_tack_toe(string[] parameters)
        {
            parameters.CopyTo(this.Moves, 0);
            this.Computer = new User("Computer");
            this.Player = new User("You");
        }

        public void ShowMenu(string[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ") " + parameters[i]);
            }
        }

        public void StartGame()
        {
            int index = 9;
            while (index != 0)
            {
                byte[] secretKey = KeyGen.GenerateSecretKey();
                Computer.GenerateMove(Moves);
                Console.WriteLine("HMAC:");
                Console.WriteLine(KeyGen.GenerateHMAC(secretKey, Computer.Move));
                ShowMenu(Moves);
                Console.Write("Enter your move: ");
                index = Console.Read();
                Player.ChooseMove(index, Moves);
                Console.Write("Your move: " + Player.Move);
                if (index != 0)
                {
                    Console.WriteLine(GameResults(Player, Computer).Name + " win!");
                }

                Console.WriteLine("HMAC key:");
                Console.WriteLine((new BigInteger(secretKey)).ToString());
            }

            Console.WriteLine("Exit");
        }

        public User GameResults(User firstUser, User secondUser)
        {
            int firstUserIndex = Array.IndexOf(Moves, firstUser.Move);
            int secondUserIndex = Array.IndexOf(Moves, secondUser.Move);
            if (firstUserIndex < secondUserIndex)
            {
                return firstUser;
            }

            return secondUser;
        }
    }
}
