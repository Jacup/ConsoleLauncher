namespace ConsoleLauncher
{
    /// <summary>
    /// Main class for this app.
    /// </summary>
    public static class Program
    {
        private static readonly List<string> Menus = new()
        {
            "Menu1",
            "Menu2",
            "Exit",
        };

        /// <summary>
        /// Main method.
        /// </summary>
        public static void Main()
        {
            var pointer = 0;
 
            for (int i = 0; i < 100; i++)
            {
                GenerateScreen(Menus, pointer);
                
                var x = WaitForAction();
                pointer += x;

            }


        }

        /// <summary>
        /// Method that generates view.
        /// </summary>
        /// <param name="options">List of values to print in options.</param>
        /// <param name="pointer">Highlighted option.</param>
        public static void GenerateScreen(List<string> options, int pointer)
        {
            Console.Clear();

            for (int i = 0; i < options.Count; i++)
            {
                if (pointer == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine($" > " + options[i]);

                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine($"   " + options[i]);
            }
        }

        private static int WaitForAction()
        {
            var action = Console.ReadKey();

            if (action.Key == ConsoleKey.DownArrow)
            {
                return 1;
            }
            else if (action.Key == ConsoleKey.UpArrow)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
