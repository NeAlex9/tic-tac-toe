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
            Moves = new string[parameters.Length];
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

            Console.WriteLine("0) Exit");
        }

        public void StartGame()
        {
            int index = 9;
            while (true)
            {
                byte[] secretKey = KeyGen.GenerateSecretKey();
                Computer.GenerateMove(Moves);
                Console.WriteLine("HMAC:");
                Console.WriteLine(KeyGen.GenerateHMAC(secretKey, Computer.Move));
                ShowMenu(Moves);
                Console.Write("Enter your move: ");
                while (true)
                {
                    try
                    {
                        index = Convert.ToInt32(Console.ReadLine());
                        if (index > Moves.Length || index < 0)
                        {
                            Console.WriteLine("Invalid operation");
                        }
                        else if (index == 0)
                        {
                            Console.WriteLine("Exit");
                            return;
                        }
                        else
                        {
                            Player.ChooseMove(index, Moves);
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid operation");
                    }
                }

                Console.WriteLine("Your move: " + Player.Move);
                Console.WriteLine("Computer move: " + Computer.Move);
                User winner; 
                if ((winner = GameResults(Player, Computer)) != null)
                {
                    Console.WriteLine(winner.Name + " win!");
                }
                else
                {
                    Console.WriteLine("no winners");
                }
                Console.WriteLine("HMAC key: ");
                Console.WriteLine((new BigInteger(secretKey)).ToString("X") + "\n\n");
            }
        }

        public User GameResults(User firstUser, User secondUser)
        {
            int firstUserIndex = Array.IndexOf(Moves, firstUser.Move);
            int secondUserIndex = Array.IndexOf(Moves, secondUser.Move);
            if (firstUserIndex == secondUserIndex)
            {
                return null;
            }

            if (firstUserIndex > secondUserIndex)
            {
                if ((firstUserIndex - secondUserIndex) > Moves.Length / 2)
                {
                    return secondUser;
                }
                else
                {
                    return firstUser;
                }
            }
            else if ((firstUserIndex - secondUserIndex) < Moves.Length / 2)
            {
                if ((secondUserIndex - firstUserIndex) > Moves.Length / 2)
                {
                    return firstUser;
                }
                else
                {
                    return secondUser;
                }
            }
            int len = Moves.Length / 2;

            return secondUser;
        }
    }
}
