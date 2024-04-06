using ControllerUI.Entities;
using ControllerUI.Extensions;
using ControllerUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUI.Services.Classes
{
    public class GameService : IGameService
    {
        
        public async Task<List<GameEntity>> GetAllGamesAsync()
        {
         
            //TODO: remove hardcoded string
            var dir = Directory.GetDirectories(@"F:\Steamie\steamapps\common");
            var games = new List<GameEntity>();
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await Task.WhenAll(new List<Task>() 
            {
                TaskAdder(games, dir, dir.Length / 4),
                TaskAdder(games, dir, dir.Length / 4, 1, 2),
                TaskAdder(games, dir, dir.Length / 4, 2, 3),
                TaskAdder(games, dir, dir.Length / 4, 3, 4)
            });
            stopwatch.Stop();
            return games;
        }

        private static Task TaskAdder(List<GameEntity> games, string[] dir, int dirDivised, int firstMultiplication = 1, int secondMultiplication = 1)
        {
            return Task.Run(async () =>
            {
                for (int i = dirDivised * firstMultiplication; i < dirDivised * secondMultiplication; i++)
                {
                    var gameDirData = Directory.GetFiles(dir[i]);
                    for (int j  = 0; j < gameDirData.Count(); j++)
                    {
                        if (gameDirData[j].EndsWith(".exe"))
                        {
                                games.Add(new GameEntity() { Name = gameDirData[j]});
                                break;
                        }
                    }
                }
            });
        }
    }
}
