using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace aoc2023;

[TestClass]
public class D08 : AocBase
{
    [TestMethod]
    public void P1()
    {
        var rslt = Calc1($"input/_{nameof(D08)}_1_sample.txt", "LLR");
        Assert.AreEqual(6, rslt);

        rslt = Calc1($"input/_{nameof(D08)}.txt", "LRLRLRRLRRRLRRRLRRRLRLRRRLRRRLRRRLLRLRRRLRLRRRLLRRRLRRLRRRLRRLRLRRRLRRRLRLRRLRRRLRRLRRRLRRLRLRRLRRRLRLRRLRRRLLRRRLRLRRLLLRLLRLRRLLRRRLLRLLRRLRLRRRLLLRLRRLRLRRLRRRLRRLLRRLLRLRRRLRRRLRLLLLRLLRLRLRLRRRLRRLRRLRLRRRLLRRLRLLRRLRLRRLRLRLRRLRRLLRLRRLLRLLRRRLLLRRRLRRLRLRRRLRRLRRRLRRLLLRRRR");
        Assert.AreEqual(14893, rslt);
    }


    [TestMethod]
    public void P2()
    {
        var rslt = Calc2($"input/_{nameof(D08)}_2_sample.txt", "LR");
        Assert.AreEqual(6, rslt);

        // if think it works, but is too slow and have int32 overflow => use D08_encse.cs
        // rslt = Calc2($"input/_{nameof(D08)}.txt", "LRLRLRRLRRRLRRRLRRRLRLRRRLRRRLRRRLLRLRRRLRLRRRLLRRRLRRLRRRLRRLRLRRRLRRRLRLRRLRRRLRRLRRRLRRLRLRRLRRRLRLRRLRRRLLRRRLRLRRLLLRLLRLRRLLRRRLLRLLRRLRLRRRLLLRLRRLRLRRLRRRLRRLLRRLLRLRRRLRRRLRLLLLRLLRLRLRLRRRLRRLRRLRLRRRLLRRLRLLRRLRLRRLRLRLRRLRRLLRLRRLLRLLRRRLLLRRRLRRLRLRRRLRRLRRRLRRLLLRRRR");
        // Assert.AreEqual(-1, rslt);
    }

    public static double Calc1(string inputName, string moves)
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

    public static double Calc2(string inputName, string moves)
    {
        var q1 =
        (from f in File.ReadLines(inputName)
         select new KeyValuePair<string, string>(f[..3], f.Substring(7, 8))
        ).ToDictionary();

        var positions = q1.Where(x => x.Key.EndsWith('A')).Select(x => x.Key).ToArray();

        var idx = 0;
        var cnt = 0;
        while (positions.Any(x => !x.EndsWith('Z')))
        {
            cnt++;
            Debug.WriteLineIf(cnt % 10000 == 0, cnt);

            if (idx >= moves.Length) idx = 0;
            var direction = moves[idx];

            for (int i = 0; i < positions.Length; i++)
            {
                var val = q1[positions[i]];
                if (direction == 'L')
                {
                    positions[i] = val[..3];
                }
                else
                {
                    positions[i] = val.Substring(5, 3);
                }
            }
            idx++;
        }

        return cnt;
    }
}

