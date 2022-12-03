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
        /// Gets current index.
        /// </summary>
        public short Index { get; }

        /// <summary>
        /// Gets a value indicating whether index is set.
        /// </summary>
        public bool IndexSetFlag { get; }

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
        public (ConsoleColor Background, ConsoleColor Foreground)? HighlitedItemColors { get; }

        /// <summary>
        /// Gets colors of highlited menu item.
        /// </summary>
        public (ConsoleColor Background, ConsoleColor Foreground)? ItemColors { get; }

        /// <summary>
        /// Gets colors of highlited menu item.
        /// </summary>
        public (ConsoleColor Background, ConsoleColor Foreground)? NonTraverserableItemColors { get; }

        /// <summary>
        /// Gets character used as pointer.
        /// </summary>
        public char? PointerCharacter { get; }

        /// <summary>
        /// Gets a value indicating whether menu is builded.
        /// </summary>
        public bool IsBuilded { get; }

        /// <summary>
        /// Adds an item to current Menu.
        /// </summary>
        /// <param name="menuItem">Item to add.</param>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu AddItem(MenuItem menuItem);

        /// <summary>
        /// Adds an item to current Menu.
        /// </summary>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu AddExitItem();

        /// <summary>
        /// Adds an item to current Menu that returns in menu.
        /// </summary>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu AddReturnItem();

        /// <summary>
        /// Allows to set options of displayed menu.
        /// </summary>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu Setup();

        /// <summary>
        /// Set colors for highlited menu item. Overrides global settings.
        /// </summary>
        /// <param name="backgroundColor">Color to be set as background color.</param>
        /// <param name="fontColor">Color to be sent as font color.</param>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu SetHighlitedColors(ConsoleColor backgroundColor, ConsoleColor fontColor);

        /// <summary>
        /// Set colors for menu items. Overrides global settings.
        /// </summary>
        /// <param name="backgroundColor">Color to be set as background color.</param>
        /// <param name="fontColor">Color to be sent as font color.</param>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu SetItemColors(ConsoleColor backgroundColor, ConsoleColor fontColor);

        /// <summary>
        /// Set colors for non traverserable menu items. Overrides global settings.
        /// </summary>
        /// <param name="backgroundColor">Color to be set as background color.</param>
        /// <param name="fontColor">Color to be sent as font color.</param>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu SetNonTraverserableItemColors(ConsoleColor backgroundColor, ConsoleColor fontColor);

        /// <summary>
        /// Set colors for highlited menu item. Overrides global settings.
        /// </summary>
        /// <param name="pointer">Character to be used as pointer.</param>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu SetPointerCharacter(char pointer);

        /// <summary>
        /// Builds current menu.
        /// </summary>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu Build();

        /// <summary>
        /// Prints current menu on console.
        /// </summary>
        public void Print();

        /// <summary>
        /// Sets pointer at <paramref name="index"/>. By default, pointer will be set to first traversable item.
        /// </summary>
        /// <param name="index">Index to be set pointer at.</param>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if item at <paramref name="index"/> is not traverserable.</exception>
        internal IMenu SetIndex(short index);
    }
}