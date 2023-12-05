using System.Text.Json;

namespace aoc2023;

[TestClass]
public class D04
{
    [TestMethod]
    public void P1()
    {
        var rslt = Calc1($"input/_{nameof(D04)}_1_sample.txt");
        Assert.AreEqual(13, rslt);

        rslt = Calc1($"input/_{nameof(D04)}.txt");
        Assert.AreEqual(19135, rslt);
    }

    public static double Calc1(string inputName)
    {
        return File.ReadLines(inputName).Select(i =>
        {
            var x = i.Split(':')[1].Replace("  ", " ").Split(" | ");
            return new
            {
                wins = x[0].Trim().Split(" "),
                my = x[1].Trim().Split(" ")
            };
        })
        .Select(game =>
        {
            var cnt = game.my.Intersect(game.wins).Count();
            return cnt > 1 ? Math.Pow(2, cnt - 1) : cnt;
        })
        .Sum();
    }


    [TestMethod]
    public void P2()
    {
        var rslt = Calc2($"input/_{nameof(D04)}_1_sample.txt");
        Assert.AreEqual(30, rslt);

        rslt = Calc2($"input/_{nameof(D04)}.txt");
        Assert.AreEqual(5704953, rslt);
    }

    public static double Calc2(string inputName)
    {
        var rslt = File.ReadLines(inputName).Select(i =>
        {
            var x = i.Split(':')[1].Replace("  ", " ").Split(" | ");
            return new
            {
                wins = x[0].Trim().Split(" "),
                my = x[1].Trim().Split(" ")
            };
        })
        .Select(game =>
        {
            var cnt = game.my.Intersect(game.wins).Count();

            return new Card
            {
                Score = cnt,
                Count = 1
            };
        })
        .ToArray();

        for (int cardIdx = 0; cardIdx < rslt.Length - 1; cardIdx++)
        {
            var copyNextCnt = rslt[cardIdx].Score;
            for (int i = 0; i < copyNextCnt; i++)
            {
                rslt[cardIdx + 1 + i].Count += rslt[cardIdx].Count;
            }
        }

        return rslt.Sum(c => c.Count);
    }
}

public class Card
{
    public int Score;
    public int Count;
}
