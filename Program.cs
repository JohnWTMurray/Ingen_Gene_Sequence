using System.Runtime.CompilerServices;

namespace JurassicSystems;


class Program
{

    private static void DebugLog(Config cfg)
    {
        Console.WriteLine($"column length: {cfg.ColumnLength}");
        Console.WriteLine($"column per line: {cfg.ColumnCount}");
        Console.WriteLine($"GapLength: {cfg.GapLength}");
        Console.WriteLine($"Lines: {cfg.Lines}");
        Console.WriteLine($"Delay: {cfg.Delay}");
    }


    public static void Main(string[] args)
    {

        GeneSequence.Init(new ArgumentHandler(args).GetConfig());

        // Console.WriteLine(String.Join(", ", args));
        // DebugLog(
        //     new ArgumentHandler(args).GetConfig()
        // );

    }
}



