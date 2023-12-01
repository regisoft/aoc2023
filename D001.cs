using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace aoc2023;

[TestClass]
public class D001
{
    [TestMethod]
    public void P1()
    {
        var rslt = Calc1($"_{nameof(D001)}_1_sample.txt");
        Assert.AreEqual(142, rslt);

        rslt = Calc1($"_{nameof(D001)}.txt");
        Assert.AreEqual(55447, rslt);
    }

    public static int Calc1(string inputName)
    {
        var input = File.ReadLines(inputName);
        return input.Select(s => new string(s.Where(char.IsDigit).ToArray()))
        .Select(s2 =>
        {   //s2 = s2.Length == 0 ? "0" : s2;  
            return Convert.ToInt32(string.Concat(s2.AsSpan(0, 1), s2.AsSpan(s2.Length - 1)));
        }).Sum();
    }

    [TestMethod]
    public void P2()
    {
        var rslt1 = Calc2($"_{nameof(D001)}_2_sample.txt");
        Assert.AreEqual(281, rslt1);
        return;


        var rslt = Calc2($"_{nameof(D001)}.txt");
        //Assert.AreEqual(54764, rslt);
        // 54764 ...too high
        // 54650 ...too low

        // einander überlappend muss gehen oder einfach erster
        // tw o ne
        // eigh t two2
        // eigh t hree 
        // seve n ine
        // nin e ight
        // fiv e ight
        // thre e ight
        // on e ight
    }   


    public static int Calc2(string inputName)
    {
        var wordsToNumbers = new Dictionary<string, int>() {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
            };

       //\bzero\b|
        string pattern = @"(\d+|\bone\b|\btwo\b|\bthree\b|\bfour\b|\bfive\b|\bsix\b|\bseven\b|\beight\b|\bnine\b)";

        var input = File.ReadLines(inputName);

        var x1 = input.Select(s =>
        {


            MatchCollection matches = Regex.Matches(s, pattern);
            List<int> numbers = [];

foreach (Match match in matches)
{
    string value = match.Value;

    if (int.TryParse(value, out int number))
    {
        numbers.Add(number);
    }
    else if (wordsToNumbers.TryGetValue(value, out number))
    {
        numbers.Add(number);
    }
}

string firstNumber = numbers.First().ToString();
string lastNumber = numbers.Last().ToString();

string result = firstNumber + lastNumber;
return result == null ? 0 : int.Parse(result);
        }).Sum();

        Debug.WriteLine("===> " + x1);

        return x1;
    }


/*
public static int Calc2(string inputName)
    {
        var wordsToNumbers = new Dictionary<string, int>() {
            {"one",1,
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
            }
       

       //{"tw o ne", "21"}
//{"eigh t two", "82"}
//{"eigh t hree ", "83"}
//{"seve n ine", "79"}
//{"nin e ight", "98"}
//{"fiv e ight", "58"}
//{"thre e ight", "38"}
//{"on e ight", "18"}
//{"eigh t hre e eight ", "838"}  würde nicht gehen

       //\bzero\b|
        string pattern = @"(\d+|\bone\b|\btwo\b|\bthree\b|\bfour\b|\bfive\b|\bsix\b|\bseven\b|\beight\b|\bnine\b)";

        // eigh t hre e ight ...   
        // eigh 3t hre e ight ...   





        var input = File.ReadLines(inputName);

        var x1 = input.Select(s =>
        {
            foreach (var pair in wordsToNumbers)
            {
                s = s.Replace(pair.Key, pair.Key + pair.Value + '*' );
            }
            return s;
        });

       // x1.ToList();
       //Debug.Write(JsonSerializer.Serialize(x1));
        File.WriteAllLines("c:/tmp/dump.txt", x1);


        var x2 = x1.Select(s => new string(s.Where(char.IsDigit).ToArray()))
        .Select(s2 =>
        {   //s2 = s2.Length == 0 ? "0" : s2;  
            return Convert.ToInt32(string.Concat(s2.AsSpan(0, 1), s2.AsSpan(s2.Length - 1)));
        }).Sum();

        Debug.WriteLine("===> " + x2);

        return x2;
    }
    */
}