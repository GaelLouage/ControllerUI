using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUI.CustomExceptions
{
    public class Game404Exception : Exception
    {
        public Game404Exception() : base("Games not found!")
        {}
    }
}
