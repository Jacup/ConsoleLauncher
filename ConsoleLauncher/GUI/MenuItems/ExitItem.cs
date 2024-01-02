namespace ConsoleLauncher.GUI.MenuItems
{
    /// <summary>
    /// Exit item.
    /// </summary>
    public class ExitItem : MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitItem"/> class.
        /// </summary>
        /// <param name="name">Name to print as menu entry.</param>
        public ExitItem(string name)
            : base(name, () => Environment.Exit(0))
        {
        }
    }
}
