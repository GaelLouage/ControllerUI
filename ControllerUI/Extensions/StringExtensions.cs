using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUI.Extensions
{
    public static class StringExtensions
    {
        public  static string SetGameName(this string gameName, string fileData) => fileData
               .Split('\\')
               .LastOrDefault();
        public static async Task<string> SetGameUrlAsync(this string gameUrl, string fileData) =>
                 (await File.ReadAllLinesAsync(fileData)).FirstOrDefault(f => f
                .ToLower()
                .StartsWith("url="))?
                .Split("URL=")[^1];

    }
}
