using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountsApp
{
    public class BankAccount
    {
        public string Owner { get; set; }
        public Guid AccountNumber { get; set; }
        public decimal Balances { get; protected set; }

        public BankAccount(string hoten, decimal sodu)
        {
            Owner = hoten;
            AccountNumber = Guid.NewGuid();
            Balances = sodu;
        }

        public virtual string Deposit(decimal amount)
        {
            if (amount < 0) return "You can not Deposit $" + amount;
            if(Balances + amount > 1000000000) return "AML Deposit Limit Reached!";
            Balances += amount;
            return "Deposit completed successfully!";
        }

        public string Withdraw(decimal amount)
        {
            if (amount < 0) return "You can not Withdraw $" + amount;
            if (amount > Balances) return "You don't have enough money!";
            Balances -= amount;
            return "Withdraw completed successfully!";
        }
    }
}
