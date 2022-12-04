public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 0)
        {
            Console.WriteLine("Please provide day as input argument");
            return;
        }

        var day = args[0];
        if (!int.TryParse(day, out int dayInt))
        {
            Console.WriteLine("Not a valday day input");
            return;
        }

        var name = $"Day{day}.Solution";
        var solutionType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => typeof(ISolution).IsAssignableFrom(p))
            .FirstOrDefault(x => x.FullName == name);

        if (solutionType == null)
        {
            Console.WriteLine("No solution found");
            return;
        }

        var solution = Activator.CreateInstance(solutionType) as ISolution;
        if (solution == null)
        {
            Console.WriteLine("No solution cound be created");
            return;
        }

        Console.WriteLine($"Solving Day {day}");
        solution.Run();
    }
}