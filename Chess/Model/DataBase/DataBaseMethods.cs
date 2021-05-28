using Chess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.DataBase
{
    public static class DataBaseMethods
    {
        static DataBaseMethods()
        {
            LoginViewModel.logedEnemy = GetUser("PaulSali");
        }
        //Найти юзера для регистрации и логина
        public static Player GetUser(string nickName)
        {
            Player user;
            using(DBContexts connecting = new DBContexts())
            {
                user = connecting.Players.First(b => b.NickName.Equals(nickName));
            }
            return user;
        }
        public static bool FindUserByName(string nickName)
        {
            bool IsFound = false;
            using(DBContexts connecting = new DBContexts())
            {
                IsFound = connecting.Players.Any(b => b.NickName.Equals(nickName));
            }
            return IsFound;
        }
        public static Player FindUserPassword(string nickName, string password)
        {
            bool truePassword = false;
            using (DBContexts connecting = new DBContexts())
            {
                truePassword = connecting.Players.Any(b => b.NickName.Equals(nickName) && b.Password.Equals(password));
            }
            return truePassword ? GetUser(nickName) : null;
        }
        //Добавить юзера 
        public static bool AddUser(Player user)
        {
            if (FindUserByName(user.NickName))
                return false;
            using(DBContexts connecting = new DBContexts())
            {
                connecting.Players.Add(user);
                connecting.SaveChanges();
            }
            return true;
        }
        //Удалить юзера
        public static bool DeleteUser(string nickName)
        {
            if (!FindUserByName(nickName))
                return false;
            using(DBContexts connecting = new DBContexts())
            {
                Player player = connecting.Players
                .Where(o => o.NickName.Equals(nickName))
                .FirstOrDefault();
                connecting.Players.Remove(player);
                connecting.SaveChanges();
            }
            return true;
        }
        //получить топ (10/100) юзеров по победам
        public static List<Player> GetPlayersByWins()
        {
            List<Player> players = new List<Player>();
            using (DBContexts connecting = new DBContexts())
            {
                players = connecting.Players.Take(11).OrderByDescending(b => b.WinsCount).ToList();
            }
            return players;
        }
        //получить топ (10/100) юзеров по количеству партий
        public static List<Player> GetPlayersByAmountParties()
        {
            List<Player> players = new List<Player>();
            using (DBContexts connecting = new DBContexts())
            {
                players = connecting.Players.Take(11).OrderByDescending(b => b.AmountParties).ToList();
            }
            return players;
        }

        //получить топ (10/100) юзеров по длительности партии
        public static List<Player> GetPlayersByName()
        {
            List<Player> players = new List<Player>();
            using (DBContexts connecting = new DBContexts())
            {
                players = connecting.Players.Take(11).OrderBy(b => b.NickName).ToList();
            }
            return players;
        }
        public static void UpdateAfterWins(Player User, Player Enemy)
        {
            using (DBContexts connecting = new DBContexts())
            {
                Player player = connecting.Players.FirstOrDefault(b => b.NickName.Equals(User.NickName));
                player.WinsCount = User.WinsCount;
                player.AmountParties = User.AmountParties;
                connecting.SaveChanges();
                Player player2 = connecting.Players.FirstOrDefault(b => b.NickName.Equals(Enemy.NickName));
                player2.WinsCount = User.WinsCount;
                player2.AmountParties = player2.AmountParties;
            }
        }
    }
}
