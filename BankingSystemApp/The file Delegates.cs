using System;


namespace Banking_Application
{
    public delegate void TransactionEventHandler(object sender,TransactionEventArgs e);
    public delegate void LoginEventHandler(object sender, LoginEventArgs e);


}
