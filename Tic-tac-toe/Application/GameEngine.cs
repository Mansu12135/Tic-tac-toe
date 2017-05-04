using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class GameEngine
    {
        private readonly GameSettings Settings;
        public GameEngine(GameSettings settings)
        {
            Settings = settings;
        }
    }
}
