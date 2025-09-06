using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public static class Logger
    {
        //fields
        private static List<string> loginEvents = new List<string>();
        private static List<string> transactionEvents = new List<string>();

        //constructors
        public static void LoginHandler(object sender, LoginEventArgs e)
        {
            loginEvents.Add($"{e.PersonName} {e.EventType} {(e.Success ? "successfully " : "unsuccessfully")} on {e.Time}");
        }
        //Methods
        public static void TransactionHandler(object sender, TransactionEventArgs e)
        {
            string type = e.Amount >= 0 ? "Deposit" : "Withdraw";
            transactionEvents.Add($"{e.Amount:C} {type} by {e.PersonName} on {e.Time}");
        }

        public static void DisplayLoginEvents()
        {
            for (int i = 0; i < loginEvents.Count; i++)
                Console.WriteLine($"{i + 1}. {loginEvents[i]}");
        }

        public static void DisplayTransactionEvents()
        {
            for (int i = 0; i < transactionEvents.Count; i++)
                Console.WriteLine($"{i + 1}. {transactionEvents[i]}");
        }
    }
}
