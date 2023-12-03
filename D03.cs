namespace aoc2023;

[TestClass]
public class D03
{
    [TestMethod]
    public void P1()
    {
        var rslt = Calc1($"input/_{nameof(D03)}_1_sample.txt");
        Assert.AreEqual(4361, rslt);

        rslt = Calc1($"input/_{nameof(D03)}.txt");
        Assert.AreEqual(535351, rslt);
    }

    public static int Calc1(string inputName)
    {
        var input = File.ReadLines(inputName);
        var matrix = input.Select(l => l.ToCharArray()).ToArray();

        int sum = 0;

        for (int y = 0; y < matrix.Length; y++)
        {
            int start = -1;

            for (int x = 0; x < matrix[y].Length; x++)
            {
                var current = matrix[y][x];
                if (char.IsDigit(current))
                {
                    if (start == -1) start = x;
                }
                else
                {
                    if (start != -1)
                    {
                        var end = x - 1;
                        if (HasSymbolAround(y, start, end))
                        {
                            string substring = string.Empty;
                            for (int idx = start; idx <= end; idx++)
                            {
                                substring += matrix[y][idx];
                            }
                            sum += Convert.ToInt32(substring);
                        }
                        start = -1;
                    }
                }
            }
        }

        bool HasSymbolAround(int yStart, int xStart, int xEnd)
        {
            for (int y = yStart - 1; y <= yStart + 1; y++)
            {
                for (int x = xStart - 1; x <= xEnd + 1; x++)
                {
                    var current = matrix[y][x];
                    if (!char.IsDigit(current) && current != '.')
                    { return true; }
                }
            }
            return false;
        }

        return sum;

    }


    [TestMethod]
    public void P2()
    {
        var rslt = Calc2($"input/_{nameof(D03)}_1_sample.txt");
        Assert.AreEqual(467835, rslt);

        rslt = Calc2($"input/_{nameof(D03)}.txt");
        Assert.AreEqual(87287096, rslt);
    }

    public static int Calc2(string inputName)
    {
        var input = File.ReadLines(inputName);
        var matrix = input.Select(l => l.ToCharArray()).ToArray();

        //var dict = new Dictionary<string, int>();
        var dict = new List<KeyValuePair<string, int>>();

        for (int y = 0; y < matrix.Length; y++)
        {
            int start = -1;

            for (int x = 0; x < matrix[y].Length; x++)
            {
                var current = matrix[y][x];
                if (char.IsDigit(current))
                {
                    if (start == -1) start = x;
                }
                else
                {
                    if (start != -1)
                    {
                        var end = x - 1;
                        AddToListWhenAsterix(y, start, end);
                        start = -1;
                    }
                }
            }
        }

        var groups = dict.GroupBy(info => info.Key)
                 .Select(group => new
                 {
                     Metric = group.Key,
                     Count = group.Count()
                 })
                 .Where(x => x.Count == 2)
                 .Select(x => x.Metric);

        var x2 = groups.Select(g => dict.First(d => d.Key == g).Value  * dict.Last(d => d.Key == g).Value);      
        return x2.Sum();

        //return dict.Where(x => groups.Contains(x.Key)).Select(x => x.Value).Sum();

        void AddToListWhenAsterix(int yStart, int xStart, int xEnd)
        {
            string substring = string.Empty;
            for (int idx = xStart; idx <= xEnd; idx++)
            {
                substring += matrix[yStart][idx];
            }

            for (int y = yStart - 1; y <= yStart + 1; y++)
            {
                for (int x = xStart - 1; x <= xEnd + 1; x++)
                {
                    var current = matrix[y][x];
                    if (current == '*')
                    {
                        dict.Add(new KeyValuePair<string, int>(x + "_" + y, Convert.ToInt32(substring)));
                    }
                }
            }
        }
    }
}