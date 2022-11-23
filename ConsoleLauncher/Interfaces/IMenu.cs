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
        /// Gets pointer.
        /// </summary>
        public short Pointer { get; }

        /// <summary>
        /// Gets a value indicating whether custom pointer was set.
        /// </summary>
        public bool PointerSet { get; }

        /// <summary>
        /// Gets a value indicating whether exit item should be added.
        /// </summary>
        public bool ExitItemFlag { get; }

        /// <summary>
        /// Gets a value indicating whether return flag should be added.
        /// </summary>
        public bool ReturnItemFlag { get; }

        /// <summary>
        /// Gets colors of highlited menu item.
        /// </summary>
        public (ConsoleColor Background, ConsoleColor Foreground) HighlitedItemColors { get; }

        /// <summary>
        /// Gets a value indicating whether custom colors for highlited item are set.
        /// </summary>
        public bool CustomHighlitedItem { get; }

        /// <summary>
        /// Gets a value indicating whether menu is builded.
        /// </summary>
        public bool IsBuilded { get; }

        /// <summary>
        /// Adds an item to current Menu.
        /// </summary>
        /// <param name="menuItem">Item to add.</param>
        /// <returns>Current menu.</returns>
        public IMenu AddItem(MenuItem menuItem);

        /// <summary>
        /// Adds an item to current Menu.
        /// </summary>
        /// <returns>Current menu.</returns>
        public IMenu AddExitItem();

        /// <summary>
        /// Adds an item to current Menu that returns in menu.
        /// </summary>
        /// <returns>Current menu.</returns>
        public IMenu AddReturnItem();

        /// <summary>
        /// Allows to set options of displayed menu.
        /// </summary>
        /// <returns>Current menu.</returns>
        public IMenu Setup();

        /// <summary>
        /// Set colors for highlited menu item. Overrides global settings.
        /// </summary>
        /// <param name="backgroundColor">Color to be set as background color.</param>
        /// <param name="fontColor">Color to be sent as font color.</param>
        /// <returns>Current menu.</returns>
        public IMenu SetHighlitedColors(ConsoleColor backgroundColor, ConsoleColor fontColor);

        /// <summary>
        /// Builds current menu.
        /// </summary>
        /// <returns>Current menu.</returns>
        public IMenu Build();

        /// <summary>
        /// Prints current menu on console.
        /// </summary>
        public void Print();

        /// <summary>
        /// Sets pointer at <paramref name="index"/>.
        /// </summary>
        /// <param name="index">Index to be set pointer at.</param>
        /// <returns>Current menu.</returns>
        /// <exception cref="ArgumentException">Thrown if item at <paramref name="index"/> is not traverserable.</exception>
        internal IMenu SetPointer(short index);
    }
}