namespace ConsoleLauncher.Sample
{
    using ConsoleLauncher.Layout;

    public static class Program
    {
        public static void Main()
        {
            Setup();

            List<Option> options = new()
            {
                new Option("Submenu", Submenu),
                new Option("Enable/Disable layout", EnableDisableLayout),
                new Option("Make me colorful!", ChangeColors),
                new Option("Option 1 as action", Option1),
                new Option("Option 1 as method call", () => Option1()),
                new Option("Empty option 2"),
                new Option("Exit", () => Environment.Exit(0)),
            };

            Launcher.Menu(options);
        }

        private static void ChangeColors()
        {
            Header.Title.Colors = (ConsoleColor.Yellow, ConsoleColor.Blue);
            Header.Clock.Colors = (ConsoleColor.Yellow, ConsoleColor.Blue);
            Menu.HighlitedEntryColors = (ConsoleColor.Red, ConsoleColor.Yellow);
        }

        private static void EnableDisableLayout()
        {
            if (!Header.IsVisible || !Footer.IsVisible)
            {
                Header.IsVisible = true;
                Footer.IsVisible = true;
            }
            else
            {
                Header.IsVisible = false;
                Footer.IsVisible = false;
            }
        }

        private static void Setup()
        {
        }

        private static void Submenu()
        {
            List<Option> options = new()
            {
                new Option("Option 1", Option1),
                new Option("Exit", () => Environment.Exit(0)),
            };

            Launcher.Menu(options);
        }

        private static void Option1()
        {
            Console.Clear();
            Console.WriteLine($"Entered Option 1");
            Console.ReadLine();
        }
    }
}