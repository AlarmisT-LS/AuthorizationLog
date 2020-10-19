using System;
using System.IO;
using System.Threading.Tasks;

namespace AuthorizationLog
{
    class Program
    {
        static void Main(string[] args)
        {
            Logins logins = new Logins();
            bool lfs = true;
            string login, password;

            logins.mesinf += MessageInfo;
            logins.meserorr += MessageErorr;
            logins.handler += MessageLogInfoAsync;
            while (lfs)
            {
                Console.Write("Введите логин:");
                login = Console.ReadLine();
                Console.Write("Введите пароль:");
                password = Console.ReadLine();
                logins.Logs(login, password);
                Console.WriteLine();
            }
        }
        static async void MessageLogInfoAsync(object s, LoginEventArgs e)
        {
            string text = $"{DateTime.Now} : Login:{e.Login}   Password:{e.Password}     Result:{e.Message}\n";
            //string path = @"D:\Файлы C#";
            await Task.Run(() => File.AppendAllText($"log.txt", text));
        }
        static void MessageInfo(string mes)
        {
            Console.WriteLine($"[INFO]{mes}");
        }
        static void MessageErorr(string mes)
        {
            Console.WriteLine($"[ERORR]{mes}");
        }
    }
}
