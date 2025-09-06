using System.Collections.Generic;
using Banking_Application;

namespace Banking.GUI
{
    internal static class AppState
    {
        public static Person CurrentUser;
        public static List<Account> CurrentAccounts = new List<Account>();
    }
}
