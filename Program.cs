using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = (@"C:\Users\Giannis\Documents\accounts.txt");
            Account test = new Account();
            Read_Write_toFile read = new Read_Write_toFile();
            string[,] accountlist = read.ReadFile(filepath);
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("[1] Add account \n[3] Transfer amount \n[6] Show accounts \n[7] Close account \n[8] Show bank vault \n[X] Close the program");
                Console.Write("\nChoose an option: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        test.AddAccount(accountlist);
                        break;
                    case "3":
                        Console.Clear();
                        //Console.Write("From account number: \t");
                        //int from = int.Parse(Console.ReadLine());
                        //Console.Write("Enter amount: \t\t");
                        //double amount = double.Parse(Console.ReadLine());
                        //Console.Write("To account number: \t");
                        //int to = int.Parse(Console.ReadLine());
                        //foreach (Account acc in accountlist)
                        //{
                        //    if (acc.Number==from)
                        //    {
                        //        acc.Withdraw(amount);
                        //    }
                        //}
                        break;
                    case "6":
                        Console.Clear();
                        test.Display();
                        break;
                    case "7":
                        Console.Clear();
                        test.DeleteAccount();
                        break;
                    case "8":
                        Console.Clear();
                        
                        break;
                    case "x":
                    case "X":
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
