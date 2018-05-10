using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountService service = new AccountService();
            var creditAccount1 = new CreditAccount();
            var creditAccount2 = new CreditAccount();
            var bonusAccount1 = new BonusAccount();
            var bonusAccount2 = new BonusAccount();
            service.AddAccount(creditAccount1);
            service.AddAccount(creditAccount2);
            service.AddAccount(bonusAccount1);
            service.AddAccount(bonusAccount2);

            service.Deposit(1, 100);
            service.Deposit(3, 100);
            service.Withdraw(3, 90);
            service.Withdraw(1, 50);
            service.Withdraw(1, 50);
            service.Withdraw(1, 50);

            Console.WriteLine("Balance of first account: " + service.GetAccountById(1).Balance);
            Console.WriteLine("Balance of third account: " + service.GetAccountById(3).Balance);

            BinaryWriter writer = new BinaryWriter(File.Open("test.bin", FileMode.OpenOrCreate));
            service.Save(writer);
            writer.Dispose();

            AccountService service2 = new AccountService();
            BinaryReader reader = new BinaryReader(File.Open("test.bin", FileMode.OpenOrCreate));
            service2.Load(reader);

            Console.WriteLine("Balance of first account: " + service2.GetAccountById(1).Balance);
            Console.WriteLine("Balance of third account: " + service2.GetAccountById(3).Balance);
        }
    }
}
