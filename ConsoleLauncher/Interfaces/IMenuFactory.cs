namespace ConsoleLauncher.Interfaces
{
    /// <summary>
    /// Represents printable Console menu.
    /// </summary>
    public interface IMenuFactory
    {
        /// <summary>
        /// Gets list of added items.
        /// </summary>
        internal List<MenuItem> Items { get; }

        /// <summary>
        /// Gets a value indicating whether exit item should be added.
        /// </summary>
        public bool ExitItemFlag { get; }

        /// <summary>
        /// Gets a value indicating whether return flag should be added.
        /// </summary>
        public bool ReturnItemFlag { get; }

        /// <summary>
        /// Gets a value indicating whether menu is builded.
        /// </summary>
        public bool IsBuilded { get; }

        /// <summary>
        /// Adds an item to current Menu.
        /// </summary>
        /// <param name="menuItem">Item to add.</param>
        /// <returns>Current menu.</returns>
        public IMenuFactory AddItem(MenuItem menuItem);

        /// <summary>
        /// Adds an item to current Menu.
        /// </summary>
        /// <returns>Current menu.</returns>
        public IMenuFactory AddExitItem();

        /// <summary>
        /// Adds an item to current Menu that returns in menu.
        /// </summary>
        /// <returns>Current menu.</returns>
        public IMenuFactory AddReturnItem();

        /// <summary>
        /// Allows to set options of displayed menu.
        /// </summary>
        /// <returns>Current menu.</returns>
        public IMenuFactory Setup();

        /// <summary>
        /// Builds current menu.
        /// </summary>
        /// <returns>Current menu.</returns>
        public IMenuFactory Build();

        /// <summary>
        /// Prints current menu on console.
        /// </summary>
        public void Print();
    }
}