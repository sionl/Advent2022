namespace Day7
{
    public class Solution : ISolution
    {
        private Dir system = new() { Name = "/" };
        private OutputBuilder builder = new();

        private class Dir
        {
            public string Name { get; set; } = string.Empty;
            public List<Dir> Directories { get; set; } = new();
            public List<File> Files { get; set; } = new();
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
                        // To do
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
                    var dir = new Dir() { Name = line.Substring(4) };
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
            System.IO.File.WriteAllText("Day7\\Output.txt", builder.ToString());
        }

        private void OutputDir(Dir dir, int level)
        {
            builder.AppendSpaces(level * 2);
            builder.AppendLine($"- {dir.Name} (dir)");

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
    }
}