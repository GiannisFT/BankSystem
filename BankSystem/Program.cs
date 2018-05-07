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
            Account test = new Account();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("[1] Add account \n[2] Deposit/Withdrawal \n[3] Transfer amount \n[6] Show accounts \n[7] Close account \n[8] Show bank vault \n[X] Close the program");
                Console.Write("\nChoose an option: \n");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        test.AddAccount();
                        break;
                    case "2":
                        Console.Write("Type D or W:\t");
                        string dw = Console.ReadLine();
                        switch (dw)
                        {
                            case "d":
                            case "D":   Transfer.Deposit();
                                break;
                            case "w":
                            case "W":   Transfer.Withdraw();
                                break;
                            default: Console.Clear();
                                break;
                        }
                        break;
                    case "3":
                        Transfer.Transaction();
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
                        Transfer.Vault();
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
