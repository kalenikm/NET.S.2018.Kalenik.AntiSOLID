using System;

namespace Logic
{
    public abstract class Account
    {
        public int Id { get; protected set; }
        public decimal Balance { get; protected set; }

        public virtual void Withdraw(decimal money)
        {
            if (money <= 0)
            {
                throw new Exception();
            }

            if (Balance < money)
            {
                throw new Exception();
            }

            Balance -= money;
        }

        public virtual void Deposit(decimal money)
        {
            if (money <= 0)
            {
                throw new Exception();
            }

            Balance += money;
        }
    }
}