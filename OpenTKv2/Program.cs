using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game(800, 600, "Tutek"))
            {
                game.Run(60);
            }
        }
    }
}
