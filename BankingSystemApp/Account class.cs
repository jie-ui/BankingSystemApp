using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public abstract class Account
    {
        //Field
        private static int LAST_NUMBER = 100000;
        protected readonly List<Person> users = new List<Person>();
        protected readonly List<Transaction> transactions = new List<Transaction>();
        public IReadOnlyList<Transaction> Transactions => transactions;
       
        //properties
        public string Number { get; }
        public decimal Balance { get; protected set; }
        public decimal LowestBalance { get; protected set; }
        public event TransactionEventHandler OnTransaction;//identification event

        //consturter
        public Account(string type, decimal balance)
        {
            Number = $"{type}-{LAST_NUMBER++}";
            Balance = balance;
            LowestBalance = balance;
        }


        //Method
        protected void Deposit(decimal amount, Person person)
        {
            Balance += amount;
            if (Balance < LowestBalance) LowestBalance = Balance;
            transactions.Add(new Transaction(Number, amount, person));
        }

        public void AddUser(Person person)
        {
            users.Add(person);
        }

        public bool IsUser(Person person)
        {
            return users.Any(u => u.Name == person.Name && u.Sin == person.Sin);
        }

        public virtual void OnTransactionOccur(object sender, TransactionEventArgs e)
        {
            OnTransaction?.Invoke(sender, e);//inform 
        }

        public abstract void PrepareMonthlyReport();

        public override string ToString()
        {
            string list = $"{Number}\n";
            foreach (Person p in users)
                list += p + "\n";
            list += Balance;
            foreach (Transaction t in transactions)
                list += t + "\n";
            return list;
        }

    }
}
