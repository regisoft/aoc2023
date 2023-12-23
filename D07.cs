using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace aoc2023;

[TestClass]
public class D07
{
    [TestMethod]
    public void P1()
    {
        var rslt = Calc1($"input/_{nameof(D07)}_1_sample.txt");
        Assert.AreEqual(6440, rslt);

        rslt = Calc1($"input/_{nameof(D07)}.txt");
        Assert.AreEqual(250120186, rslt);
    }

    public static double Calc1(string inputName)
    {
        var q1 =
        (from f in File.ReadLines(inputName)
         let x = f.Split(' ')
         select new Rec()
         {
             CardsString = x[0],
             Cards = Encoding.ASCII.GetBytes(x[0].Replace('T', ':').Replace('J', ';').Replace('Q', '<').Replace('K', '=').Replace('A', '>')),
             Bid = Convert.ToInt32(x[1])
         }
        ).OrderBy(o => o.Points)
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

    public int Points
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

    public Dictionary<byte, int> MoreThanOne
    {
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
}
