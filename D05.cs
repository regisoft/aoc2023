namespace aoc2023;

[TestClass]
public class D05
{
    [TestMethod]
    public void P1()
    {
        long[] seeds = [79, 14, 55, 13];

        var rslt = Calc1(seeds, $"input/_{nameof(D05)}_1_sample.txt");
        Assert.AreEqual(35, rslt);

        seeds = [629551616, 310303897, 265998072, 58091853, 3217788227, 563748665, 2286940694, 820803307, 1966060902, 108698829, 190045874, 3206262, 4045963015, 223661537, 1544688274, 293696584, 1038807941, 31756878, 1224711373, 133647424];
        rslt = Calc1(seeds, $"input/_{nameof(D05)}.txt");
        Assert.AreEqual(403695602, rslt);
    }

    public static long Calc1(long[] src, string inputName)
    {
        var map = File.ReadLines(inputName).Select(i =>
        {
            var x = i.Split(' ');
            return new Mapping
            {
                MapType = x[0],
                Dst = Convert.ToInt64(x[1]),
                Src = Convert.ToInt64(x[2]),
                Range = Convert.ToInt64(x[3]),
            };
        }).ToList();

        src = MapIt(src, map, "seed-to-soil");
        src = MapIt(src, map, "soil-to-fertilizer");
        src = MapIt(src, map, "fertilizer-to-water");
        src = MapIt(src, map, "water-to-light");
        src = MapIt(src, map, "light-to-temperature");
        src = MapIt(src, map, "temperature-to-humidity");
        src = MapIt(src, map, "humidity-to-location");

        return src.Min();

        static long[] MapIt(long[] src, List<Mapping> map, string mapType)
        {
            return
            (from s in src
             from m in (from s1 in map where s1.MapType == mapType && s >= s1.Src && s <= s1.Src + s1.Range select s1).DefaultIfEmpty()
             select m == null ? s : m.Dst + (s - m.Src)
            ).ToArray();
        }
    }

    [TestMethod]
    public void P2()
    {
        /*
                var rslt = Calc2($"input/_{nameof(D05)}_1_sample.txt");
                Assert.AreEqual(30, rslt);

                rslt = Calc2($"input/_{nameof(D05)}.txt");
                Assert.AreEqual(5704953, rslt);
                */
    }
}


class Mapping
{
    public string MapType = string.Empty;
    public long Dst;
    public long Src;
    public long Range;
}
