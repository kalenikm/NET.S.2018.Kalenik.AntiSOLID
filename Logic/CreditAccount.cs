using System;

namespace Logic
{
    public class CreditAccount : Account
    {
        public CreditAccount()
        {
            Id = NumberCreator.CreateNumber();
        }

        public CreditAccount(int id, decimal balance)
        {
            Id = id;
            Balance = balance;
        }

        public override void Withdraw(decimal money)
        {
            Balance -= money;
        }

        public override void Deposit(decimal money)
        {
            Balance += money;
        }
    }
}