using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp.Classes
{
    public class BankAccount
    {
        public string Owner { get; set; }

        public string AccountNumber { get; set; }

        public double Balance { get; protected set; }


        public BankAccount(string owner, string accountNumber, double balance)
        {
            Owner = owner;
            AccountNumber = accountNumber;
            Balance = balance;
        }


        public bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            Balance += amount;

            return true;
        }


        public virtual bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (amount > Balance)
            {
                return false;
            }

            Balance -= amount;

            return true;
        }


        public bool TransferTo(BankAccount targetAccount, double amount)
        {
            if (targetAccount == this)
            {
                return false;
            }

            if (!Withdraw(amount))
            {
                return false;
            }

            targetAccount.Deposit(amount);

            return true;
        }


        public virtual string GetAccountType()
        {
            return "Bankovní účet";
        }


        public virtual double GetMonthlyFee()
        {
            return 0;
        }


        public virtual double CalculateInterest()
        {
            return 0;
        }


        public virtual double GetAvailableFunds()
        {
            return Balance;
        }
    }
}
