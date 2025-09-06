using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application

{
   

    public class VisaAccount : Account, ITransaction
    {
        //Field
        private decimal creditLimit;
        private static decimal INTEREST_RATE = 0.1995m;

        //Construcor
        public VisaAccount(decimal balance = 0, decimal limit = 1200) : base("VS", balance)
        {
            creditLimit = limit;
        }

        public void  Deposit(decimal amount, Person person)
        {
            Pay(amount, person);
        }

        public void Withdraw(decimal amount, Person person)
        {
            Purchase(amount, person);
        }

        public void Pay(decimal amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public void Purchase(decimal amount, Person person)
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
            if (Balance - amount < -creditLimit)
            {
                base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(AccountExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }
            base.Deposit(-amount, person);
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public override void PrepareMonthlyReport()
        {
            decimal interest = (LowestBalance * INTEREST_RATE) / 12;
            Balance -= interest;
            transactions.Clear();
        }
    }


}
