namespace XirzoResult;

public record Error(string code, string description)
{
    public static Error None => new Error(string.Empty, string.Empty);

    public string Code => code;
    public string Description => description;
}