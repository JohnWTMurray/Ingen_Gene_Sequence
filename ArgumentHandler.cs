namespace JurassicSystems;




/* 
    Takes argument array and generates a config instance according to the 
    users' specifications. Use 'GetConfig()' to 
*/
public class ArgumentHandler : Config
{
    private List<string> _args;
    List<Theme> _themes = new Theme[] {
        new Theme { Name ="RETRO", Foreground = ConsoleColor.Green, Background = ConsoleColor.Black },
        new Theme { Name ="ORIGINAL", Foreground = ConsoleColor.White, Background = ConsoleColor.DarkBlue },
        new Theme { Name ="NONE", Foreground = Console.ForegroundColor , Background = Console.BackgroundColor }
    }.ToList();

    private void ReduceArgsToLowerCase()
    {
        _args.ForEach(x => x = x.ToLower());
    }

    /*  This gets repeated for every argument that takes a number.
     *  Confirms if argument was input correctly. 
     *  This method is for numeric arguments only
    */
    private int ValidateArgument(int index, int min, int max)
    {
        int argNum;
        // Assure the user input a parameter after the flag
        if (index + 1 > _args.Count - 1)
            JurassicError.NoArgumentGiven();

        string arg = _args.ElementAt(index + 1);

        // Assure there is a parameter before the next flag
        if (arg.StartsWith('-'))
            JurassicError.NoArgumentGiven();

        if (!int.TryParse(arg, out argNum))
            JurassicError.MustBeNumber();

        if (argNum < min || argNum > max)
            JurassicError.NotWithinLimits();
        
        return argNum;
    }

    private void RemindThemTheMagicWord()
    {
        Thread.Sleep(1000);
        while (true)
        {
            Console.WriteLine("YOU DIDN'T SAY THE MAGIC WORD!");
            Thread.Sleep(250);
        }
    }

    private void SetGap() 
    {
        int index = _args.Contains("-g") ? _args.IndexOf("-g") : _args.IndexOf("--gap");
        int argNum = ValidateArgument(index, 1, 6);
        GapLength = argNum;
        Gap = new string(' ', GapLength);
    }

    private void SetColumnLength()
    {
        int index = _args.Contains("-cl") ? _args.IndexOf("-cl") : _args.IndexOf("--columnlength");
        ColumnLength = ValidateArgument(index, 4, 10);
    }

    private void SetColumnCount()
    {
        int index = _args.Contains("-cc") ? _args.IndexOf("-cc") : _args.IndexOf("--columncount");
        ColumnCount = ValidateArgument(index, 1, 10);
    }

    private void SetLines() {
        int index = _args.Contains("-l") ? _args.IndexOf("-l") : _args.IndexOf("--lines");
        Lines = ValidateArgument(index, 1, int.MaxValue);
    }
        

    /* Identifies flags and inputs parameters to config according to flag */
    private void HandleArguments()
    {
        PopulateDefault();

        if (_args.Contains("--gap") || _args.Contains("-g"))
            SetGap();

        if (_args.Contains("--columnlength") || _args.Contains("-cl"))
            SetColumnLength();

        if (_args.Contains("--columncount") || _args.Contains("-cc"))
            SetColumnCount();

        if (_args.Contains("--lines") || _args.Contains("-l"))
            SetLines();

        if (_args.Contains("--theme") || _args.Contains("-t"))
        {
            int index = _args.Contains("-t") ? _args.IndexOf("-t") : _args.IndexOf("--theme");

            if (index + 1 > _args.Count - 1)
                JurassicError.NoArgumentGiven();

            string arg = _args.ElementAt(index + 1).ToUpper();
            if (arg.StartsWith('-'))
                JurassicError.NoArgumentGiven();

            if (_themes.Any(x => x.Name == arg))
            {
                Theme = _themes.Find(x => x.Name == arg);
            }
            else {
                JurassicError.InvalidTheme(_themes);
            }
        }
        
        if (!_args.Contains("please"))
            RemindThemTheMagicWord();

    }

    /* Assigns default values to the config. Overwritten if user specifies in arguments */
    public void PopulateDefault()
    {
        ColumnLength = 6;
        ColumnCount = 6;
        GapLength = 4;
        Gap = new string(' ', GapLength);
        Lines = 0; // '0' translates to infinity 
        Delay = 50;
        Theme = _themes[0];
    }


    // Constructor
    public ArgumentHandler(string[] args)
    {
        _args = args.ToList();
        ReduceArgsToLowerCase();
        HandleArguments();
    }

    public Config GetConfig()
    {
        return new Config{
            ColumnLength = ColumnLength,
            ColumnCount = ColumnCount, 
            GapLength = ColumnCount, 
            Gap = Gap,
            Lines = Lines,
            Delay = Delay,
            Theme = Theme
        };
    }

}
