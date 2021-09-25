using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballPlayerLib;

namespace SimpleRESTService
{
    public class FootballPlayerManager
    {
        private static List<FootballPlayer> _players = new List<FootballPlayer>() {
            new FootballPlayer(0, "Henrik", 1000, 15),
            new FootballPlayer(1, "Peter", 800, 4),
            new FootballPlayer(2, "Lars", 1250, 9),
            new FootballPlayer(3, "Daniel", 25, 16)
        };

        public static List<FootballPlayer> Get()
        {
            return _players;
        }

        public static FootballPlayer Get(int id)
        {
            try 
            { 
                return _players.Find(p => p.Id == id); 
            }
            catch (ArgumentException e) 
            {
                throw new ArgumentException($"FootballPlayer with {id} not found");
            }        
        }

        public static bool Create(FootballPlayer player)
        {
            try 
            {
                _players.Add(player);
                return true;
            }
            catch (Exception e) {
                return false;
            }            
        }

        public static bool Update(int id, FootballPlayer player)
        {
            try 
            {
                FootballPlayer currentPlayer = Get(id);
                currentPlayer.Id = player.Id;
                currentPlayer.Name = player.Name;
                currentPlayer.Price = player.Price;
                currentPlayer.ShirtNumber = player.ShirtNumber;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static FootballPlayer Delete(int id)
        {
            try 
            {
                FootballPlayer player = Get(id);
                _players.Remove(player);
                return player;
            }
            catch (Exception e)
            {
                throw new ArgumentException($"FootballPlayer with {id} not found");
            }
        }
    }
}
