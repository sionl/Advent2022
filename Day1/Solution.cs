using System.Text;

namespace Day1
{
    public class Solution : ISolution
    {
        private class Elf
        {
            public int Number { get; set; }
            public int Calories { get; set; }
        }

        public void Run()
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

            var builder = new StringBuilder();
            foreach (var item in elves)
            {
                builder.AppendLine($"{item.Number} - {item.Calories}");
            }

            builder.Append(Environment.NewLine);
            var mostCalories = elves.Max(x => x.Calories);
            builder.AppendLine($"The Most Calories: {mostCalories}");

            builder.Append(Environment.NewLine);
            var top3 = elves.OrderByDescending(x => x.Calories).Take(3).Sum(x => x.Calories);
            builder.Append($"The Top3 Calories: {top3}");

            File.WriteAllText("Day1\\Output.txt", builder.ToString());
        }
    }
}