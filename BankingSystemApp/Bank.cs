using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Text.Json;
namespace Banking_Application
{
    public static class Bank
    {
        public static readonly Dictionary<string, Account> ACCOUNTS = new Dictionary<string, Account>();
        public static readonly Dictionary<string, Person> USERS = new Dictionary<string, Person>();

        static Bank()
        {
            // Add predefined users
            AddUser("Narendra", "1234-5678");   //0
            AddUser("Ilia", "2345-6789");       //1
            AddUser("Mehrdad", "3456-7890");    //2
            AddUser("Vinay", "4567-8901");      //3
            AddUser("Arben", "5678-9012");      //4
            AddUser("Patrick", "6789-0123");    //5
            AddUser("Yin", "7890-1234");        //6
            AddUser("Hao", "8901-2345");        //7
            AddUser("Jake", "9012-3456");       //8
            AddUser("Mayy", "1224-5678");       //9
            AddUser("Nicoletta", "2344-6789");  //10

            // Add predefined accounts
            AddAccount(new VisaAccount());                        // VS-100000
            AddAccount(new VisaAccount(150, -500));              // VS-100001
            AddAccount(new SavingAccount(5000));                 // SV-100002
            AddAccount(new SavingAccount());                     // SV-100003
            AddAccount(new CheckingAccount(2000));               // CK-100004
            AddAccount(new CheckingAccount(1500, true));         // CK-100005
            AddAccount(new VisaAccount(50, -550));               // VS-100006
            AddAccount(new SavingAccount(1000));                 // SV-100007

            // Associate users to accounts
            string number = "VS-100000";
            AddUserToAccount(number, "Narendra");
            AddUserToAccount(number, "Ilia");
            AddUserToAccount(number, "Mehrdad");

            number = "VS-100001";
            AddUserToAccount(number, "Vinay");
            AddUserToAccount(number, "Arben");
            AddUserToAccount(number, "Patrick");

            number = "SV-100002";
            AddUserToAccount(number, "Yin");
            AddUserToAccount(number, "Hao");
            AddUserToAccount(number, "Jake");

            number = "SV-100003";
            AddUserToAccount(number, "Mayy");
            AddUserToAccount(number, "Nicoletta");

            number = "CK-100004";
            AddUserToAccount(number, "Mehrdad");
            AddUserToAccount(number, "Arben");
            AddUserToAccount(number, "Yin");

            number = "CK-100005";
            AddUserToAccount(number, "Jake");
            AddUserToAccount(number, "Nicoletta");

            number = "VS-100006";
            AddUserToAccount(number, "Ilia");
            AddUserToAccount(number, "Vinay");

            number = "SV-100007";
            AddUserToAccount(number, "Patrick");
            AddUserToAccount(number, "Hao");
        }

        // Add a new user
        public static void AddUser(string name, string sin)
        {
            if (USERS.ContainsKey(sin))
                throw new AccountException(AccountExceptionType.USER_ALREADY_EXIST);

            var person = new Person(name, sin);
            person.OnLogin += Logger.LoginHandler;
            USERS[sin] = person;
        }

        // Add a new account
        public static void AddAccount(Account account)
        {
            account.OnTransaction += Logger.TransactionHandler;
            ACCOUNTS[account.Number] = account;
        }

        // Add user to account (by name)
        public static void AddUserToAccount(string number, string name)
        {
            var account = GetAccount(number);
            var person = GetUser(name);
            account.AddUser(person);
        }

        // Get account by account number
        public static Account GetAccount(string number)
        {
            if (!ACCOUNTS.ContainsKey(number))
                throw new AccountException(AccountExceptionType.ACCOUNT_DOES_NOT_EXIST);
            return ACCOUNTS[number];
        }

        // Get user by name (not SIN!)
        public static Person GetUser(string name)
        {
            foreach (var user in USERS.Values)
            {
                if (user.Name == name)
                    return user;
            }
            throw new AccountException(AccountExceptionType.USER_DOES_NOT_EXIST);
        }

        // Print all accounts
        public static void PrintAccounts()
        {
            foreach (var account in ACCOUNTS.Values)
                Console.WriteLine(account);
        }

        // Print all users
        public static void PrintUsers()
        {
            foreach (var user in USERS.Values)
                Console.WriteLine(user);
        }

        // Save accounts to JSON
        /*
        public static void SaveAccounts(string filename)
        {
            string json = JsonSerializer.Serialize(ACCOUNTS.Values, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }

        // Save users to JSON
        public static void SaveUsers(string filename)
        {
            string json = JsonSerializer.Serialize(USERS.Values, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }

        // Get all transactions across accounts
        public static List<Transaction> GetAllTransactions()
        {
            return ACCOUNTS.Values.SelectMany(a => a.Transactions).ToList();
        }
        */
    }
}
