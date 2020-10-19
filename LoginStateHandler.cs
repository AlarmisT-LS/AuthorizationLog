using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationLog
{
    public delegate void LoginStateHandler(object sendler, LoginEventArgs e);
    public class LoginEventArgs
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Message { get; private set; }

        public LoginEventArgs(string message, string login, string password)
        {
            Message = message;
            Login = login;
            Password = password;
        }
    }

}
