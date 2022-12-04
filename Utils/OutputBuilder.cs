
using System.Text;

public class OutputBuilder
{
    private StringBuilder builder = new();

    public OutputBuilder Append(string line)
    {
        builder.Append(line);
        return this;
    }

    public OutputBuilder AppendLine(string line)
    {
        builder.AppendLine(line);
        return this;
    }

    public OutputBuilder AppendNewLine()
    {
        builder.Append(Environment.NewLine);
        return this;
    }

    public OutputBuilder AppendLines(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            builder.AppendLine(line);
        }
        builder.Append(Environment.NewLine);
        return this;
    }

    public override string ToString()
    {
        return builder.ToString();
    }
}