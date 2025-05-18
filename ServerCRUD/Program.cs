using ServerCRUD.Core.Domain.Entities;

namespace ServerCRUD
{
    public class Program
    {
        static void Main(string[] args)
        {
            new User(1, Role.Admin, "Vad1ch", "1666", "+79115880650", 21, "IlyaRogOfficial@yandex.ru");
        }
    }
}
