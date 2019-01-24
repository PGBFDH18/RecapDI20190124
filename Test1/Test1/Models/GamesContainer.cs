using LudoGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Models
{
    public class GamesContainer
    {
        private Dictionary<string, LudoGame> ludoGames;

        public GamesContainer()
        {
            ludoGames = new Dictionary<string, LudoGame>();
        }

        public LudoGame GetGame(string id)
        {
            if (!ludoGames.ContainsKey(id)) {
                ludoGames.Add(id, new LudoGame(new Diece()));
            }

            return ludoGames[id];
        }

        public void CreateNewLudoGame()
        {
            var game = new LudoGame(new Diece());
            ludoGames.Add(Guid.NewGuid().ToString(), game);
        }

        public List<string> GetAllGames()
        {
            return ludoGames.Select(d => d.Key).ToList();
        }
    }
}
