using System.Text;
using System.Text.Json.Nodes;

JsonNode.Parse(args[0])
    .AsObject()
    .Select(x => $"{MapName(x.Key)}: #{FormatColor(x.Value.AsObject())};")
    .Join(Environment.NewLine)
    .Print();

static string MapName(string value)
{
    StringBuilder builder = new();
    builder.Append('-');
    foreach (char c in value)
    {
        if (char.IsUpper(c))
        {
            builder.Append('-');
            builder.Append(char.ToLower(c));
        }
        else
        {
            builder.Append(c);
        }
    }
    return builder.ToString();
}

static string FormatColor(JsonObject obj)
{
    var r = obj["R"].GetValue<int>();
    var g = obj["G"].GetValue<int>();
    var b = obj["B"].GetValue<int>();
    var a = obj["A"].GetValue<int>();
    return $"{r:X2}{g:X2}{b:X2}{a:X2}";
}

static class Extensions
{
    public static string Join<T>(this IEnumerable<T> source, string separator)
        => string.Join(separator, source);

    public static void Print(this string value)
        => Console.WriteLine(value);
}
