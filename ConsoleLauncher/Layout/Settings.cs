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

        /// <summary>
        /// Method that set current ConsoleColors to provided in parameters.
        /// </summary>
        /// <param name="colors">ConsoleColors to set as tuple (background, foreground).</param>
        internal static void SetColors((ConsoleColor Background, ConsoleColor Foreground) colors)
        {
            if (colors.Background != Settings.DefaultBackgroundColor)
            {
                Console.BackgroundColor = colors.Background;
            }

            if (colors.Foreground != Settings.DefaultForegroundColor)
            {
                Console.ForegroundColor = colors.Foreground;
            }
        }
    }
}
