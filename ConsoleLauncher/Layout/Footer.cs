namespace ConsoleLauncher.Layout
{
    /// <summary>
    ///  Footer used to print at bottom of the screen.
    /// </summary>
    public static class Footer
    {
        private const string Tooltip = "Use arrows to navigate, Enter to select, Exit to go back.";

        static Footer()
        {
            IsVisible = false;
            LeftText = string.Empty;
            RightText = Tooltip;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the footer is visible.
        /// </summary>
        public static bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets a string printed on the left side of window.
        /// </summary>
        public static string LeftText { get; set; }

        /// <summary>
        /// Gets or sets a string printed on the right side of window. Default = navigating helper.
        /// </summary>
        public static string RightText { get; set; }

        /// <summary>
        /// Gets or sets colors of footer.
        /// </summary>
        public static (ConsoleColor Background, ConsoleColor Foreground) Colors { get; set; } =
        (Console.BackgroundColor, Console.ForegroundColor);

        /// <summary>
        /// Prints both footers.
        /// </summary>
        internal static void PrintFooter()
        {
            if (IsVisible)
            {
                Settings.SetColors(Colors);

                if (LeftText.Length > 0)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.WindowTop + Console.WindowHeight - 1);
                    Console.Write(LeftText);
                }

                if (RightText.Length > 0)
                {
                    Console.SetCursorPosition(Console.WindowWidth - RightText.Length, Console.WindowTop + Console.WindowHeight - 1);
                    Console.Write(RightText);
                }

                Console.ResetColor();
            }
        }
    }
}
