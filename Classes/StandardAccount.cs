using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp.Classes
{
    public class StandardAccount : BankAccount
    {
        public StandardAccount(string owner, string accountNumber, double balance)
            : base(owner, accountNumber, balance)
        {

        }

        public override string GetAccountType()
        {
            return "Běžný účet";
        }


        public override double GetMonthlyFee()
        {
            return 50;
        }
    }
}
