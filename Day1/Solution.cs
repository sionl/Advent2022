using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Day1.Models;

namespace Day1
{
    public class Solution
    {
        public void Run()
        {
            Console.WriteLine("ReadData");
            ReadData();
        }

        private void ReadData()
        {
            var data = File.ReadAllText("Day1\\Input1.txt");
            var lines = data.Split(Environment.NewLine);
            var elves = new List<Elf>();

            var elf = new Elf() { Number = 1 };
            elves.Add(elf);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    var nextNumber = elf.Number + 1;
                    elf = new Elf() { Number = nextNumber };
                    elves.Add(elf);
                }
                else
                {
                    elf.Calories += int.Parse(line);
                }
            }

            SaveData(elves);
        }

        private void SaveData(List<Elf> elves)
        {
            var builder = new StringBuilder();
            foreach (var elf in elves)
            {
                builder.AppendLine($"{elf.Number} - {elf.Calories}");
            }

            builder.Append(Environment.NewLine);
            var mostCalories = elves.Max(x => x.Calories);
            builder.AppendLine($"The most Calories: {mostCalories}");

            builder.Append(Environment.NewLine);
            var top3 = elves.OrderByDescending(x => x.Calories).Take(3).Sum(x => x.Calories);
            builder.AppendLine($"The Top3 Calories: {top3}");

            File.WriteAllText("Day1\\Output.txt", builder.ToString());
        }
    }
}