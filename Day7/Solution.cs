namespace Day7
{
    public class Solution : ISolution
    {
        private Dir system = new() { Name = "/" };
        private OutputBuilder builder = new();
        private int total = 0;

        private class Dir
        {
            public string Name { get; set; } = string.Empty;
            public Dir Parent { get; set; } = null;
            public List<Dir> Directories { get; set; } = new();
            public List<File> Files { get; set; } = new();
            public int Size { get; set; }
        }

        private class File
        {
            public string Name { get; set; } = string.Empty;
            public int Size { get; set; }
        }

        public void Run()
        {
            ReadData();
            OutputData();
        }

        private void ReadData()
        {
            var data = System.IO.File.ReadAllText("Day7\\Input.txt").Split(Environment.NewLine);
            var current = system;

            foreach (var line in data)
            {
                if (line.StartsWith("$ ls"))
                {
                    // Noting to do
                }
                else if (line.StartsWith("$ cd"))
                {
                    var dirName = line.Substring(5);
                    if (dirName.Equals("/"))
                    {
                        current = system;
                    }
                    else if (dirName.Equals(".."))
                    {
                        current = current.Parent;
                    }
                    else
                    {
                        var newDir = current.Directories.FirstOrDefault(x => x.Name == dirName);
                        if (newDir != null)
                        {
                            current = newDir;
                        }
                    }
                }
                else if (line.StartsWith("dir"))
                {
                    var dir = new Dir()
                    {
                        Name = line.Substring(4),
                        Parent = current
                    };
                    current.Directories.Add(dir);
                }
                else // file
                {
                    var array = line.Split(" ");
                    var file = new File()
                    {
                        Name = array[1],
                        Size = int.Parse(array[0])
                    };
                    current.Files.Add(file);
                }
            }
        }

        private void OutputData()
        {
            OutputDir(system, 0);
            builder.AppendNewLine();
            builder.AppendLine($"Total: {total}");

            FindSmallest(system);
            builder.AppendLine($"Smallest: {smallest}");
            System.IO.File.WriteAllText("Day7\\Output.txt", builder.ToString());
        }

        private int smallest = 70000000;

        private void FindSmallest(Dir dir)
        {
            int remaining = 70000000 - system.Size + dir.Size;
            if (remaining > 30000000 && smallest > dir.Size)
            {
                smallest = dir.Size;
            }
            foreach (var folder in dir.Directories)
            {
                FindSmallest(folder);
            }
        }

        private void OutputDir(Dir dir, int level)
        {
            dir.Size = GetSize(dir);
            if (dir.Size < 100000)
            {
                total += dir.Size;
            }

            builder.AppendSpaces(level * 2);
            builder.AppendLine($"- {dir.Name} (dir) - {dir.Size}");

            foreach (var folder in dir.Directories)
            {
                OutputDir(folder, level + 1);
            }

            foreach (var file in dir.Files)
            {
                builder.AppendSpaces(level * 2 + 2);
                builder.AppendLine($"- {file.Name} (file) - {file.Size}");
            }
        }

        private int GetSize(Dir dir)
        {
            var size = 0;
            foreach (var folder in dir.Directories)
            {
                size += GetSize(folder);
            }
            foreach (var file in dir.Files)
            {
                size += file.Size;
            }
            return size;
        }
    }
}