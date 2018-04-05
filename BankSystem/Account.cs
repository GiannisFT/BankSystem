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
        public int accountNumber;
        public string accountType;
        public string accountOwner;
        public double accountBalance;
        //public static List<double> vault = new List<double>();

        public Account(int accountnumber, string accounttype, string accountowner, double accountbalance)
        {
            this.accountNumber = accountnumber;
            this.accountType = accounttype;
            this.accountOwner = accountowner;
            this.accountBalance = accountbalance;
            //vault.Add(accountBalance);
        }

        public Account()
        {

        }

        public static Account Add()
        {
            var accountDetails = new Account();
            Console.WriteLine("Enter account number: ");
            accountDetails.accountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter account type: ");
            accountDetails.accountType = Console.ReadLine();
            Console.WriteLine("Enter account owner: ");
            accountDetails.accountOwner = Console.ReadLine();
            Console.WriteLine("Enter account balance: ");
            accountDetails.accountBalance = double.Parse(Console.ReadLine());
            return accountDetails;
        }

        public static void BankVault()
        {
            
        }
    }
}
