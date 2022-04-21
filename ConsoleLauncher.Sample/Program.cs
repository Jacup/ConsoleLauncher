namespace ConsoleLauncher.Sample
{
    public static class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        public static void Main()
        {
            bool exit = false;
            List<string> optionList = new()
            {
                "Submenu",
                "Option 1",
                "Exit",
            };

            while (!exit)
            {
                var value = Launch.Menu(optionList);

                switch (value)
                {
                    case 0:
                        Submenu(out exit);
                        break;
                    case 1:
                        Console.WriteLine($"Entering {optionList[0]}");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Closing app");
                        exit = true;
                        break;
                }
            }
        }

        private static void Submenu(out bool exit)
        {
            exit = false;
            List<string> optionList = new()
            {
                "Action 1",
                "Go back",
                "Exit",
            };

            var value = Launch.Menu(optionList);

            switch (value)
            {
                case 0:
                    Console.WriteLine("some action ...");
                    Console.ReadLine();
                    break;
                case 1:
                    Console.WriteLine("Returning to main menu.\n Enter key to continue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Closing app");
                    exit = true;
                    break;
            }
        }
    }
}