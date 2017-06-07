
namespace ApplicationLayer
{
    public class GameEngine
    {
        private readonly GameSettings Settings;
        private readonly ComputerEngine Engine;
        public GameEngine(GameSettings settings)
        {
            Settings = settings;
            Engine = new ComputerEngine(settings.EnemyIsComputer ? settings.EnemySide : TicTacToe.Empty,
                settings.PlayingFieldMode, side => OnGameCompleted?.Invoke("", side));
        }

        public void MakeMove(int cell, TicTacToe side)
        {
            (TicTacToe, int) answer = Engine.OnPlayerMadeMove(cell, side);
            if (answer.Item2 > -1)
            {
                OnMatrixChanged(answer.Item2, answer.Item1);
            }
        }

        public delegate void GameStatusHandler(string winnerName, TicTacToe winnerSide);

        public event GameStatusHandler OnGameCompleted;

        public delegate void MatrixChangedHandler(int cell, TicTacToe side);

        public event MatrixChangedHandler OnMatrixChanged;
    }
}
