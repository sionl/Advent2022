using System.Text;

namespace Day4
{
    public class Solution : ISolution
    {
        private List<Pairs> list = new();

        private class Pairs
        {
            public string Line { get; set; } = string.Empty;
            public bool FullRange { get; set; } = false;
            public bool PartRange { get; set; } = false;
        }

        public void Run()
        {
            var data = File.ReadAllText("Day4\\Input1.txt");
            var lines = data.Split(Environment.NewLine);
            list = lines.Select(x => new Pairs() { Line = x }).ToList();

            foreach (var item in list)
            {
                item.FullRange = CheckFullRanges(item);
                item.PartRange = CheckPartRanges(item);
            }

            var builder = new StringBuilder();
            foreach (var item in list)
            {
                builder.AppendLine($"{item.Line} - {item.FullRange} - {item.PartRange}");
            }

            builder.Append(Environment.NewLine);
            var totalFull = list.Count(x => x.FullRange);
            builder.Append($"Full range Total: {totalFull}");

            builder.Append(Environment.NewLine);
            var totalPart = list.Count(x => x.PartRange);
            builder.Append($"Part Range Total: {totalPart}");

            File.WriteAllText("Day4\\Output.txt", builder.ToString());
        }

        private bool CheckPartRanges(Pairs pairs)
        {
            var array = pairs.Line.Split(',');
            var elv1 = array[0].Split('-');
            var elv2 = array[1].Split('-');

            var num1 = int.Parse(elv1[0]);
            var num2 = int.Parse(elv1[1]);
            var num3 = int.Parse(elv2[0]);
            var num4 = int.Parse(elv2[1]);

            if (num1 >= num3 && num1 <= num4)
            {
                return true;
            }

            if (num2 >= num3 && num2 <= num4)
            {
                return true;
            }

            if (num2 >= num4 && num1 <= num4)
            {
                return true;
            }

            return false;
        }

        private bool CheckFullRanges(Pairs pairs)
        {
            var array = pairs.Line.Split(',');
            var elv1 = array[0].Split('-');
            var elv2 = array[1].Split('-');

            var num1 = int.Parse(elv1[0]);
            var num2 = int.Parse(elv1[1]);
            var num3 = int.Parse(elv2[0]);
            var num4 = int.Parse(elv2[1]);

            if (num1 <= num3 && num2 >= num4)
            {
                return true;
            }

            if (num3 <= num1 && num4 >= num2)
            {
                return true;
            }

            return false;
        }
    }
}