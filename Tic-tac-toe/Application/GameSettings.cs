using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GameSettings
    {
        public PlayingFieldMode PlayingFieldMode { get; set; }


        public bool EnemyIsComputer { get; set; }
    }
    public enum PlayingFieldMode
    {
        Basic = 0,
        Extended = 1
    }
}
