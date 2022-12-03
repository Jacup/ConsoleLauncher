namespace ConsoleLauncher.GUI
{
    using System.Diagnostics;
    using ConsoleLauncher.Helpers;

    /// <summary>
    /// Title class.
    /// </summary>
    public static partial class Title
    {
        private static readonly string ProcessName = Process.GetCurrentProcess().ProcessName;

        static Title()
        {
            Text = ProcessName;
            TitlePosition = Position.Center;
        }

        /// <summary>
        /// Position.
        /// </summary>
        public enum Position
        {
            /// <summary>
            /// Align to left.
            /// </summary>
            Left,

            /// <summary>
            /// Align to center.
            /// </summary>
            Center,
        }

        /// <summary>
        /// Gets or sets customizable title. By default = project name.
        /// </summary>
        public static string Text { get; set; }

        /// <summary>
        /// Gets or sets customizable title. By default = center.
        /// </summary>
        public static Position TitlePosition { get; set; }

        /// <summary>
        /// Gets or sets colors of title.
        /// </summary>
        public static (ConsoleColor Background, ConsoleColor Foreground) Colors { get; set; } =
        (Console.BackgroundColor, Console.ForegroundColor);

        /// <summary>
        /// Writes title.
        /// </summary>
        internal static void WriteTitle()
        {
            SetPosition();
            ConsoleHelper.SetColors(Colors);

            Console.Write(Text);
            Console.ResetColor();
        }

        private static void SetPosition()
        {
            if (TitlePosition == Position.Center)
            {
                int position = (Console.WindowWidth - Text.Length) / 2;
                Console.SetCursorPosition(position, Console.CursorTop);
            }
            else if (TitlePosition == Position.Left)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            }
        }
    }
}
