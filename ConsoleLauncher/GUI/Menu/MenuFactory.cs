namespace ConsoleLauncher.GUI
{
    using System;
    using System.Linq;
    using ConsoleLauncher;
    using ConsoleLauncher.GUI.Interfaces;
    using ConsoleLauncher.GUI.MenuItems;

    /// <summary>
    /// Printable menu with set of MenuItems.
    /// </summary>
    public class MenuFactory : IMenu
    {
        private readonly List<IMenuItem> _items;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuFactory"/> class.
        /// </summary>
        internal MenuFactory()
        {
            _items = new List<IMenuItem>();
        }

        /// <inheritdoc/>
        public bool ExitItemFlag { get; private set; }

        /// <inheritdoc/>
        public bool ReturnItemFlag { get; private set; }

        /// <inheritdoc/>
        public bool IsBuilt { get; private set; }

        /// <inheritdoc/>
        public IReadOnlyCollection<IMenuItem> Items => _items;

        /// <inheritdoc/>
        public (ConsoleColor Background, ConsoleColor Foreground)? HighlitedItemColors { get; private set; }

        /// <inheritdoc/>
        public (ConsoleColor Background, ConsoleColor Foreground)? ItemColors { get; private set; }

        /// <inheritdoc/>
        public (ConsoleColor Background, ConsoleColor Foreground)? NonTraverserableItemColors { get; private set; }

        /// <inheritdoc/>
        public bool CustomPointerIndexFlag { get; private set; }

        /// <inheritdoc/>
        public short PointerIndex { get; private set; }

        /// <inheritdoc/>
        public char PointerChar { get; private set; }

        /// <inheritdoc/>
        public bool PointerCharFlag { get; private set; }

        /// <inheritdoc/>
        public IMenu AddItem(IMenuItem menuItem)
        {
            _items.Add(menuItem);

            return this;
        }

        /// <inheritdoc/>
        public IMenu AddExitItem()
        {
            ExitItemFlag = true;

            return this;
        }

        /// <inheritdoc/>
        public IMenu AddReturnItem()
        {
            ReturnItemFlag = true;

            return this;
        }

        /// <inheritdoc/>
        public IMenu SetItemsColors(ConsoleColor backgroundColor, ConsoleColor fontColor)
        {
            ItemColors = (backgroundColor, fontColor);

            return this;
        }

        /// <inheritdoc/>
        public IMenu SetHighlitedColors(ConsoleColor backgroundColor, ConsoleColor fontColor)
        {
            HighlitedItemColors = (backgroundColor, fontColor);

            return this;
        }

        /// <inheritdoc/>
        public IMenu SetNonTraverserableItemColors(ConsoleColor backgroundColor, ConsoleColor fontColor)
        {
            NonTraverserableItemColors = (backgroundColor, fontColor);

            return this;
        }

        /// <inheritdoc/>
        public IMenu SetPointerCharacter(char pointer)
        {
            PointerChar = pointer;
            PointerCharFlag = true;

            return this;
        }

        /// <inheritdoc/>
        public IMenu SetPointerIndex(short index)
        {
            CustomPointerIndexFlag = true;
            PointerIndex = index;

            return this;
        }

        /// <inheritdoc/>
        public IMenu Build()
        {
            if (IsBuilt)
                return this;

            if (ReturnItemFlag && !_items.OfType<ReturnItem>().Any())
                _items.Add(new ReturnItem("Return"));
            if (ExitItemFlag && !_items.OfType<ExitItem>().Any())
                _items.Add(new ExitItem("Exit"));
            if (!PointerCharFlag)
                PointerChar = Launcher.Settings.PointerCharacter;

            ItemColors ??= Launcher.Settings.Colors.DefaultItemColors();
            HighlitedItemColors ??= Launcher.Settings.Colors.DefaultHighlitedColors();
            NonTraverserableItemColors ??= Launcher.Settings.Colors.DefaultNonTraverserableColors();

            if (CustomPointerIndexFlag)
            {
                if (_items.ElementAtOrDefault(PointerIndex) == null)
                    throw new ArgumentException($"Item at index {PointerIndex} does not exists.", nameof(PointerIndex));
                if (!_items.ElementAt(PointerIndex).IsTraverserable)
                    throw new ArgumentException($"Item at index {PointerIndex} is not traverserable.", nameof(PointerIndex));
            }
            else
            {
                PointerIndex = MenuActions.GetFirstTraverserableMenuItemIndex(Items);
            }

            IsBuilt = true;
            return this;
        }

        /// <inheritdoc/>
        public void Print() => MenuActions.Print(this);
    }
}
