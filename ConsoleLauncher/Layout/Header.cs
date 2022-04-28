namespace ConsoleLauncher.Layout
{
    /// <summary>
    /// Header used to print at top of the screen.
    /// </summary>
    public static class Header
    {
        public enum Position
        {
            Left,
            Center,
        }

        private static readonly string ProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

        static Header()
        {
            IsVisible = false;
            Title = ProcessName;
            ClockVisible = true;
            TimeFormat = "h:mm tt";
            TitlePosition = Position.Center;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the header is visible.
        /// </summary>
        public static bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets customizable title. By default = project name.
        /// </summary>
        public static string Title { get; set; }

        /// <summary>
        /// Gets or sets customizable title. By default = center.
        /// </summary>
        public static Position TitlePosition { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the clock is visible. Default = true.
        /// </summary>
        public static bool ClockVisible { get; set; }

        /// <summary>
        /// Gets or sets time display format. Default = "h:mm tt".
        /// </summary>
        public static string TimeFormat { get; set; }
        public static (ConsoleColor Background, ConsoleColor Foreground) TitleColors { get; set; } =
        (Console.BackgroundColor, Console.ForegroundColor);

        private static void SetTitlePosition()
        {
            if (TitlePosition == Position.Center)
            {
                int position = (Console.WindowWidth - Title.Length) / 2;
                Console.SetCursorPosition(position, Console.CursorTop);
            }
            else if (TitlePosition == Position.Left)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            }
        }

        private static void SetTitleColors()
        {
            if (TitleColors.Background != Settings.DefaultBackgroundColor)
            {
                Console.BackgroundColor = TitleColors.Background;
            }

            if (TitleColors.Foreground != Settings.DefaultForegroundColor)
            {
                Console.ForegroundColor = TitleColors.Foreground;
            }
        }

        internal static void WriteTitle()
        {
            SetTitlePosition();
            SetTitleColors();
            Console.Write(Title);
            Console.ResetColor();
        }
    }
}