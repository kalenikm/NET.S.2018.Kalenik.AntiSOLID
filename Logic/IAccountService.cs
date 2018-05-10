using System.IO;

namespace Logic
{
    public interface IAccountService
    {
        void AddAccount(Account account);
        Account[] GetAllAccounts();
        void Save(BinaryWriter writer);
        void Load(BinaryReader reader);
        Account GetAccountById(int id);
        void DeleteAccountById(int id);

        void Withdraw(int id, decimal money);
        void Deposit(int id, decimal money);
    }
}