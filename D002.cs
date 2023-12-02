namespace aoc2023;

[TestClass]
public class D002
{


    [TestMethod]
    public void P1()
    {
        var rslt = Calc1($"_{nameof(D002)}_1_sample.txt");
        Assert.AreEqual(8, rslt);

       rslt = Calc1($"_{nameof(D002)}.txt");
       Assert.AreEqual(2283, rslt);
    }

    public static int Calc1(string inputName)
    {
        var gameId = 1;
        return File.ReadLines(inputName)
        .Select(s => 
        {   // gameID, isImpossible --red, green, blue 
            var rslt = new int[2];
            rslt[0]=gameId++;
            
            var rec = s.Split(":")[1];
            // rec = "3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"

            foreach(var set in rec.Trim().Split(";"))
            {
                // set = "3 blue, 4 red"
                foreach(var color in set.Trim().Split(","))
                {
                    // color = 3 blue
                    var one=color.Trim().Split(" ");
                    switch (one[1])
                    {   
                        case "red":     if (Convert.ToInt32(one[0])>12) rslt[1]++; break;
                        case "green":   if (Convert.ToInt32(one[0])>13) rslt[1]++; break;
                        case "blue":    if (Convert.ToInt32(one[0])>14) rslt[1]++; break;
                    };
                }
            }
            return rslt;
        })
        .Where(c => c[1] == 0)
        .Sum(c => c[0]);
    }

    [TestMethod]
    public void P2()
    {
        var rslt = Calc2($"_{nameof(D002)}_1_sample.txt");
        Assert.AreEqual(2286, rslt);

        rslt = Calc2($"_{nameof(D002)}.txt");
        Assert.AreEqual(78669, rslt);
    }

    public static int Calc2(string inputName)
    {
        var gameId = 1;
        return File.ReadLines(inputName)
        .Select(s => 
        {   // gameID, red, green, blue 
            var rslt = new int[4];
            rslt[0]=gameId++;
            
            var rec = s.Split(":")[1];
            // rec = "3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"

            foreach(var set in rec.Trim().Split(";"))
            {
                // set = "3 blue, 4 red"
                foreach(var color in set.Trim().Split(","))
                {
                    // color = 3 blue
                    var one=color.Trim().Split(" ");
                    var cubeCnt = Convert.ToInt32(one[0]); 
                    switch (one[1])
                    {   
                        case "red":     if (cubeCnt>rslt[1]) rslt[1]=cubeCnt; break;
                        case "green":   if (cubeCnt>rslt[2]) rslt[2]=cubeCnt; break;
                        case "blue":    if (cubeCnt>rslt[3]) rslt[3]=cubeCnt; break;
                    };
                }
            }
            return rslt[1]*rslt[2]*rslt[3];
        })
        .Sum();
    }
}