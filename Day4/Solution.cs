namespace Day4
{
    public class Solution : ISolution
    {
        private List<Pairs> list = new();

        private class Pairs
        {
            public string Line { get; set; } = string.Empty;
            public int Number1 { get; set; }
            public int Number2 { get; set; }
            public int Number3 { get; set; }
            public int Number4 { get; set; }
            public bool FullRange { get; set; } = false;
            public bool PartRange { get; set; } = false;
            public string Output => $"{Line} - {FullRange} - {PartRange}";
        }

        public void Run()
        {
            var data = File.ReadAllText("Day4\\Input1.txt");
            list = data.Split(Environment.NewLine).Select(x => new Pairs() { Line = x }).ToList();

            foreach (var item in list)
            {
                var array = item.Line.Split(',');
                var elv1 = array[0].Split('-');
                var elv2 = array[1].Split('-');

                item.Number1 = int.Parse(elv1[0]);
                item.Number2 = int.Parse(elv1[1]);
                item.Number3 = int.Parse(elv2[0]);
                item.Number4 = int.Parse(elv2[1]);

                item.FullRange = CheckFullRanges(item);
                item.PartRange = CheckPartRanges(item);
            }

            var builder = new OutputBuilder();
            builder.AppendLines(list.Select(item => item.Output));
            builder.AppendLine($"Full range Total: {list.Count(x => x.FullRange)}");
            builder.Append($"Part Range Total: {list.Count(x => x.PartRange)}");
            File.WriteAllText("Day4\\Output.txt", builder.ToString());
        }

        private bool CheckPartRanges(Pairs pairs)
        {
            if (pairs.Number1 >= pairs.Number3 && pairs.Number1 <= pairs.Number4)
            {
                return true;
            }

            if (pairs.Number2 >= pairs.Number3 && pairs.Number2 <= pairs.Number4)
            {
                return true;
            }

            if (pairs.Number2 >= pairs.Number4 && pairs.Number1 <= pairs.Number4)
            {
                return true;
            }

            return false;
        }

        private bool CheckFullRanges(Pairs pairs)
        {
            if (pairs.Number1 <= pairs.Number3 && pairs.Number2 >= pairs.Number4)
            {
                return true;
            }

            if (pairs.Number3 <= pairs.Number1 && pairs.Number4 >= pairs.Number2)
            {
                return true;
            }

            return false;
        }
    }
}