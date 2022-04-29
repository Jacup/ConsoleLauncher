namespace ConsoleLauncher.Layout
{
    /// <summary>
    ///  Footer used to print at bottom of the screen.
    /// </summary>
    public static class Footer
    {
        private const string Tooltip = "Use arrows to navigate, Enter to select, Exit to go back";

        static Footer()
        {
            IsVisible = false;
            Left = string.Empty;
            Right = Tooltip;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the footer is visible.
        /// </summary>
        public static bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets a string printed on the left side of window.
        /// </summary>
        public static string Left { get; set; }

        /// <summary>
        /// Gets or sets a string printed on the right side of window. Default = navigating helper.
        /// </summary>
        public static string Right { get; set; }

        internal static void PrintFooter()
        {
            if (Left.Length > 0)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.WindowTop + Console.WindowHeight - 1);
                Console.Write(Left);
            }

            if (Right.Length > 0)
            {
                Console.SetCursorPosition(Console.WindowWidth - Right.Length, Console.WindowTop + Console.WindowHeight - 1);
                Console.Write(Right);
            }
        }

    }
}
