namespace ConsoleLauncher.Layout
{
    /// <summary>
    /// Header used to be printed at top of the screen.
    /// </summary>
    public static partial class Header
    {
        /// <summary>
        /// Clock displayed in the header.
        /// </summary>
        public static partial class Clock
        {
            static Clock()
            {
                IsVisible = true;
                TimeFormat = "h:mm tt";
            }

            /// <summary>
            /// Gets or sets a value indicating whether the clock is visible. Default = true.
            /// </summary>
            /// <returns>true if the clock is visible; otherwise, false.</returns>
            public static bool IsVisible { get; set; }

            /// <summary>
            /// Gets or sets time display format. Default = "h:mm tt".
            /// </summary>
            public static string TimeFormat { get; set; }

            /// <summary>
            /// Gets or sets colors of clock.
            /// </summary>
            public static (ConsoleColor Background, ConsoleColor Foreground) Colors { get; set; } =
            (Console.BackgroundColor, Console.ForegroundColor);

            /// <summary>
            /// Prints clock.
            /// </summary>
            internal static void WriteClock()
            {
                if (IsVisible)
                {
                    var formattedTime = GetFormattedTime();
                    Console.SetCursorPosition(Console.WindowWidth - formattedTime.Length, Console.CursorTop);
                    SetColors();

                    Console.Write(formattedTime);
                    Console.ResetColor();
                }
            }

            private static void SetColors()
            {
                if (Colors.Background != Settings.DefaultBackgroundColor)
                {
                    Console.BackgroundColor = Colors.Background;
                }

                if (Colors.Foreground != Settings.DefaultForegroundColor)
                {
                    Console.ForegroundColor = Colors.Foreground;
                }
            }

            private static string GetFormattedTime()
            {
                return DateTime.Now.ToString(TimeFormat);
            }
        }
    }
}
