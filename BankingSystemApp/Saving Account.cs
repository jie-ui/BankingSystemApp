using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    //  SAVING ACCOUNT
    public interface ITransaction
    {
        void Deposit(decimal amount, Person person);
        void Withdraw(decimal amount, Person person);
    }

    public class SavingAccount : Account, ITransaction
    {
        private static decimal COST_PER_TRANSACTION = 0.5m;
        private static decimal INTEREST_RATE = 0.015m;

        public SavingAccount(decimal balance = 0) : base("SV", balance) { }

        public void Deposit(decimal amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public void Withdraw(decimal amount, Person person)
        {
            if (!IsUser(person))
            {
                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(AccountExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            if (!person.IsAuthenticated)
            {
                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(AccountExceptionType.USER_NOT_LOGGED_IN);
            }
            if (amount > Balance)
            {
                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(AccountExceptionType.INSUFFICIENT_FUNDS);
            }
            base.Deposit(-amount, person);
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public override void PrepareMonthlyReport()
        {
            decimal serviceFee = transactions.Count * COST_PER_TRANSACTION;
            decimal interest = (LowestBalance * INTEREST_RATE) / 12;
            Balance += interest - serviceFee;
            transactions.Clear();
        }
    }

}
