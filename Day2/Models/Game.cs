namespace Models
{
    public class Game
    {
        public Char Opp { get; set; }
        public int OppNumber { get; set; }
        public string OppName { get; set; } = string.Empty;
        public Char MineStrat { get; set; }
        public Char Mine { get; set; }
        public int MineNumber { get; set; }
        public string MineName { get; set; } = string.Empty;
        public Char Result { get; set; }
        public int Score { get; set; }
    }
}