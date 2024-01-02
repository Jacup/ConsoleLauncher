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

        private Layout(ILayoutComponent footer, ILayoutComponent header)
        {
            Footer = footer;
            Header = header;
        }

        /// <summary>
        /// Gets or sets footer.
        /// </summary>
        public ILayoutComponent Footer { get; set; }

        /// <summary>
        /// Gets or sets header.
        /// </summary>
        public ILayoutComponent Header { get; set; }

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
