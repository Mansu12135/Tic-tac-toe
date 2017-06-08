using System;

namespace ApplicationLayer
{
    internal class ComputerEngine
    {
        private readonly TicTacToe ComputerSide;
        private readonly Desk Desk;
        private readonly PlayingFieldMode GameMode;
        private Action<TicTacToe> InvokeWin;

        public ComputerEngine(TicTacToe computerSide, PlayingFieldMode mode, Action<TicTacToe> invokeWin)
        {
            GameMode = mode;
            if (GameMode == PlayingFieldMode.Basic) {
                Desk = new Desk(9);
            }
            else {
                Desk = new Desk(25);
            }
            InvokeWin = invokeWin;
            ComputerSide = computerSide;
            AttachEventHandlers();
        }

        private void AttachEventHandlers()
        {
            DetachEventHandlers();
            Desk.GameCompleted += RaiseCompleteGame;
        }

        internal (TicTacToe, int) OnPlayerMadeMove(int cell, TicTacToe side)
        {
            if (cell >= 0 || cell == Int32.MinValue)
            {
                if (cell >= 0)
                {
                    Desk[cell] = side;
                }
                if (ComputerSide != TicTacToe.Empty)
                {
                    return (ComputerSide, Desk.MakeMoveForPlayer(ComputerSide));
                }
            }
            return (TicTacToe.Empty, -1);
        }

        private void DetachEventHandlers()
        {
            Desk.GameCompleted -= RaiseCompleteGame;
        }

        internal void RaiseCompleteGame(TicTacToe side)
        {
            InvokeWin(side);
        }
    }

    public enum TicTacToe
    {
        Empty = 0,
        Dagger = 1,
        Toe = 2
    }
}

