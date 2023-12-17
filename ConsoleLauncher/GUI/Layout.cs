namespace ConsoleLauncher.GUI
{
    using ConsoleLauncher.GUI.Interfaces;

    /// <summary>
    /// Layout.
    /// </summary>
    public class Layout
    {
        private static readonly object _lock = new();

        private static Layout? _instance;

        internal Layout(IFooter footer, IHeader header)
        {
            Footer = footer;
            Header = header;
        }

        /// <summary>
        /// Gets or sets footer.
        /// </summary>
        public IFooter Footer { get; set; }

        /// <summary>
        /// Gets or sets header.
        /// </summary>
        public IHeader Header { get; set; }

        internal static Layout GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new Layout(new Footer(), new Header());
                }
            }

            return _instance;
        }
    }
}
