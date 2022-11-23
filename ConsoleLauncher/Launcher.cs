namespace ConsoleLauncher
{
    /// <summary>
    /// ConsoleLauncher tool. There you can find all functionalities that ConsoleLauncher can handle.
    /// </summary>
    public static class Launcher
    {
        /// <summary>
        /// Gets new printable menu with set of MenuItems.
        /// </summary>
        public static MenuFactory Menu => new();
    }
}
