namespace Day6
{
    public class Solution : ISolution
    {
        private const int DISTINCT = 14;

        public void Run()
        {
            var data = File.ReadAllText("Day6\\Input.txt");

            var result = 0;
            string mark = data.Substring(0, DISTINCT);

            for (int i = DISTINCT; i < data.Length; i++)
            {
                var letter = data[i];
                mark = mark.Substring(1) + letter;
                if (IsUnique(mark))
                {
                    result = i + 1;
                    break;
                }
            }

            File.WriteAllText("Day6\\Output.txt", $"Result : {result}");
        }

        private bool IsUnique(String str)
        {

            for (int i = 0; i < str.Length; i++)
                for (int j = i + 1; j < str.Length; j++)
                    if (str[i] == str[j])
                        return false;

            return true;
        }
    }
}