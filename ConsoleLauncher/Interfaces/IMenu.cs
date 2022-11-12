namespace ConsoleLauncher.Interfaces
{
    /// <summary>
    /// Represents printable Console menu.
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// Gets list of added items.
        /// </summary>
        internal List<MenuItem> Items { get; }

        /// <summary>
        /// Adds an item to current Menu.
        /// </summary>
        /// <param name="menuItem">Item to add.</param>
        /// <returns>Current menu.</returns>
        public IMenu AddItem(MenuItem menuItem);

        /// <summary>
        /// Allows to set options of displayed menu.
        /// </summary>
        /// <returns>Current menu.</returns>
        public IMenu Setup();

        /// <summary>
        /// Prints current menu on console.
        /// </summary>
        public void Print();
    }
}