namespace ConsoleLauncher.Setup
{
    /// <summary>
    /// Global ConsoleLauncher settings.
    /// </summary>
    public class Settings
    {
        private static readonly object _lock = new();
        private static Settings? instance;

        private Settings()
        {
            Colors = new();
        }

        /// <summary>
        /// Gets colors setup.
        /// </summary>
        public Colors Colors { get; private set; }

        /// <summary>
        /// Gets or sets the pointer character.
        /// </summary>
        public char PointerCharacter { get; set; } = '>';

        internal static Settings GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    instance ??= new Settings();
                }
            }

            return instance;
        }
    }
}
