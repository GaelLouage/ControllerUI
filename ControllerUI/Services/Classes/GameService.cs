using ControllerUI.Entities;
using ControllerUI.Extensions;
using ControllerUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUI.Services.Classes
{
    public class GameService : IGameService
    {
        public async Task<List<GameEntity>> GetAllGamesAsync()
        {
            var games = new List<GameEntity>();
            //TODO: remove hardcoded string
            var dir = Directory.GetFiles(@"C:\Users\louag\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Steam");
            for (int i = 0; i < dir.Length; i++)
            {
                games.Add(await new GameEntity().GetGameData(dir[i]));
            }
            return games;
        }
    }
}
