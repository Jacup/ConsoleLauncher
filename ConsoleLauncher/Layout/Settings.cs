namespace ConsoleLauncher.Layout
{
    public static class Settings
    {
        internal static ConsoleColor DefaultBackgroundColor = Console.BackgroundColor;
        internal static ConsoleColor DefaultForegroundColor = Console.ForegroundColor;

        private static bool defaultsSet = false;

        public static void GetDefaults()
        {
            if (!defaultsSet)
            {
                DefaultBackgroundColor = Console.BackgroundColor;
                DefaultForegroundColor = Console.ForegroundColor;

                defaultsSet = true;
            }
        }

    }
}
