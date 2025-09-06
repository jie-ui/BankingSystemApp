using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public class LoginEventArgs : EventArgs
    {
        //properties
        public string PersonName { get; }
        public bool Success {  get;  }
        public DayTime Time { get; }
        public LoginEventType EventType { get; }

        //Methods
        public LoginEventArgs (string name,bool success, LoginEventType loginEventType)
        {
            EventType = loginEventType;
            PersonName = name;
            Success = success;
            Time = Util.Now; 

        }

    }
}
