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
