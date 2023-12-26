# aoc2023

# setup

dotnet new mstest

# dump helpers

- Debug.Write(JsonSerializer.Serialize(x1, new JsonSerializerOptions { WriteIndented = true }));
- File.WriteAllText("c:/tmp/dump.json", JsonSerializer.Serialize(q1, new JsonSerializerOptions { WriteIndented = true }));

# other learnings

- https://github.com/encse/adventofcode/blob/master/2023/Day07/Solution.cs#L39
- line.Split(" ").Select(long.Parse)
- ints.Chunk(2)
- var q=new Queue<Range>(); q.Enqueue(range); while (q.Any()) { range = q.Dequeue(); }
- D07: when mapping something (Jass): ..789TJQ.. use index of in a pattern ... instead of Encoding.Bytes... https://github.com/encse/adventofcode/blob/master/2023/Day07/Solution.cs
- D07: Pack some bytes together in 1 long: long Pack(IEnumerable<int> numbers) => numbers.Aggregate(1L, (a, v) => (a \* 256) + v);
- give the main logic a function for part1 and part2: D07: int Solve(string input, Func<string, (long, long)> getPoints)
- when input contains multiple differnet things: var blocks = input.Split("\n\n"); var dirs = blocks[0];
- input: "22A = (22B, XXX)" hole die 3 \* 3BC: Map ParseMap(string input) => input.Split("\n").Select(line => Regex.Matches(line, "[A-Z0-9]+")).ToDictionary(m => m[0].Value, m => (m[1].Value, m[2].Value)); ... im dict ist der Value ein Tupel
- https://github.com/encse/adventofcode/blob/master/2023/Day08/Solution.cs#L29C10-L30C13
  -- GCD The Greatest Common Divisor == HCF Highest Common Factor
  -- LCM Least Common Multiple
  - ENCSE ist wohl auf Linux: \n mit \r\n ersetzen
  - brauche immer LONG nie INT
