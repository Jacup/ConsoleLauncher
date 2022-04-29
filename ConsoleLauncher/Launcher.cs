namespace ConsoleLauncher
{
    using ConsoleLauncher.Layout;

    /// <summary>
    /// ConsoleLauncher tool. There you can find all functionalities that ConsoleLauncher can handle.
    /// </summary>
    public class Launcher
    {
        /// <summary>
        /// Initializes user-friendly, console menu that
        /// allow user to use arrows to navigate thru menu options.
        /// </summary>
        /// <param name="options">List of options to show in menu.</param>
        public static void Menu(List<Option> options)
        {
            Settings.GetDefaults();
            ConsoleLauncher.Menu.Run(options);
        }
    }
}
