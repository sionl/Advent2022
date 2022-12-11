namespace Day8
{
    public class Solution1 : ISolution
    {
        private Tree[,] map;

        private class Tree
        {
            public int Height { get; set; }
            public bool Visable { get; set; }
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

        private bool CheckData(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return true;
            }

            if (x == map.GetLength(0) - 1)
            {
                return true;
            }

            if (y == map.GetLength(1) - 1)
            {
                return true;
            }

            var tree = map[x, y];

            if (tree.Height > GetMaxAbove(x - 1, y))
            {
                return true;
            }

            if (tree.Height > GetMaxBelow(x + 1, y))
            {
                return true;
            }

            if (tree.Height > GetMaxLeft(x, y - 1))
            {
                return true;
            }

            if (tree.Height > GetMaxRight(x, y + 1))
            {
                return true;
            }

            return false;
        }

        private int GetMaxAbove(int i, int y)
        {
            var max = 0;
            while (i >= 0)
            {
                var tree = map[i, y];
                if (tree.Height > max)
                {
                    max = tree.Height;
                }
                i -= 1;
            }
            return max;
        }

        private int GetMaxBelow(int i, int y)
        {
            var max = 0;
            while (i < map.GetLength(0))
            {
                var tree = map[i, y];
                if (tree.Height > max)
                {
                    max = tree.Height;
                }
                i += 1;
            }
            return max;
        }

        private int GetMaxLeft(int i, int y)
        {
            var max = 0;
            while (y >= 0)
            {
                var tree = map[i, y];
                if (tree.Height > max)
                {
                    max = tree.Height;
                }
                y -= 1;
            }
            return max;
        }

        private int GetMaxRight(int i, int y)
        {
            var max = 0;
            while (y < map.GetLength(1))
            {
                var tree = map[i, y];
                if (tree.Height > max)
                {
                    max = tree.Height;
                }
                y += 1;
            }
            return max;
        }

        private void OutputData()
        {
            var count = 0;
            var builder = new OutputBuilder();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    var tree = map[x, y];
                    tree.Visable = CheckData(x, y);
                    if (tree.Visable)
                    {
                        count += 1;
                    }
                    builder.Append($"{tree.Height} ({tree.Visable.ToString().Substring(0, 1)}), ");
                }
                builder.AppendNewLine();
            }

            builder.AppendNewLine();
            builder.Append($"Total: {count}");
            System.IO.File.WriteAllText("Day8\\Output.txt", builder.ToString());
        }
    }
}