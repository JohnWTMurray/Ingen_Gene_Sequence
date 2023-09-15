namespace JurassicSystems;


public static class GeneSequence
{
    private static Config _cfg;
    private static string Nucleotides = "ACGT";


    private static char GetRandomNucleotide()
    {
        return Nucleotides[Random.Shared.Next(0, 3)];
    }


    private static void Column()
    {
        for (int i = 0; i < _cfg.ColumnLength; i++)
        {
            // In almost any other context. This would be bad.
            Thread.Sleep(_cfg.Delay);
            Console.Write(GetRandomNucleotide());
        }
    }
    private static void Line()
    {
        for (int i = 0; i < _cfg.ColumnCount - 1; i++)
        {
            Column();
            Console.Write(_cfg.Gap);
        }
        Column();
        Console.WriteLine();
    }

    private static void LoadTerminalTheme()
    {
        // update terminal foreground and background colors
        // to be implemented later
    }

    public static void Init(Config config)
    {
        _cfg = config;
        LoadTerminalTheme();

        // prints lines indefinitly if 'Lines == 0'
        for (int i = 1; i < _cfg.Lines || _cfg.Lines == 0; i++)
        {
            Line();
        }

    }
}