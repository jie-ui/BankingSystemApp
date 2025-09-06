using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public class TransactionEventArgs : LoginEventArgs
    {
        private static bool success;

        //properties
        public decimal Amount { get; }

        //Constructor
        public TransactionEventArgs(string name, decimal amount, bool success)
     : base(name, success, LoginEventType.None)
        {
            Amount = amount;
        }




    }
}
