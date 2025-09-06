using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
 
    public class Person
    {


        //fields
        private string password;
        public event LoginEventHandler OnLogin;

        //properties
        public string Sin { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }
        
        //constructor
        public Person(string name, string sin)
        {
            Name = name;
            Sin = sin;
            password = sin.Substring(0, 3);
        }

        public void Login(string pwd)
        {
            if (pwd != password)
            {
                IsAuthenticated = false;
                OnLogin?.Invoke(this, new LoginEventArgs(Name, false, LoginEventType.Login));
                throw new AccountException(AccountExceptionType.PASSWORD_INCORRECT);
            }
            IsAuthenticated = true;
            OnLogin?.Invoke(this, new LoginEventArgs(Name, true, LoginEventType.Login));
        }

        public void Logout()
        {
            IsAuthenticated = false;
            OnLogin?.Invoke(this, new LoginEventArgs(Name, true, LoginEventType.Logout));
        }

        public override string ToString()
        {
            return $"{Name} [{Sin}] {(IsAuthenticated ? "authenticated" : "not authenticated")}";
        }
    }
}
