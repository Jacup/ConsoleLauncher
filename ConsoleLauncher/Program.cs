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
                GenerateView(Menus, pointer);

                var x = GetAction();
                pointer += x;

            }


        }

        /// <summary>
        /// Method that generates view.
        /// </summary>
        /// <param name="options">List of values to print in options.</param>
        /// <param name="pointer">Highlighted option.</param>
        public static void GenerateView(List<string> options, int pointer)
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

        private static int GetAction()
        {
            var action = Console.ReadKey();

            return action.Key switch
            {
                ConsoleKey.DownArrow => 1,
                ConsoleKey.UpArrow => -1,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
