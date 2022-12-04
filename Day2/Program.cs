using System.Text;
using Models;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Reading Data");
        var games = ReadData();

        Console.WriteLine("Playing Games");
        var gameSimulator = new GameSimulator();
        games = gameSimulator.Play(games);

        Console.WriteLine("Saving Data");
        SaveData(games);
    }

    private static List<Game> ReadData()
    {
        var data = File.ReadAllText("Input1.txt");
        var lines = data.Split(Environment.NewLine);
        var games = new List<Game>();

        foreach (var line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                var array = line.Split(' ');
                if (array.Length >= 2)
                {
                    var game = new Game();
                    game.Opp = Char.Parse(array[0]);
                    game.MineStrat = Char.Parse(array[1]);
                    games.Add(game);
                }
            }
        }

        return games;
    }

    private static void SaveData(List<Game> games)
    {
        var builder = new StringBuilder();
        foreach (var game in games)
        {
            builder.AppendLine($"{game.Opp} {game.OppName} {game.MineStrat} {game.Mine} {game.MineName} - {game.Result} {game.Score}");
        }

        builder.Append(Environment.NewLine);
        var totalScore = games.Sum(x => x.Score);
        builder.AppendLine($"Total Score: {totalScore}");

        File.WriteAllText("Output2.txt", builder.ToString());
    }
}