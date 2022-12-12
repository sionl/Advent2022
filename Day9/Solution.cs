namespace Day9
{
    public class Solution : ISolution
    {
        private int[,] map = new int[6, 6];
        private int hX = 0;
        private int hY = 0;
        private int tX = 0;
        private int tY = 0;

        public void Run()
        {
            ReadData();
            OutputData();
        }

        private void ReadData()
        {
            var data = System.IO.File.ReadAllText("Day9\\Input.txt").Split(Environment.NewLine);

            foreach (var line in data)
            {
                char direction = char.Parse(line.Substring(0, 1));
                var number = int.Parse(line.Substring(1));
                switch (direction)
                {
                    case 'U':
                        MoveUp(number);
                        break;
                    case 'D':
                        MoveDown(number);
                        break;
                    case 'R':
                        MoveRight(number);
                        break;
                    case 'L':
                        MoveLeft(number);
                        break;
                }
            }
        }

        private void MoveUp(int number)
        {
            Console.WriteLine("Up: " + number);
            for (int i = 0; i < number; i++)
            {
                var abs = Math.Abs(hY - tY);
                if (hX == tX && hY == tY)
                {
                }
                else if (hX == tX)
                {
                    tY += 1;
                }
                else if (abs > 0)
                {
                    tX = hX;
                    tY = hY;
                }
                hY += 1;
                map[tX, tY] = map[tX, tY] + 1;
            }
        }

        private void MoveDown(int number)
        {
            Console.WriteLine("Down: " + number);
            for (int i = 0; i < number; i++)
            {
                var abs = Math.Abs(hY - tY);
                if (hX == tX && hY == tY)
                {
                }
                else if (hX == tX)
                {
                    tY -= 1;
                }
                else if (abs > 0)
                {
                    tX = hX;
                    tY = hY;
                }
                hY -= 1;
                map[tX, tY] = map[tX, tY] + 1;
            }
        }

        private void MoveRight(int number)
        {
            Console.WriteLine("Right: " + number);
            for (int i = 0; i < number; i++)
            {
                var abs = Math.Abs(hX - tX);
                if (hX == tX && hY == tY)
                {
                }
                else if (hY == tY)
                {
                    tX += 1;
                }
                else if (abs > 0)
                {
                    tX = hX;
                    tY = hY;
                }
                hX += 1;
                map[tX, tY] = map[tX, tY] + 1;
            }
        }

        private void MoveLeft(int number)
        {
            Console.WriteLine("Left: " + number);
            for (int i = 0; i < number; i++)
            {
                var abs = Math.Abs(hX - tX);
                if (hX == tX && hY == tY)
                {
                }
                else if (hY == tY)
                {
                    tX -= 1;
                }
                else if (abs > 0)
                {
                    tX = hX;
                    tY = hY;
                }
                hX -= 1;
                map[tX, tY] = map[tX, tY] + 1;
            }
        }

        private void OutputData()
        {
            var builder = new OutputBuilder();
            for (int y = map.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    var value = map[x, y];
                    builder.Append($"{value}, ");
                }
                builder.AppendNewLine();
            }

            System.IO.File.WriteAllText("Day9\\Output.txt", builder.ToString());
        }
    }
}