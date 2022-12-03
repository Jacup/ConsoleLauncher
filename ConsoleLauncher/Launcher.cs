namespace ConsoleLauncher
{
    using ConsoleLauncher.Layout;

    /// <summary>
    /// ConsoleLauncher tool. There you can find all functionalities that ConsoleLauncher can handle.
    /// </summary>
    public static class Launcher
    {
        /// <summary>
        /// Gets new printable menu with set of <see cref="MenuItem"/>.
        /// </summary>
        public static MenuFactory Menu => new();

        /// <summary>
        /// Gets instance of global customizable <see cref="Settings"/>.
        /// </summary>
        public static Settings Settings => Settings.GetSettings();
    }
}
