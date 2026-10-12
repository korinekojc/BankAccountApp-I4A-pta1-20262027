using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp.Classes
{
    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }


        public SavingsAccount(
            string owner,
            string accountNumber,
            double balance,
            double interestRate)
            : base(owner, accountNumber, balance)
        {
            InterestRate = interestRate;
        }


        public override string GetAccountType()
        {
            return "Spořicí účet";
        }


        public override double GetMonthlyFee()
        {
            return 20;
        }


        public override double CalculateInterest()
        {
            return Balance * InterestRate / 100;
        }
    }
}
