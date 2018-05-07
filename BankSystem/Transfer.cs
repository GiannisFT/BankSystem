using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankSystem
{
    class Transfer
    {
        public static void Withdraw()
        {
            string filepath = (@"C:\Users\Giannis\Documents\accounts.txt");
            Read_Write_toFile read = new Read_Write_toFile();
            string[,] accountlist = read.ReadFile(filepath);
            Console.Write("From account:\t");
            int from = int.Parse(Console.ReadLine());
            for (int i = 0; i < accountlist.GetLength(0); i++)
            {
                if ((int.Parse(accountlist[i, 0]).Equals(from)))
                {
                    Console.Write("Amount:\t\t");
                    double amount = double.Parse(Console.ReadLine());

                    if (amount > 0 && amount <= (int.Parse(accountlist[i, 3])))
                    {
                        double result = double.Parse(accountlist[i, 3]);
                        result -= amount;
                        accountlist[i, 3] = result.ToString();
                        Console.WriteLine("Withdrawal succesful!\nAccount No.{0} new balance is {1}\n", from, accountlist[i, 3]);
                    }
                }
            }
            Read_Write_toFile.WriteFile(filepath, accountlist);
        }

        public static void Deposit()
        {
            string filepath = (@"C:\Users\Giannis\Documents\accounts.txt");
            Read_Write_toFile read = new Read_Write_toFile();
            string[,] accountlist = read.ReadFile(filepath);
            Console.Write("To account:\t");
            int to = int.Parse(Console.ReadLine());
            for (int i = 0; i < accountlist.GetLength(0); i++)
            {
                if ((int.Parse(accountlist[i, 0]).Equals(to)))
                {
                    Console.Write("Amount:\t\t");
                    double amount = double.Parse(Console.ReadLine());

                    if (amount > 0)
                    {
                        double result = double.Parse(accountlist[i, 3]);
                        result += amount;
                        accountlist[i, 3] = result.ToString();
                        Console.WriteLine("Deposit succesful!\nAccount No.{0} new balance is {1}\n", to, accountlist[i, 3]);
                    }
                }
            }
            Read_Write_toFile.WriteFile(filepath, accountlist);
        }

        public static void Transaction()
        {
            string filepath = (@"C:\Users\Giannis\Documents\accounts.txt");
            Read_Write_toFile read = new Read_Write_toFile();
            string[,] accountlist = read.ReadFile(filepath);
            Console.Write("From account:\t");
            int from = int.Parse(Console.ReadLine());
            for (int i = 0; i < accountlist.GetLength(0); i++)
            {
                if ((int.Parse(accountlist[i, 0]).Equals(from)))
                {
                    double fromBalance = double.Parse(accountlist[i, 3]);
                    Console.Write("To account:\t");
                    int to = int.Parse(Console.ReadLine());
                    for (int j = 0; j < accountlist.GetLength(0); j++)
                    {
                        if ((int.Parse(accountlist[j, 0]).Equals(to)) && (from != to))
                        {
                            double toBalance = double.Parse(accountlist[j, 3]);
                            Console.Write("Amount:\t\t");
                            double amount = double.Parse(Console.ReadLine());
                            if (amount > 0)
                            {
                                fromBalance -= amount;
                                toBalance += amount;
                                accountlist[i, 3] = fromBalance.ToString();
                                accountlist[j, 3] = toBalance.ToString();
                                Console.WriteLine("Transaction completed!\n{0} were transfered from No.{1} to No.{2}", amount, from, to);
                                break;
                            }
                        }
                    }
                }
            }
            Read_Write_toFile.WriteFile(filepath, accountlist);
        }

        public static void Vault()
        {
            string filepath = (@"C:\Users\Giannis\Documents\accounts.txt");
            Read_Write_toFile read = new Read_Write_toFile();
            string[,] accountlist = read.ReadFile(filepath);
            List<double> vault = new List<double>();
            for (int i = 0; i < accountlist.GetLength(0); i++)
            {
                vault.Add(double.Parse(accountlist[i, 3]));
            }
            double sum = vault.Sum();
            Console.WriteLine("The bank vault contains {0} SEK\n", sum);
        }
    }
}
