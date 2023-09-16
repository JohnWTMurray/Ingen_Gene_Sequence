namespace JurassicSystems;

/* 
 * if you ended up here. You ran into an error and the program will terminate.
 * Any method written here MUST close the program. ie 'Environment.Exit(1);'
 * 
 * TODO: Better error messages. Take in parameters for more information.
*/
public static class JurassicError
{
    // This one would specify the flag that's missing a parameter
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

    // This one in particular should specify the limits
    public static void NotWithinLimits()
    {
        Console.Error.WriteLine("argument provided was not within limits");
        Environment.Exit(1);
    }

    public static void InvalidTheme(List<Theme> _themes)
    {
        Console.Error.WriteLine("Invalid Theme. Input one of the following values for a theme:");
        _themes.ForEach(x => {
            Console.Error.WriteLine($"{x.Name}");
        });
        Environment.Exit(1);
    }

}
