using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountsApp
{
    public class SavingAccount : BankAccount 
    {
        public decimal InterestRate { get; set; }

        public SavingAccount(string hoten, decimal sodu, decimal tile) : base(hoten + " (" + tile + "%)", sodu)
        {
            InterestRate = tile;
        }

        public override string Deposit(decimal amount)
        {
            if (amount < 0) return "You can not Deposit $" + amount;
            if (Balances + amount > 1000000000) return "AML Deposit Limit Reached!";
            Balances += amount * (InterestRate / 100 + 1);
            return "Deposit completed successfully!";
        }

    }
}
