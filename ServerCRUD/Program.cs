using System.Data;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Channels;
using System.Xml;
using ServerCRUD.Core.Domain.Entities;
using ServerCRUD.Infrastructure.Repositories;
using ServerCRUD.Infrastructure.Settings;

namespace ServerCRUD
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Существует некий json, в котором храниться путь к локальной папке,
                                                         например с данными о пользователях.
            There is a json file containing a pair of "filesUsersPath" : ".../Path/"
            */
            
            string json = File.ReadAllText("config.json");
            var config = JsonSerializer.Deserialize<ConfigRoot>(json) ?? throw new Exception("Error");

            string userDirPath = config.FileStorage.filesUsersPath;
            string messageDirPath = config.FileStorage.filesMessagesPath;

            FileMessageRepository fileMsgRep = new(messageDirPath);
            FileUserRepository fileUsersRep = new(userDirPath);

            //Console UI
            bool Active = false;
            do
            {
                Console.Clear();
                Console.WriteLine("1.Register new account\n2.Login account\nQ.Exit\nSelect the desired option...\n");
                var keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        try
                        {
                            Console.Clear();
                            Console.Write("Nickname: ");
                            string[] userData = new string[5];
                            userData[0] = Console.ReadLine();
                            Console.Write("Login: ");
                            userData[1] = Console.ReadLine();
                            Console.Write("Password: ");
                            userData[2] = Console.ReadLine();
                            Console.Write("PhoneNumber: ");
                            userData[3] = Console.ReadLine();
                            Console.Write("Mail: ");
                            userData[4] = Console.ReadLine();
                            Console.Write("Date of birth (YYYY.MM.DD): ");
                            string data = Console.ReadLine();
                            var nums = data.Split('.');
                            fileUsersRep.CreateUser(userData[0], userData[1],
                                userData[2], userData[3],
                                new DateTime(Convert.ToInt32(nums[0]),
                                             Convert.ToInt32(nums[1]),
                                             Convert.ToInt32(nums[2])), userData[4]);

                        Active = false;
                        }
                        catch { Active = true; }
                        break;
                    case ConsoleKey.D2:
                        Active = false;
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("This option does not exist! Try again...");
                        Console.ReadKey();
                        Active = true;
                        break;
                }
            } while (Active);
            
            User? session;
            
            do 
            {
                session = Start(fileUsersRep);
            } while (session == null);

            Load();

            while (!Active)
            {
                Console.WriteLine($"Account: {session.Nickname}\n1. Прочитать все сообщения\n2. Написать сообщение\n3. Настроить аккаунт\nQ.Завершить работу");
                //Дописать пункты меню
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("*Отображение сообщений*");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2: 
                        Console.Clear();
                        Console.WriteLine("*Создание сообщений*");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3: 
                        Console.Clear();
                        Console.WriteLine("*Выбрать что настроить*");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Q:
                        Active = true;
                        break;
                    default:
                        Console.WriteLine("Такого варианта не существует. \nНажмите любую кнопку чтобы продолжить...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static User Start(FileUserRepository fileUserRep)
        {
            User? user;
            Console.Clear();
            Console.Write("Login: ");
            try
            {
                user = fileUserRep.GetByLogin(Console.ReadLine() ?? "None");
                Console.Write("Password: ");
                if (user.Password == Console.ReadLine()) return user;
                else
                {
                    Console.WriteLine("Password is not correct!");
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        private static void Load()
        {
            Console.Clear();

            var rnd = new Random();
            int time;
            string message = "Добро пожаловать...\nДождитесь загрузки, чтобы продолжить:\n{";
            Console.Write(message);
            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 20; i++)
            {
                Console.Write(" ");
                time = rnd.Next(0, 300);
                Thread.Sleep(time);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("} 100%\n");
            Thread.Sleep(150);
            Console.WriteLine("Загрузка завершена, нажмите Enter чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
