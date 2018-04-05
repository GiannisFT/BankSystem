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
            var accountlist = new List<Account>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("[1] Add account \n[6] Show accounts \n[7] Close account \n[8] Show bank vault \n[X] Close the program");
                Console.Write("\nChoose an option: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        accountlist.Add(Account.Add());
                        break;
                    case "6":
                        Console.Clear();
                        foreach (Account acc in accountlist)
                        {
                            Console.Write("{0}\t{1}\t{2}\t{3}", acc.accountNumber, acc.accountType, acc.accountOwner, acc.accountBalance);
                            Console.WriteLine("");
                        }
                        Console.WriteLine("");
                        break;
                    case "7":
                        Console.Clear();
                        Console.Write("Enter account number: ");
                        int aNum = int.Parse(Console.ReadLine());
                        accountlist.RemoveAll(r => r.accountNumber == aNum);
                        Console.WriteLine("");
                        break;
                    case "8":
                        Console.Clear();
                        List<double> blist = new List<double>();
                        foreach (var item in accountlist)
                        {
                            blist.Add(item.accountBalance);
                        }
                        double vault = blist.Sum();
                        Console.WriteLine(vault+"\n");
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
