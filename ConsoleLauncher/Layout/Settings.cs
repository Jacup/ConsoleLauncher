namespace ConsoleLauncher.Layout
{
    /// <summary>
    /// Global ConsoleLauncher settings.
    /// </summary>
    public static class Settings
    {
        private static bool defaultsSet;

        /// <summary>
        /// Gets default background color.
        /// </summary>
        internal static ConsoleColor DefaultBackgroundColor { get; private set; } = Console.BackgroundColor;

        /// <summary>
        /// Gets default foreground(font) color.
        /// </summary>
        internal static ConsoleColor DefaultForegroundColor { get; private set; } = Console.ForegroundColor;

        /// <summary>
        /// Method to save default settings of console.
        /// </summary>
        internal static void GetDefaults()
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
