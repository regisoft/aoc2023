using System.Text;

namespace aoc2023;

[TestClass]
public class D07 : AocBase
{
    [TestMethod]
    public void P1()
    {
        var rslt = Calc($"input/_{nameof(D07)}_sample.txt", false);
        Assert.AreEqual(6440, rslt);

        rslt = Calc($"input/_{nameof(D07)}.txt", false);
        Assert.AreEqual(250120186, rslt);
    }

    [TestMethod]
    public void P2()
    {
        var rslt = Calc($"input/_{nameof(D07)}_sample.txt", true);
        Assert.AreEqual(5905, rslt);

        rslt = Calc($"input/_{nameof(D07)}.txt", true);
        Assert.AreEqual(250665248, rslt);
    }

    public double Calc(string inputName, bool isPart2)
    {
        var q1 =
        (from f in File.ReadLines(inputName)
         let x = f.Split(' ')
         select new Rec()
         {
             CardsString = x[0],
             Cards = Encoding.ASCII.GetBytes(x[0].Replace('T', ':').Replace('J', isPart2 ? '1' : ';').Replace('Q', '<').Replace('K', '=').Replace('A', '>')),
             Bid = Convert.ToInt32(x[1])
         }
        ).OrderBy(o => isPart2 ? o.PointsP2 : o.PointsP1)
        .ThenBy(o => o.Cards[0])
        .ThenBy(o => o.Cards[1])
        .ThenBy(o => o.Cards[2])
        .ThenBy(o => o.Cards[3])
        .ThenBy(o => o.Cards[4]).ToArray();

        for (int i = 0; i < q1.Length; i++)
        {
            q1[i].Rank = i + 1;
        }

        return q1.Sum(r => r.Bid * r.Rank);
    }
}

public class Rec
{
    private Dictionary<byte, int>? wins;

    public string? CardsString { get; set; }

    public byte[]? Cards { get; set; }

    public int Rank { get; set; }

    public int Bid { get; set; }

    public Dictionary<byte, int> MoreThanOne
    {
        // 48=0, 49=1 ... 58=10=':' ... 62=14='>'  
        get
        {
            if (wins == null)
            {
                wins = [];
                for (byte a = 48; a <= 62; a++)
                {
                    var cnt = (from c in Cards where c == a select c).Count();
                    if (cnt > 1)
                    {
                        wins.Add((byte)(a - 48), cnt);
                    }
                }
            }
            return wins;
        }
    }

    public int PointsP1
    {
        get
        {
            var sortedDict = from entry in MoreThanOne orderby entry.Value descending select entry;
            return sortedDict.FirstOrDefault().Value switch
            {
                5 => 6,
                4 => 5,
                3 => sortedDict.Count() == 1 ? 3 : 4, // 4 == full house  
                2 => sortedDict.Count() == 1 ? 1 : 2, // 2 == two pair 
                _ => 0
            };
        }
    }

    public int JCount
    {
        get => Cards!.Count(c => c == 49); // 49 = J = '1' 
    }

    public int PointsP2
    {
        get
        {
            var sortedDict = from entry in MoreThanOne orderby entry.Value descending select entry;
            switch (sortedDict.FirstOrDefault().Value)
            {
                case 5: return 6; // 5 same
                case 4:
                    if (JCount == 4) return 6; // 5 same
                    return JCount == 1 ? 6 : 5; // 5 or 4 same
                case 3:
                    if (sortedDict.Count() == 1)
                    {
                        if (JCount == 0) return 3; // 3 same
                        if (JCount == 1) return 5; // 4 same
                        if (JCount == 2) return 6; // 5 same
                        if (JCount == 3) return 5; // 4 same
                    }
                    else
                    {
                        if (JCount == 0) return 4; // full house
                        if (JCount == 2) return 6; // 5 same
                        if (JCount == 3) return 6; // 5 same
                    }
                    return -3; // not possible
                case 2:
                    if (sortedDict.Count() == 1) // 1pair 
                    {
                        if (JCount == 0) return 1; // 1 pair
                        if (JCount == 1) return 3; // 3 same
                        if (JCount == 2) return 3; // 3 same JJx 
                    }
                    else // 2 == two pair 
                    {
                        if (JCount == 0) return 2; // 2 pair
                        if (JCount == 1) return 4; // full house
                        if (JCount == 2) return 5; // 4 same
                    }
                    return -2; // not possible
                default: return JCount;
            };
        }
    }
}
