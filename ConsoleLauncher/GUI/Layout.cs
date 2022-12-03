using ConsoleLauncher.Setup;

namespace ConsoleLauncher.GUI
{
    /// <summary>
    /// Layout.
    /// </summary>
    public class Layout
    {
        private static readonly object _lock = new();

        private static Layout? _instance;

        internal Layout()
        {
        }

        /// <summary>
        /// Gets colors setup.
        /// </summary>
        public Colors Colors { get; private set; }

        internal static Layout GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new Layout();
                }
            }

            return _instance;
        }
    }
}
