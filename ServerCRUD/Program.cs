using System.Text.Json;
using System.Threading.Channels;
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
        }
    }
}
