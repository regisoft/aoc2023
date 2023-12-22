# aoc2023

# setup
dotnet new mstest

# dump helpers     
* Debug.Write(JsonSerializer.Serialize(x1));
* File.WriteAllLines("c:/tmp/dump.txt", x1);

# other learnings
* line.Split(" ").Select(long.Parse)
* ints.Chunk(2)
* var q=new Queue<Range>(); q.Enqueue(range);  while (q.Any()) { range = q.Dequeue(); }