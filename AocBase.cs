
using System.Diagnostics;
using System.Text.Json;

public class AocBase
{
    private JsonSerializerOptions opt = new JsonSerializerOptions { WriteIndented = true };

    protected void Dump2Debug(object o)
    {
        Debug.Write(JsonSerializer.Serialize(o, opt));
    }

    protected void Dump2File(object o)
    {
        File.WriteAllText("../../../dump.json", JsonSerializer.Serialize(o, opt));
    }
}