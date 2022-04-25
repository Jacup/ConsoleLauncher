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
                new Option("Option 1 as action", Option1),
                new Option("Option 1 as method call", () => Option1()),
                new Option("Empty option 2"),
                new Option("Exit", () => Environment.Exit(0)),
            };

            Launcher.Menu(options);
        }

        private static void Setup()
        {
            // setup header
            Header.IsVisible = true;
            Header.Title = "My own title";

            // setup footer
            Footer.IsVisible = true;
            Footer.Left = "My left footer!";
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