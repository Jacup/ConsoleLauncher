namespace ConsoleLauncher
{
    using ConsoleLauncher.Layout;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// ConsoleLauncher tool. There you can find all functionalities that ConsoleLauncher can handle.
    /// </summary>
    public static class Launcher
    {
        //public static void Menu(IEnumerable<IMenuItem> options)
        //{
        //    Settings.GetDefaults();
        //    ConsoleLauncher.Menu.Run(options);
        //}

        /// <summary>
        /// Gets Menu Factory.
        /// </summary>
        public static MenuFactory Menu => new();
    }
}
