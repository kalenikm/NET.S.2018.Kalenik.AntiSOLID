using System;
using System.Collections.Generic;
using System.IO;

namespace Logic
{
    public class AccountService : IAccountService
    {
        private List<Account> _accounts = new List<Account>();
        private Logger _logger = new Logger();

        public void AddAccount(Account account)
        {
            if (ReferenceEquals(null, account))
            {
                throw new Exception();
            }

            _accounts.Add(account);
            _logger.Log("Account added.");
        }

        public Account[] GetAllAccounts()
        {
            return _accounts.ToArray();
        }

        public void Save(BinaryWriter writer)
        {
            if (ReferenceEquals(null, writer))
            {
                throw new Exception();
            }

            using (writer)
            {
                foreach (var account in _accounts)
                {
                    if (account is CreditAccount)
                    {
                        writer.Write("credit");
                        writer.Write(((CreditAccount)account).Id);
                        writer.Write(((CreditAccount)account).Balance);
                    }
                    else if (account is BonusAccount)
                    {
                        writer.Write("bonus");
                        writer.Write(((BonusAccount)account).Id);
                        writer.Write(((BonusAccount)account).Balance);
                        writer.Write(((BonusAccount)account).Bonus);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            _logger.Log("Accounts were saved in stream.");
        }

        public void Load(BinaryReader reader)
        {
            if (ReferenceEquals(null, reader))
            {
                throw new Exception();
            }

            _accounts.Clear();

            using (reader)
            {
                while (reader.BaseStream.Length > reader.BaseStream.Position)
                {
                    string type = reader.ReadString();
                    if (type == "credit")
                    {
                        var creditAccount = new CreditAccount(reader.ReadInt32(), reader.ReadDecimal());
                        _accounts.Add(creditAccount);
                    }
                    else if (type == "bonus")
                    {
                        var bonusAccount = new BonusAccount(reader.ReadInt32(), reader.ReadDecimal(), reader.ReadInt32());
                        _accounts.Add(bonusAccount);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            _logger.Log("Accounts were loaded from stream.");
        }

        public Account GetAccountById(int id)
        {
            if (id < 0)
            {
                throw new Exception();
            }

            foreach (var account in _accounts)
            {
                if (account is CreditAccount)
                {
                    if (((CreditAccount) account).Id == id)
                    {
                        return account;
                    }
                }
                else if (account is BonusAccount)
                {
                    if (((BonusAccount)account).Id == id)
                    {
                        return account;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }

            _logger.Log("There is no such account.");
            return null;
        }

        public void DeleteAccountById(int id)
        {
            if (id < 0)
            {
                throw new Exception();
            }

            foreach (var account in _accounts)
            {
                if (account.Id == id)
                {
                    _logger.Log("Account was deleted.");
                    _accounts.Remove(account);
                }
            }
            _logger.Log("Account is not founded.");
        }

        public void Withdraw(int id, decimal money)
        {
            var account = GetAccountById(id);
            if (account == null)
            {
                throw new Exception();
            }

            if (money <= 0)
            {
                throw new Exception();
            }

            account.Withdraw(money);
        }

        public void Deposit(int id, decimal money)
        {
            var account = GetAccountById(id);
            if (account == null)
            {
                throw new Exception();
            }

            if (money <= 0)
            {
                throw new Exception();
            }

            account.Deposit(money);
        }
    }
}