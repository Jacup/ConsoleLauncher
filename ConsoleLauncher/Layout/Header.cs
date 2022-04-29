﻿namespace ConsoleLauncher.Layout
{
    /// <summary>
    /// Header used to be printed at top of the screen.
    /// </summary>
    public static partial class Header
    {
        static Header() => IsVisible = false;

        /// <summary>
        /// Gets or sets a value indicating whether the header is visible.
        /// </summary>
        /// <returns>true if the header is visible; otherwise, false.</returns>
        public static bool IsVisible { get; set; }

        /// <summary>
        /// Print whole header.
        /// </summary>
        internal static void PrintHeader()
        {
            if (IsVisible)
            {
                Title.WriteTitle();
                Clock.WriteClock();

                Console.WriteLine();
            }
        }
    }
}