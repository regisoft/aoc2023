namespace aoc2023;

[TestClass]
public class D06
{
    [TestMethod]
    public void P1()
    {
        // sample data
        var winCnt = Calc(7, 9) * Calc(15, 40) * Calc(30, 200);
        Assert.AreEqual(288, winCnt);

        // real data
        winCnt = Calc(49, 263) * Calc(97, 1532) * Calc(94, 1378) * Calc(94, 1851);
        Assert.AreEqual(4403592, winCnt);
    }

    [TestMethod]
    public void P2()
    {
        // sample data
        var winCnt = Calc(71530, 940200);
        Assert.AreEqual(71503, winCnt);

        // sample data
        winCnt = Calc(49979494, 263153213781851);
        Assert.AreEqual(38017587, winCnt);
    }

    public static long Calc(long t_fix, long d_record)
    {
        var winCnt = 0;
        for (long h = 1; h < t_fix; h++)
        {
            long d = (t_fix - h) * h;
            if (d > d_record)
            {
                winCnt++;
            }
        }

        return winCnt;
    }
}