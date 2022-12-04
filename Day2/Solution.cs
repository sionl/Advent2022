﻿using System.Text;
using Day2.Models;

namespace Day2
{
    public class Solution
    {
        public void Run()
        {
            Console.WriteLine("Solving Day 2");
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
            var data = File.ReadAllText("Day2\\Input1.txt");
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

            File.WriteAllText("Day2\\Output2.txt", builder.ToString());
        }
    }
}