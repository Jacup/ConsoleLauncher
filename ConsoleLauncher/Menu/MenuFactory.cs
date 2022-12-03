namespace ConsoleLauncher
{
    using ConsoleLauncher.Interfaces;
    using ConsoleLauncher.Layout;
    using System;
    using System.Linq;

    /// <summary>
    /// Printable menu with set of MenuItems.
    /// </summary>
    public class MenuFactory : IMenu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuFactory"/> class.
        /// </summary>
        internal MenuFactory()
        {
            Items = new List<MenuItem>();
        }

        /// <inheritdoc/>
        public bool ExitItemFlag { get; private set; }

        /// <inheritdoc/>
        public bool ReturnItemFlag { get; private set; }

        /// <inheritdoc/>
        public bool IsBuilded { get; private set; }

        /// <inheritdoc/>
        public List<MenuItem> Items { get; private set; }

        /// <inheritdoc/>
        public short Index { get; private set; }

        /// <inheritdoc/>
        public bool IndexSetFlag { get; private set; }

        /// <inheritdoc/>
        public (ConsoleColor Background, ConsoleColor Foreground)? HighlitedItemColors { get; private set; }

        /// <inheritdoc/>
        public (ConsoleColor Background, ConsoleColor Foreground)? ItemColors { get; private set; }

        /// <inheritdoc/>
        public (ConsoleColor Background, ConsoleColor Foreground)? NonTraverserableItemColors { get; private set; }

        /// <inheritdoc/>
        public char? PointerCharacter { get; private set; }

        /// <inheritdoc/>
        public IMenu AddItem(MenuItem menuItem)
        {
            Items.Add(menuItem);

            return this;
        }

        /// <inheritdoc/>
        public IMenu Setup()
        {
            throw new NotImplementedException();
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
        public IMenu SetItemColors(ConsoleColor backgroundColor, ConsoleColor fontColor)
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
            PointerCharacter = pointer;

            return this;
        }

        /// <inheritdoc/>
        public IMenu SetIndex(short index)
        {
            Index = index;

            return this;
        }

        /// <inheritdoc/>
        public IMenu Build()
        {
            if (IsBuilded)
                return this;

            if (ReturnItemFlag && !Items.Any(item => item.Description.Equals("Return")))
                Items.Add(new("Return", () => { return; }));

            if (ExitItemFlag && !Items.Any(item => item.Description.Equals("Exit")))
                Items.Add(new("Exit", () => Environment.Exit(0)));

            ItemColors ??= Launcher.Settings.Colors.DefaultItemColors();
            HighlitedItemColors ??= Launcher.Settings.Colors.DefaultHighlitedColors();
            NonTraverserableItemColors ??= Launcher.Settings.Colors.DefaultNonTraverserableColors();

            if (IndexSetFlag)
            {
                if (Items.ElementAtOrDefault(Index) == null)
                    throw new ArgumentException($"Item at index {Index} does not exists.", nameof(Index));
                if (!Items.ElementAt(Index).IsTraverserable)
                    throw new ArgumentException($"Item at index {Index} is not traverserable.", nameof(Index));
            }
            else
            {
                Index = MenuActions.GetFirstTraverserableMenuItemIndex(Items);
            }

            IsBuilded = true;
            return this;
        }

        /// <inheritdoc/>
        public void Print() => MenuActions.Print(this);
    }
}
