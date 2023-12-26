# aoc2023

# setup

dotnet new mstest

# dump helpers

- Debug.Write(JsonSerializer.Serialize(x1, new JsonSerializerOptions { WriteIndented = true }));
- File.WriteAllText("c:/tmp/dump.json", JsonSerializer.Serialize(q1, new JsonSerializerOptions { WriteIndented = true }));

# other learnings

- line.Split(" ").Select(long.Parse)
- ints.Chunk(2)
- var q=new Queue<Range>(); q.Enqueue(range); while (q.Any()) { range = q.Dequeue(); }
- D07: when mapping something (Jass): ..789TJQ.. use index of in a pattern ... instead of Encoding.Bytes... https://github.com/encse/adventofcode/blob/master/2023/Day07/Solution.cs
- D07: Pack some bytes together in 1 long: long Pack(IEnumerable<int> numbers) => numbers.Aggregate(1L, (a, v) => (a \* 256) + v);
