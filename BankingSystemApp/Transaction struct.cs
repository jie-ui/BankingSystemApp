using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public struct Transaction
    {
        //properties
        public string AccountNumber { get; }
        public decimal Amount { get; }

        public Person Originator { get; }
        public DayTime Time { get; }


        //constructor
        public Transaction (string accountNumber,
            decimal amount, Person person)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = Util.Now;
         }
        public override string ToString()
        {
            string type = Amount >= 0 ? "Deposit" : "Withdraw";
            return $"{AccountNumber} {type} ${Amount} by {Originator.Name}  {Time}";

        }


    }
}
