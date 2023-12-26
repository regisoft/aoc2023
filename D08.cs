using System.Collections;
using System.Text;

namespace aoc2023;

[TestClass]
public class D08 : AocBase
{
    [TestMethod]
    public void P1()
    {
        var rslt = Calc($"input/_{nameof(D08)}_1_sample.txt", "LLR");
        Assert.AreEqual(6, rslt);

        rslt = Calc($"input/_{nameof(D08)}.txt", "LRLRLRRLRRRLRRRLRRRLRLRRRLRRRLRRRLLRLRRRLRLRRRLLRRRLRRLRRRLRRLRLRRRLRRRLRLRRLRRRLRRLRRRLRRLRLRRLRRRLRLRRLRRRLLRRRLRLRRLLLRLLRLRRLLRRRLLRLLRRLRLRRRLLLRLRRLRLRRLRRRLRRLLRRLLRLRRRLRRRLRLLLLRLLRLRLRLRRRLRRLRRLRLRRRLLRRLRLLRRLRLRRLRLRLRRLRRLLRLRRLLRLLRRRLLLRRRLRRLRLRRRLRRLRRRLRRLLLRRRR");
        Assert.AreEqual(14893, rslt);
    }


    [TestMethod]
    public void P2()
    {
        var rslt = Calc($"input/_{nameof(D08)}_2_sample.txt", "LR");
        Assert.AreEqual(6, rslt);
    }

    public double Calc(string inputName, string moves)
    {
        var q1 =
        (from f in File.ReadLines(inputName)
         select new KeyValuePair<string, string>(f.Substring(0, 3), f.Substring(7, 8))
        ).ToDictionary();

        var pos = "AAA";
        var idx = 0;
        var cnt = 0;
        while (pos != "ZZZ")
        {
            cnt++;
            if (idx >= moves.Length) idx = 0;
            var direction = moves[idx];
            var val = q1[pos];
            if (direction == 'L')
            {
                pos = val.Substring(0, 3);
            }
            else
            {
                pos = val.Substring(5, 3);
            }

            idx++;
        }

        return cnt;
    }
}

