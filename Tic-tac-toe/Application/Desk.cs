using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationLayer
{
    public class Desk : BaseEngine
    {
        private Dictionary<int, TicTacToe> Progress = new Dictionary<int, TicTacToe>();
        private MatrixOperation Operator;
        private Random Random;

        public Desk(int scale) : base(scale)
        {
            Random = new Random();
            Operator = new MatrixOperation(this);
            PlayerWays.Add(TicTacToe.Dagger, new WinningWay(TicTacToe.Dagger, 3));
            PlayerWays.Add(TicTacToe.Toe, new WinningWay(TicTacToe.Toe, 3));
        }


        public override TicTacToe this[int index]
        {
            get
            {
                if (!Progress.ContainsKey(index)) { Progress[index] = TicTacToe.Empty; }
                return Progress[index];
            }

            set
            {
                Progress[index] = value;
                Operator.UpdateDesk(index, value);
                if (PlayerWays[value].Ways.Any() && PlayerWays[value].Ways.Max(item => item.Count) == 3)
                {
                    OnGameComplete(value);
                    return;
                }
                if (!Progress.ContainsValue(TicTacToe.Empty))
                {
                    OnGameComplete(TicTacToe.Empty);
                }
            }
        }

        public int MakeMoveForPlayer(TicTacToe value)
        {
            if (PlayerWays[GetEnemy(value)].NeedsDefendEnemy() && !PlayerWays[value].NeedsDefendEnemy())
            {
                value = GetEnemy(value);
            }
            else if (!PlayerWays[value].Ways.Any() && Random != null)
            {
                int result;
                while (true)
                {
                    result = Random.Next(0, Scale);
                    if (!PlayerWays[GetEnemy(value)].Ways.Any() || result != Progress.First(item => item.Value == GetEnemy(value)).Key)
                    {
                        Random = null;
                        return result;
                    }
                }
            }
            if (!PlayerWays[value].Ways.Any())
            {
                return Progress.First(item => item.Value == TicTacToe.Empty).Key;
            }
            int maxScale = PlayerWays[value].Ways.Max(item => item.Count);
            return SelectCellByIndexInWinningWay(PlayerWays[value].Ways.First(item => item.Count == maxScale));
        }

        private int SelectCellByIndexInWinningWay(Way way)
        {
            int count = way.WinningIndexes.Count;
            for (int i = 0; i < count; i++)
            {
                if (Progress[way.WinningIndexes[i]] == TicTacToe.Empty) { return way.WinningIndexes[i]; }
            }
            return -1;
        }
    }
}
