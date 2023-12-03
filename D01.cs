namespace aoc2023;

[TestClass]
public class D01
{
    [TestMethod]
    public void P1()
    {
        var rslt = Calc1($"_{nameof(D01)}_1_sample.txt");
        Assert.AreEqual(142, rslt);

        rslt = Calc1($"_{nameof(D01)}.txt");
        Assert.AreEqual(55447, rslt);
    }

    public static int Calc1(string inputName)
    {
        return File.ReadLines(inputName)
        .Select(s => new string(s.Where(char.IsDigit).ToArray()))
        .Select(s2 => Convert.ToInt32(string.Concat(s2.AsSpan(0, 1), s2.AsSpan(s2.Length - 1)))).Sum();
    }

    [TestMethod]
    public void P2()
    {
        var rslt = Calc2($"_{nameof(D01)}_2_sample.txt");
        Assert.AreEqual(281, rslt);

        rslt = Calc2($"_{nameof(D01)}.txt");
        Assert.AreEqual(54706, rslt);
    }

    public static int Calc2(string inputName)
    {
        var replacements = new Dictionary<string, string>() {
            {"one","o1ne"},
            {"two","t2wo"},
            {"three","th3ree"},
            {"four","f4our"},
            {"five","f5ive"},
            {"six","si6x"},
            {"seven","se7ven"},
            {"eight","ei8ght"},
            {"nine","ni9ne"}
            };

        return File.ReadLines(inputName)
        .Select(s =>
        {
            foreach (var pair in replacements)
            {
                s = s.Replace(pair.Key, pair.Value);
            }
            return s;
        })
        .Select(s => new string(s.Where(char.IsDigit).ToArray()))
        .Select(s2 => Convert.ToInt32(string.Concat(s2.AsSpan(0, 1), s2.AsSpan(s2.Length - 1)))).Sum();
    }
}