using System.Collections.Generic;
using System.Linq;

namespace ApplicationLayer
{
    internal class WinningWay
    {
        internal readonly TicTacToe Player;
        private readonly int Scale;
        private int WinningCombination = 0;
        internal List<Way> Ways = new List<Way>();

        public WinningWay(TicTacToe player, int scale)
        {
            Player = player;
            Scale = scale;
        }

        public bool IsWinner()
        {
            UpdateWinningCount();
            return WinningCombination == Scale;
        }

        public bool NeedsDefendEnemy()
        {
            UpdateWinningCount();
            return WinningCombination == Scale - 1;
        }

        private void UpdateWinningCount()
        {
            WinningCombination = Ways.Any() ? Ways.Max(item => item.Count) : 0;
        }
    }

    public class Way
    {
        public List<int> WinningIndexes  = new List<int>();

        public int Count { get; set; }
    }
}
