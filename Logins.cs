using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationLog
{
    class Logins
    {
        public LoginStateHandler handler, reglog;
        public Action<string> mesinf, meserorr;
        const string log = "Nikita";
        const string pas = "123";

        public void Logs(string l, string p)
        {
            string text;
            if (log == l)
            {
                if (pas == p)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    text = "Вход успешный";
                    mesinf?.Invoke(text);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    text = "Пароль не верный!";
                    meserorr?.Invoke(text);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                text = "Логин не верный";
                meserorr?.Invoke(text);
                Console.ResetColor();
            }
            handler?.Invoke(this, new LoginEventArgs(text, l, p));
        }

    }
}
