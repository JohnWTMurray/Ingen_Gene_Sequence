namespace JurassicSystems;

public static class JurassicError
{
    public static void NoArgumentGiven()
    {
        Console.Error.WriteLine("No argument given after flag");
        Environment.Exit(1);
    }

    public static void MustBeNumber()
    {
        Console.Error.WriteLine("Argument after flag must be a valid number");
        Environment.Exit(1);
    }
    public static void NotWithinLimits()
    {
        Console.Error.WriteLine("argument provided was not within limits");
        Environment.Exit(1);
    }

}