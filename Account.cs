using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Account
    {
        public int Number;
        public string Type;
        public string Owner;
        public double Balance;

        //public Account(int aNumber, string aType, string aOwner, double aBalance)
        //{
        //    this.Number = aNumber;
        //    this.Type = aType;
        //    this.Owner = aOwner;
        //    this.Balance = aBalance;
        //}

        public void AddAccount(string[,] accountlist)
        {
            Console.WriteLine("Enter account number: ");
            Number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter account type: ");
            Type = Console.ReadLine();
            Console.WriteLine("Enter account owner: ");
            Owner = Console.ReadLine();
            Console.WriteLine("Enter account balance: ");
            Balance = double.Parse(Console.ReadLine());

            string filepath = (@"C:\Users\Giannis\Documents\accounts.txt");
            // Create a new array with the new created account
            string[,] newAccount = new string[,] { { Number.ToString(), Type, Owner, Balance.ToString() } };
            string[,] updatedArray = new string[accountlist.GetLength(0) + 1, newAccount.GetLength(1)];
            // Copy the old accounts array and the new account into the larger array
            Array.Copy(accountlist, 0, updatedArray, 0, accountlist.Length);
            Array.Copy(newAccount, 0, updatedArray, accountlist.Length, newAccount.Length);
            Console.WriteLine("Account successfully created!\n");
            Read_Write_toFile.WriteFile(filepath, updatedArray);
        }

        public void DeleteAccount()
        {
            Console.Write("Enter account number to delete: \t");
            var choise = Console.ReadLine();
            string filepath = (@"C:\Users\Giannis\Documents\accounts.txt");
            Read_Write_toFile read = new Read_Write_toFile();
            List<string> temp = read.ReadFile(filepath).Cast<string>().ToList();
            int index = temp.FindIndex(a => a.Equals(choise));
            if (temp.Contains(choise))
            {
                temp.RemoveRange(index, 4);
                Console.WriteLine("Account No.{0} deleted successfully!\n", choise);
            }
            else
                Console.WriteLine("Account number not found!\n");
            string[] accounts = temp.ToArray();
            int height = accounts.GetLength(0) /4;
            string[,] updatedArray = Make2DArray(accounts, height, 4);
            Read_Write_toFile.WriteFile(filepath, updatedArray);
        }

        private static T[,] Make2DArray<T>(T[] input, int height, int width)
        {
            T[,] output = new T[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                }
            }
            return output;
        }

        public void Display()
        {
            string filepath = (@"C:\Users\Giannis\Documents\accounts.txt");
            Read_Write_toFile read = new Read_Write_toFile();
            string[,] accountlist = new string[0, 0];
            accountlist = read.ReadFile(filepath);
            for (int i = 0; i < accountlist.GetLength(0); i++)
            {
                string s1 = accountlist[i, 0];
                string s2 = accountlist[i, 1];
                string s3 = accountlist[i, 2];
                string s4 = accountlist[i, 3];
                Console.WriteLine("{0}  --  {1}  --  {2}  --  {3}", s1, s2, s3, s4);
            }
            Console.WriteLine("");
        }

        public double Withdraw(double amount)
        {
            if (amount>0)
            {
                this.Balance -= amount;
            }
            else
                Console.WriteLine("Cannot transfer zero or less!");
            return Balance;
        }
    }
}
