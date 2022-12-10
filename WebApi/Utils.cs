namespace WebApi;

public static class Utils
{
    public static readonly Func<string, bool> IsUnique = value => value != "None";
}