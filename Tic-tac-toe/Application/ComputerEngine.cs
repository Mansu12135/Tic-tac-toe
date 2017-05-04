namespace Application
{
    internal class ComputerEngine
    {
        private readonly TicTacToeMatrix Matrix;
        private readonly TicTacToe ComputerSide;

        public ComputerEngine(TicTacToeMatrix matrix, TicTacToe computerSide)
        {
            Matrix = matrix;
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
            Matrix.CellList[0] = ComputerSide;
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
