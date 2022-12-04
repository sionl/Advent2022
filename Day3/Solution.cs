namespace Day3
{
    public class Solution : ISolution
    {
        private List<Rucksack> list = new();
        private List<Badge> badges = new();

        private class Rucksack
        {
            public string Contents { get; set; } = string.Empty;
            public string Compartment1 { get; set; } = string.Empty;
            public string Compartment2 { get; set; } = string.Empty;
            public char Part { get; set; }
            public int Priority { get; set; }
            public string Output => $"{Contents} - {Compartment1} {Compartment2} - {Part} {Priority}";
        }

        private class Badge
        {
            public char Letter { get; set; }
            public int Priority { get; set; }
            public string Output => $"{Letter} - {Priority}";
        }

        public void Run()
        {
            var data = File.ReadAllText("Day3\\Input.txt");
            var lines = data.Split(Environment.NewLine);
            list = lines.Select(x => new Rucksack() { Contents = x }).ToList();

            foreach (var item in list)
            {
                FindItem(item);
            }

            for (int i = 0; i < list.Count; i += 3)
            {
                var badge = FindBadge(list[i], list[i + 1], list[i + 2]);
                if (badge != null)
                {
                    badges.Add(badge);
                }
            }

            var builder = new OutputBuilder();
            builder.AppendLines(list.Select(x => x.Output));
            builder.AppendLines(badges.Select(x => x.Output));
            builder.AppendLine($"Total Priority: {list.Sum(x => x.Priority)}");
            builder.Append($"Badge Priority: {badges.Sum(x => x.Priority)}");
            File.WriteAllText("Day3\\Output.txt", builder.ToString());
        }

        private void FindItem(Rucksack rucksack)
        {
            var mid = rucksack.Contents.Length / 2;
            rucksack.Compartment1 = rucksack.Contents.Substring(0, mid);
            rucksack.Compartment2 = rucksack.Contents.Substring(mid);
            foreach (var item in rucksack.Compartment1)
            {
                if (rucksack.Compartment2.Contains(item))
                {
                    rucksack.Part = item;
                    rucksack.Priority = GetPriority(rucksack.Part);
                    break;
                }
            }
        }

        private Badge FindBadge(Rucksack suck1, Rucksack suck2, Rucksack suck3)
        {
            foreach (var item1 in suck1.Contents)
            {
                if (suck2.Contents.Contains(item1))
                {
                    foreach (var item2 in suck2.Contents)
                    {
                        if (suck3.Contents.Contains(item1))
                        {
                            var badge = new Badge();
                            badge.Letter = item1;
                            badge.Priority = GetPriority(item1);
                            return badge;
                        }
                    }
                }
            }
            return new Badge();
        }

        private int GetPriority(Char letter)
        {
            if (Char.IsLower(letter))
            {
                return (int)letter - 96;
            }

            return (int)letter - 38;
        }
    }
}