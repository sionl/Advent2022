namespace Day8
{
    public class Solution : ISolution
    {
        private Tree[,] map;

        private class Tree
        {
            public int Height { get; set; }
            public int Score { get; set; }
        }

        public void Run()
        {
            ReadData();
            OutputData();
        }

        private void ReadData()
        {
            var data = System.IO.File.ReadAllText("Day8\\Input.txt").Split(Environment.NewLine);
            var xLen = data.Length;
            var yLen = data[0].Length;
            map = new Tree[xLen, yLen];

            for (int x = 0; x < data.Length; x++)
            {
                var line = data[x];
                for (int y = 0; y < line.Length; y++)
                {
                    var tree = new Tree();
                    tree.Height = int.Parse(line[y].ToString());
                    map[x, y] = tree;
                }
            }
        }

        private int GetScore(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return 0;
            }

            if (x == map.GetLength(0) - 1)
            {
                return 0;
            }

            if (y == map.GetLength(1) - 1)
            {
                return 0;
            }

            return GetAbove(x, y) * GetRight(x, y) * GetBelow(x, y) * GetLeft(x, y);
        }

        private int GetAbove(int x, int y)
        {
            var score = 0;
            var tree = map[x, y];
            x -= 1;
            while (x >= 0)
            {
                score += 1;
                var atree = map[x, y];
                if (atree.Height >= tree.Height)
                {
                    break;
                }
                x -= 1;
            }
            return score;
        }

        private int GetLeft(int x, int y)
        {
            var score = 0;
            var tree = map[x, y];
            y -= 1;
            while (y >= 0)
            {
                score += 1;
                var atree = map[x, y];
                if (atree.Height >= tree.Height)
                {
                    break;
                }
                y -= 1;
            }
            return score;
        }

        private int GetRight(int x, int y)
        {
            var score = 0;
            var tree = map[x, y];
            y += 1;
            while (y < map.GetLength(1))
            {
                score += 1;
                var atree = map[x, y];
                if (atree.Height >= tree.Height)
                {
                    break;
                }
                y += 1;
            }
            return score;
        }

        private int GetBelow(int x, int y)
        {
            var score = 0;
            var tree = map[x, y];
            x += 1;
            while (x < map.GetLength(0))
            {
                score += 1;
                var atree = map[x, y];
                if (atree.Height >= tree.Height)
                {
                    break;
                }
                x += 1;
            }
            return score;
        }

        private void OutputData()
        {
            var max = 0;
            var builder = new OutputBuilder();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    var tree = map[x, y];
                    tree.Score = GetScore(x, y);
                    if (tree.Score > max)
                    {
                        max = tree.Score;
                    }
                    builder.Append($"{tree.Height} ({tree.Score.ToString()}), ");
                }
                builder.AppendNewLine();
            }

            builder.AppendNewLine();
            builder.Append($"Max: {max}");
            System.IO.File.WriteAllText("Day8\\Output.txt", builder.ToString());
        }
    }
}