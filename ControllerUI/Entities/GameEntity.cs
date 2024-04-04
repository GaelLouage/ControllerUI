using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUI.Entities
{
    public class GameEntity
    {
        public string? Name { get; set; }    
        public string? Url { get; set; }
        public void Run()
        {
            Process.Start(Url);
        }
    }
}
