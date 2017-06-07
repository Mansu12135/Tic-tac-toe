
namespace ApplicationLayer
{
    public class GameSettings
    {
        public PlayingFieldMode PlayingFieldMode { get; set; }

        public bool EnemyIsComputer { get; set; }

        public TicTacToe EnemySide { get; set; }
    }
    public enum PlayingFieldMode
    {
        Basic = 0,
        Extended = 1
    }
}
