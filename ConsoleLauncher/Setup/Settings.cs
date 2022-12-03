namespace ConsoleLauncher.Setup
{
    /// <summary>
    /// Global ConsoleLauncher settings.
    /// </summary>
    public class Settings
    {
        private static readonly object _lock = new();

        private static Settings? _instance;

        private Settings()
        {
            Colors = new();
        }

        /// <summary>
        /// Gets colors setup.
        /// </summary>
        public Colors Colors { get; private set; }

        internal static Settings GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new Settings();
                }
            }

            return _instance;
        }
    }
}
