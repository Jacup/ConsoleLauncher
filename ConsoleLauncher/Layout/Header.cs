namespace ConsoleLauncher.Layout
{
    /// <summary>
    /// Header used to print at top of the screen.
    /// </summary>
    public static partial class Header
    {
        static Header()
        {
            IsVisible = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the header is visible.
        /// </summary>
        public static bool IsVisible { get; set; }

        /// <summary>
        /// Print whole header.
        /// </summary>
        internal static void PrintHeader()
        {
            Title.WriteTitle();
            Clock.WriteClock();

            Console.WriteLine();
        }
    }
}