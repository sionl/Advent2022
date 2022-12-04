namespace Day1
{
    public class Solution : ISolution
    {
        private class Elf
        {
            public int Number { get; set; }
            public int Calories { get; set; }
            public string Ouput => $"{Number} - {Calories}";
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

            var builder = new OutputBuilder();
            builder.AppendLines(elves.Select(x => x.Ouput));
            builder.AppendLine($"The Most Calories: {elves.Max(x => x.Calories)}");
            builder.Append($"The Top3 Calories: {elves.OrderByDescending(x => x.Calories).Take(3).Sum(x => x.Calories)}");
            File.WriteAllText("Day1\\Output.txt", builder.ToString());
        }
    }
}