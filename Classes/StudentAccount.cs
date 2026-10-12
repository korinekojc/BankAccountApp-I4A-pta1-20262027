using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp.Classes
{
    public class StudentAccount : BankAccount
    {
        public double OverdraftLimit { get; set; }


        public StudentAccount(
            string owner,
            string accountNumber,
            double balance,
            double overdraftLimit)
            : base(owner, accountNumber, balance)
        {
            OverdraftLimit = overdraftLimit;
        }


        public override string GetAccountType()
        {
            return "Studentský účet";
        }


        public override double GetMonthlyFee()
        {
            return 0;
        }


        public override bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (amount > Balance + OverdraftLimit)
            {
                return false;
            }

            Balance -= amount;

            return true;
        }


        public override double GetAvailableFunds()
        {
            return Balance + OverdraftLimit;
        }
    }
}
