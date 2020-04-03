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
            using (Game game = new Game(OpenTKv2.Common.View.Width, OpenTKv2.Common.View.Height, "Tutek"))
            {
                game.Run(60);
            }
        }
    }
}
