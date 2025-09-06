using System;
using System.Collections.Generic;
using System.Linq;
using Banking_Application;

namespace Banking.GUI
{
    internal static class CoreBridge
    {
       
        public static Person LoginByNameAndSin(string name, string sinOrPwd)
        {
            var n = NormalizeName(name);
            var tokenDigits = DigitsOnly(sinOrPwd);

            //  Bank inital
            var _ = Bank.USERS.Count;

            foreach (var user in Bank.USERS.Values)
            {
                if (!string.Equals(NormalizeName(user.Name), n, StringComparison.OrdinalIgnoreCase))
                    continue;

                var uDigits = DigitsOnly(user.Sin);
                var pwd3 = (user.Sin ?? "").Length >= 3 ? (user.Sin ?? "").Substring(0, 3) : "";
                var pwd3Dig = DigitsOnly(pwd3);

                if (tokenDigits.Length == 3)
                {
                    if (tokenDigits == pwd3Dig || (sinOrPwd ?? "").Trim() == pwd3)
                    {
                        user.Login(pwd3);
                        return user;
                    }
                }
                else
                {
                    if (tokenDigits == uDigits || NormalizeSin(sinOrPwd) == NormalizeSin(user.Sin))
                    {
                        user.Login(pwd3);
                        return user;
                    }
                }
            }
            return null;
        }

        private static string DigitsOnly(string s)
            => new string((s ?? "").Where(char.IsDigit).ToArray());

        private static string NormalizeName(string s)
        {
            var filtered = new string((s ?? "").Trim().Where(ch => char.IsLetter(ch) || ch == ' ').ToArray());
            while (filtered.Contains("  ")) filtered = filtered.Replace("  ", " ");
            return filtered;
        }

        private static string NormalizeSin(string s)
        {
            var x = (s ?? "").Trim().Replace(" ", "");
            return x.Replace("–", "-").Replace("—", "-").Replace("－", "-").Replace("−", "-");
        }
        //return account
        public static List<Account> AccountsOf(Person p)
        {
            return Bank.ACCOUNTS.Values.Where(a => a.IsUser(p)).ToList();
        }

        

        public static string NumberOf(Account a) { return a.Number; }
        public static decimal BalanceOf(Account a) { return a.Balance; }
        public static IReadOnlyList<Transaction> TransactionsOf(Account a) => a.Transactions;

        //deposit/withdraw
        public static void Deposit(Account a, decimal amount, Person actor)
        {
            if (a == null) throw new ArgumentNullException("a");
            if (amount <= 0m) throw new ArgumentException("金Amount must be greater than zero.", "amount");

            if (a is CheckingAccount c) { c.Deposit(amount, actor); return; }
            if (a is SavingAccount s) { s.Deposit(amount, actor); return; }
            if (a is VisaAccount v) { v.Deposit(amount, actor); return; }
            throw new Exception("Unsupported account type：" + a.GetType().Name);
        }

        public static void Withdraw(Account a, decimal amount, Person actor)
        {
            if (a == null) throw new ArgumentNullException("a");
            if (amount <= 0m) throw new ArgumentException("Amount must be greater than zero.", "amount");

            if (a is CheckingAccount c) { c.Withdraw(amount, actor); return; }
            if (a is SavingAccount s) { s.Withdraw(amount, actor); return; }
            if (a is VisaAccount v) { v.Withdraw(amount, actor); return; }
            throw new Exception("Unsupported account type：" + a.GetType().Name);
        }
    }
}


