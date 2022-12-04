using Day2.Models;

namespace Day2
{
    public class GameSimulator
    {
        public List<Game> Play(List<Game> games)
        {
            foreach (var game in games)
            {
                game.OppNumber = GetNumber(game.Opp);
                game.OppName = GetName(game.Opp);

                game.Mine = GetMyPlay(game);
                game.MineNumber = GetNumber(game.Mine);
                game.MineName = GetName(game.Mine);

                game.Result = GetResult(game);
                game.Score = GetScore(game);
            }
            return games;
        }

        private Char GetMyPlay(Game game)
        {
            if (game.MineStrat == 'Y')
                return game.Opp;

            if (game.MineStrat == 'Z')
            {
                if (game.Opp == 'A')
                    return 'B';
                if (game.Opp == 'B')
                    return 'C';
                if (game.Opp == 'C')
                    return 'A';
            }

            if (game.MineStrat == 'X')
            {
                if (game.Opp == 'A')
                    return 'C';
                if (game.Opp == 'B')
                    return 'A';
                if (game.Opp == 'C')
                    return 'B';
            }

            return 'L';
        }

        private int GetScore(Game game)
        {
            var score = game.MineNumber;
            if (game.Result == 'W')
                score += 6;
            if (game.Result == 'D')
                score += 3;
            return score;
        }

        private Char GetResult(Game game)
        {
            if (game.MineNumber == game.OppNumber)
                return 'D';

            if (game.MineNumber == 1 && game.OppNumber == 3)
                return 'W';

            if (game.MineNumber == 2 && game.OppNumber == 1)
                return 'W';

            if (game.MineNumber == 3 && game.OppNumber == 2)
                return 'W';

            return 'L';
        }

        private int GetNumber(char input)
        {
            switch (input)
            {
                case 'A':
                case 'X':
                    return 1;
                case 'B':
                case 'Y':
                    return 2;
                case 'C':
                case 'Z':
                    return 3;
                default:
                    return 0;
            }
        }

        private string GetName(char input)
        {
            switch (input)
            {
                case 'A':
                case 'X':
                    return "Rock ";
                case 'B':
                case 'Y':
                    return "Paper ";
                case 'C':
                case 'Z':
                    return "Scissors";
                default:
                    return "None";
            }
        }
    }
}