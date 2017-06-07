using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationLayer
{
    internal class MatrixOperation
    {
        private static BaseEngine Desk;
        private static int N;
        private static int NeedsToWin;
        private readonly StepStrategy[] Enums;

        private readonly Dictionary<StepStrategy, Action<ProgressContainer, TicTacToe>> GetIndexList = new Dictionary
            <StepStrategy, Action<ProgressContainer, TicTacToe>>
            {
                {
                    StepStrategy.Horizontal,
                    (progress, value) =>
                        DoUpdate(ind => Math.Min(progress.I * N + Math.Max(progress.J - NeedsToWin, 0) + ind, (progress.I + 1) * N - 1), value)
                },
                {
                    StepStrategy.Vertical,
                    (progress, value) =>
                        DoUpdate(
                            ind =>
                                Math.Min((Math.Max(progress.I - NeedsToWin, 0) + ind) * N + progress.J,
                                    N * (N - 1) + progress.J),
                            value)
                },
                {
                    StepStrategy.SideDiagonaly,
                    (progress, value) =>
                        DoUpdate(
                            ind => Validate(progress.I + NeedsToWin - ind, progress.J - NeedsToWin + ind), value)
                },
                {
                    StepStrategy.MainDiagonaly,
                    (progress, value) =>
                        DoUpdate(
                            ind => Validate(progress.I + NeedsToWin - ind, progress.J + NeedsToWin - ind), value)
                }
            };

        private static int Validate(int i, int j)
        {
            return i >= 0 && i < N && j >= 0 && j < N ? i * N + j : -1;
        }

        public MatrixOperation(BaseEngine desk)
        {
            Desk = desk;
            Enums = (StepStrategy[])Enum.GetValues(typeof(StepStrategy));
            N = (int)Math.Sqrt(desk.Scale);
            NeedsToWin = N - 1;
        }

       

        private static void DoUpdate(Func<int, int> getIndex, TicTacToe value)
        {
            int winningCount = 0;
            int n = NeedsToWin * 2 + 1;
            var way = new Way();
            for (int k = 0; k < n; k++)
            {
                int ind = getIndex(k);
                if (ind < 0) { continue; }
                if (Desk[ind] == Desk.GetEnemy(value) || way.WinningIndexes.Contains(ind)) { continue; }
                way.WinningIndexes.Add(ind);
                if (Desk[ind] == value) { way.Count++; }
            }
            AddOrUpdateWinningWay(value, way);
        }

        private static void AddOrUpdateWinningWay(TicTacToe value, Way way)
        {
            if (way.WinningIndexes.Count <= NeedsToWin) { return; }
            foreach (Way currentWay in Desk.PlayerWays[value].Ways)
            {
                if (CheckOnJoining(currentWay, way))
                {
                    currentWay.WinningIndexes.Union(way.WinningIndexes);
                    currentWay.Count = Math.Max(currentWay.Count, way.Count);
                    return;
                }
            }
            Desk.PlayerWays[value].Ways.Add(way);
        }

        private static bool CheckOnJoining(Way first, Way second)
        {
            int simplyCount = 0;
            Way shortlyWay = first.WinningIndexes.Count < second.WinningIndexes.Count ? first : second;
            Way largestWay = shortlyWay.Equals(first) ? second : first;
            foreach (int index in shortlyWay.WinningIndexes)
            {
                if (largestWay.WinningIndexes.Contains(index))
                {
                    simplyCount++;
                    if (simplyCount > 1) { return true; }
                    continue;
                }
                simplyCount = 0;
            }
            return false;
        }

        public void UpdateDesk(int cell, TicTacToe value, StepStrategy strategy = StepStrategy.Horizontal | StepStrategy.MainDiagonaly | StepStrategy.SideDiagonaly | StepStrategy.Vertical)
        {
            int i = cell / N;
            ProgressContainer container = new ProgressContainer { I = i, J = cell -  N * i };
            foreach (StepStrategy strat in Enums)
            {
                if (!strategy.HasFlag(strat)) { continue; }
                GetIndexList[strat].Invoke(container, value);
            }
            UpdateEnemyWinningWays(cell, Desk.GetEnemy(value));
        }

        private void UpdateEnemyWinningWays(int cell, TicTacToe enemyValue)
        {
            int count = Desk.PlayerWays[enemyValue].Ways.Count;
            for (int i = 0; i < count; i++)
            {
                if(!UpdateWay(cell, Desk.PlayerWays[enemyValue].Ways[i]))
                {
                    Desk.PlayerWays[enemyValue].Ways.RemoveAt(i);
                    i--;
                    count--;
                }
            }
            
        }

        private bool UpdateWay(int cell, Way way)
        {
            way.WinningIndexes.Remove(cell);
            return way.WinningIndexes.Count >= NeedsToWin + 1;
        }

        private struct ProgressContainer
        {
            public int I;
            public int J;
        }
    }

    [Flags]
    internal enum StepStrategy
    {
        Horizontal = 1,
        Vertical = 2,
        MainDiagonaly = 4,
        SideDiagonaly = 8
    }
}
