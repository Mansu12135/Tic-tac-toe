namespace Application
{
    internal class ComputerEngine
    {
        private readonly TicTacToeMatrix Matrix;
        private readonly TicTacToe ComputerSide;
        private readonly IMadeMovingEngine MadeMovingEngine;
        private readonly PlayingFieldMode GameMode;

        public ComputerEngine(TicTacToeMatrix matrix, TicTacToe computerSide, PlayingFieldMode mode)
        {
            Matrix = matrix;
            GameMode = mode;
            if (GameMode == PlayingFieldMode.Basic) {
                MadeMovingEngine = new BasicMadeMovingEngine();
            }
            else {
                MadeMovingEngine = new ExtendedMadeMovingEngine();
            }
            ComputerSide = computerSide;
            AttachEventHandlers();
        }

        private void AttachEventHandlers()
        {
            DetachEventHandlers();
            Matrix.OnMadeMove += OnPlayerMadeMove;
        }

        private void OnPlayerMadeMove(object sender, System.EventArgs e)
        {
            Matrix.CellList[MadeMovingEngine.MakeMove(Matrix.CellList)] = ComputerSide;
            Matrix.RaiseMatrixChanged(null, ComputerSide);
        }

        private void DetachEventHandlers()
        {
            Matrix.OnMadeMove -= OnPlayerMadeMove;
        }

        private void CompleteGame()
        {
            Matrix.RaiseCompleteGame(TicTacToe.Empty);
        }
    }
}
