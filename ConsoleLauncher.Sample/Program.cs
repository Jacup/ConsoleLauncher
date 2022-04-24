namespace ConsoleLauncher.Sample
{
    public static class Program
    {
        public static void Main()
        {
            List<Option> options = new()
            {
                new Option("Submenu", Submenu),
                new Option("Option 1 as action", Option1),
                new Option("Option 1 as method", () => Option1()),
                new Option("Empty option 2"),
                new Option("Exit", () => Environment.Exit(0)),
            };
            new Option("sad", )
            Launcher.Menu(options);
        }

        private static void Submenu()
        {
            List<Option>? options = new()
            {
                new Option("Option 1", Option1),
                new Option("Go back", Main),
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