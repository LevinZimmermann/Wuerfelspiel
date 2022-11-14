using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static bool winntrigger = false;
        static string name;
        static void Main(string[] args)
        {
            bool firsttrigger = true;
            int rand_num;
            int computerbank = 0;
            int userbank = 0;
            string answer = "";

            Console.WriteLine("Bitte gebe deinen Namen ein: ");
            name = Console.ReadLine();

            do
            {

                do
                {
                    if (winntrigger == true)
                    {
                        break;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.WriteLine("--Bank----------------------------------------------");
                    Console.WriteLine("| Computer = \t [ " + computerbank + " ] \t\t |");
                    Console.WriteLine("| User = \t [ " + userbank + " ] \t\t |");
                    Console.WriteLine("----------------------------------------------------");

                    Random rd = new Random();
                    rand_num = rd.Next(1, 7);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Du hast eine " + rand_num + " gewürfelt");
                    System.Threading.Thread.Sleep(1000);
                    if (rand_num == 1)
                    {
                        userbank = 0;
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Behalten? [y/n]: ");
                        answer = Console.ReadLine();
                    }

                    if(answer == "y")
                    {
                        userbank += rand_num;
                        winntrigger = GetWinner(computerbank, userbank);
                    }
                    else if(answer == "q") 
                    {
                        firsttrigger = false;
                        break;
                    }

                    if (winntrigger == true)
                    {
                        break;
                    }


                } while (answer == "y");

                if (answer == "q")
                {
                    break;
                }
                else if(winntrigger)
                {
                    break;
                }           
                

                do
                {
                    if (winntrigger == true)
                    {
                        break;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.WriteLine("--Bank----------------------------------------------");
                    Console.WriteLine("| Computer = \t [ " + computerbank + " ] \t\t |");
                    Console.WriteLine("| User = \t [ " + userbank + " ] \t\t |");
                    Console.WriteLine("----------------------------------------------------");

                    Random rd = new Random();
                    rand_num = rd.Next(1, 7);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Der Computer hat " + rand_num + " gewürfelt");
                    System.Threading.Thread.Sleep(2000);
                    if (rand_num == 1)
                    {
                        computerbank = 0;
                        Console.Clear();
                    }
                    else if(rand_num < 3)
                    {
                        winntrigger = GetWinner(computerbank, userbank);
                        break;
                    }
                    else 
                    {
                        computerbank += rand_num;
                        winntrigger = GetWinner(computerbank, userbank);
                    }

                    if(winntrigger == true)
                    {
                        break;
                    }
                    
                } while (rand_num != 1);

                if (winntrigger)
                {
                    break;
                }

            } while (firsttrigger);
            System.Threading.Thread.Sleep(10000);
        }



        public static bool GetWinner(int computer, int user)
        {
            if (computer > 30) 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Der Computer hat gewonnen!");
                return true;
            }
            else if (user > 30) 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(name + " hat gewonnen!");
                return true;
            }
            else 
            {
                return false;
            }
            
        }
    }
}
