using ControllerUI.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUI.Extensions
{
    public static class GameExtension
    {
        public static async  Task<GameEntity?> GetGameData(this string gameExe, string fileData)
        {
            return  new GameEntity()
            {
                Name = gameExe
            };
        }
    }
}
