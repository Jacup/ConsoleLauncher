namespace ConsoleLauncher.GUI.Interfaces
{
    using ConsoleLauncher.GUI.MenuItems;

    /// <summary>
    /// Represents printable Console menu.
    /// </summary>
    public interface IMenu : IPrintable
    {
        /// <summary>
        /// Gets list of added items.
        /// </summary>
        public IReadOnlyCollection<IMenuItem> Items { get; }

        /// <summary>
        /// Gets current index.
        /// </summary>
        public short PointerIndex { get; }

        /// <summary>
        /// Gets a value indicating whether index is set.
        /// </summary>
        public bool CustomPointerIndexFlag { get; }

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
        public char PointerChar { get; }

        /// <summary>
        /// Gets a value indicating whether custom pointer character is set.
        /// </summary>
        public bool PointerCharFlag { get; }

        /// <summary>
        /// Gets a value indicating whether menu is builded.
        /// </summary>
        public bool IsBuilt { get; }

        /// <summary>
        /// Adds an item to current Menu.
        /// </summary>
        /// <param name="menuItem">Item to add.</param>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu AddItem(IMenuItem menuItem);

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
        public IMenu SetItemsColors(ConsoleColor backgroundColor, ConsoleColor fontColor);

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
        /// Sets pointer at <paramref name="index"/>. By default, pointer will be set to first traversable item.
        /// </summary>
        /// <param name="index">Index to be set pointer at.</param>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if item at <paramref name="index"/> is not traverserable.</exception>
        public IMenu SetPointerIndex(short index);

        /// <summary>
        /// Builds current menu.
        /// </summary>
        /// <returns>Current instance of <see cref="IMenu"/>.</returns>
        public IMenu Build();
    }
}