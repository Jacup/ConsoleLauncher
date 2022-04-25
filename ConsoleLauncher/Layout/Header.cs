namespace ConsoleLauncher.Layout
{
    /// <summary>
    /// Header used to print at top of the screen.
    /// </summary>
    public static class Header
    {
        private static readonly string ProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

        static Header()
        {
            HeaderVisible = false;
            Title = ProcessName;
            ClockVisible = true;
            TimeFormat = "h:mm tt";
        }

        /// <summary>
        /// Gets or sets a value indicating whether the header is visible.
        /// </summary>
        public static bool HeaderVisible { get; set; }

        /// <summary>
        /// Gets or sets customizable title. By default = project name.
        /// </summary>
        public static string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the clock is visible. Default = true.
        /// </summary>
        public static bool ClockVisible { get; set; }

        /// <summary>
        /// Gets or sets time display format. Default = "h:mm tt".
        /// </summary>
        public static string TimeFormat { get; set; }
    }
}