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
        var rslt = File.ReadLines(inputName).Select(i =>
        {
            var x = i.Split(':')[1].Replace("  "," ").Split(" | ");
            return new
            {
                wins = x[0].Trim().Split(" "),
                my = x[1].Trim().Split(" ")
            };
        })
        /*
        .Select(game =>
        {
            var cnt = game.my.Intersect(game.wins).Count();
            var score = cnt > 1 ? Math.Pow(2, cnt - 1) : cnt;

            return new
            {
                game.wins,
                game.my,
                cnt,
                score
            };
        }).ToList();
        */
        .Select(game =>
        {
            var cnt = game.my.Intersect(game.wins).Count();
            if (cnt > 1) return Math.Pow(2, cnt - 1);
            else return cnt;
        })
        .Sum();

        //var dump = JsonSerializer.Serialize(rslt);
        // create a file from dump
        //File.WriteAllText("c:/tmp/dump.json", dump);   


        //return 13;

        return rslt;
    }


    [TestMethod]
    public void P2()
    {
        /*
               var rslt = Calc2($"input/_{nameof(D04)}_1_sample.txt");
               Assert.AreEqual(467835, rslt);

               rslt = Calc2($"input/_{nameof(D04)}.txt");
               Assert.AreEqual(87287096, rslt);
               */
    }

}