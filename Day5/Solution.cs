namespace Day5
{
    public class Solution : ISolution
    {
        private List<StackItem> stackItems = new();
        private List<Instruction> instructions = new();

        private class StackItem
        {
            public int Number { get; set; }
            public Stack<char> Crates { get; set; } = new Stack<char>();
            public string Output => $"{Number} - {string.Join(" ", Crates.Reverse())}";
        }

        private class Instruction
        {
            public int Move { get; set; }
            public int From { get; set; }
            public int To { get; set; }
            public string Output => $"move {Move} from {From} to {To}";
        }

        public void Run()
        {
            ReadData();
            RunInstructions();
            OutputData();
        }

        private void RunInstructions()
        {
            foreach (var instruction in instructions)
            {
                for (int i = 0; i < instruction.Move; i++)
                {
                    var crate = stackItems[instruction.From - 1].Crates.Pop();
                    stackItems[instruction.To - 1].Crates.Push(crate);
                }
            }
        }

        private void ReadData()
        {
            var data = File.ReadAllText("Day5\\Input1.txt");

            var stackNumbers = data.Substring(data.IndexOf("1"));
            stackNumbers = stackNumbers.Substring(0, stackNumbers.IndexOf(Environment.NewLine));
            var stackArray = stackNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var stackNumber in stackArray)
            {
                var stack = new StackItem();
                stack.Number = int.Parse(stackNumber);
                stackItems.Add(stack);
            }

            var stackList = data.Substring(0, data.IndexOf("1")).Split(Environment.NewLine).Reverse();
            foreach (var stackLine in stackList)
            {
                for (int i = 0; i < stackLine.Length; i++)
                {
                    if (stackLine[i] == '[')
                    {
                        var stackNumber = i / 4;
                        stackItems[stackNumber].Crates.Push(stackLine[i + 1]);
                    }
                }
            }

            var instructionList = data.Substring(data.IndexOf("m")).Split(Environment.NewLine);
            foreach (var instructionLine in instructionList)
            {
                var instructionArray = instructionLine.Split(" ");
                var instruction = new Instruction();
                instruction.Move = int.Parse(instructionArray[1]);
                instruction.From = int.Parse(instructionArray[3]);
                instruction.To = int.Parse(instructionArray[5]);
                instructions.Add(instruction);
            }
        }

        private void OutputData()
        {
            var builder = new OutputBuilder();
            builder.AppendLines(stackItems.Select(item => item.Output));
            var result = string.Join("", stackItems.Select(x => x.Crates.Peek()));
            builder.Append($"Result: {result}");
            File.WriteAllText("Day5\\Output.txt", builder.ToString());
        }
    }
}