using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BonusAccount : Account
    {
        public int Bonus;

        public BonusAccount()
        {
            Id = NumberCreator.CreateNumber();
        }

        public BonusAccount(int id, decimal balance, int bonus)
        {
            Id = id;
            Balance = balance;
            Bonus = bonus;
        }

        public override void Withdraw(decimal money)
        {
            if (Balance < money)
            {
                throw new Exception();
            }

            Balance -= money;
            Bonus -= (int) (money / 10);
        }

        public override void Deposit(decimal money)
        {
            Balance += money;
            Bonus += (int) (money / 5);
        }
    }
}
