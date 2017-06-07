using System.Collections.Generic;

namespace ApplicationLayer
{
    public abstract class BaseEngine
    {

        protected BaseEngine(int scale)
        {
            Scale = scale;
            PlayerWays = new Dictionary<TicTacToe, WinningWay>();
        }

        public abstract TicTacToe this[int index] { get; set; }

        internal int Scale { get; private set; }

        internal Dictionary<TicTacToe, WinningWay> PlayerWays { get; private set; }

        internal virtual TicTacToe GetEnemy(TicTacToe value)
        {
            return value == TicTacToe.Dagger ? TicTacToe.Toe : TicTacToe.Dagger;
        }

        internal delegate void ComputerMakeMoveHandler(int cell);

        internal delegate void GameCompletedEventHandler(TicTacToe side);

        protected void OnGameComplete(TicTacToe side)
        {
            if (GameCompleted != null)
            {
                GameCompleted(side);
            }
        }

        protected void OnComputerMakeMove(int cell)
        {
            if (ComputerMadeMove != null)
            {
                ComputerMadeMove(cell);
            }
        }

        internal event GameCompletedEventHandler GameCompleted;

        internal event ComputerMakeMoveHandler ComputerMadeMove;
    }
}
