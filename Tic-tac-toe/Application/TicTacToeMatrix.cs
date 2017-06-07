using System;
using System.Collections.Generic;

namespace MyApplication
{
    public class TicTacToeMatrix
    {
        private readonly List<TicTacToe> Cells;
        private readonly int CellsInRow;

        internal List<TicTacToe> CellList => Cells;

        public TicTacToeMatrix(PlayingFieldMode playingFieldMode)
        {
            CellsInRow = playingFieldMode == PlayingFieldMode.Basic ? 3 : 25;
            Cells = new List<TicTacToe>((int)Math.Pow(CellsInRow, 2.0));
            //by Kate
            while (Cells.Count < Cells.Capacity)
            {
                Cells.Add(TicTacToe.Empty);
            }
        }

        public TicTacToe this[int i, int j]
        {
            get { return Cells[i * CellsInRow + j]; }
            set
            {
                if (Cells[i * CellsInRow + j] != TicTacToe.Empty) { return; }
                Cells[i * CellsInRow + j] = value;
                OnMadeMove?.Invoke(null, null);
            }
        }

        internal void RaiseCompleteGame(TicTacToe side)
        {
            OnGameCompleted?.Invoke("", side);
        }

        internal void RaiseMatrixChanged(object sender, TicTacToe feature)
        {
            OnMatrixChanged?.Invoke("", feature);//It needs for binding only if computer made move. Talk with Kate about sending information between Application and UI Layer
        }

        public delegate void GameStatusHandler(string winnerName, TicTacToe winnerSide);

        public event GameStatusHandler OnGameCompleted;

        public delegate void MatrixChangedHandler(string winnerName, TicTacToe winnerSide);

        public event MatrixChangedHandler OnMatrixChanged;

        internal event EventHandler OnMadeMove;
    }

    public enum TicTacToe
    {
        Empty = 0,
        Dagger = 1,
        Toe = 2
    }
}
