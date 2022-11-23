namespace ConsoleLauncher
{
    using ConsoleLauncher.Interfaces;

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
        public (ConsoleColor Background, ConsoleColor Foreground) HighlitedItemColors { get; private set; }

        /// <inheritdoc/>
        public bool CustomHighlitedItem { get; private set; }

        /// <inheritdoc/>
        public short Pointer { get; private set; }

        /// <inheritdoc/>
        public bool PointerSet { get; private set; }

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
        public IMenu SetHighlitedColors(ConsoleColor backgroundColor, ConsoleColor fontColor)
        {
            HighlitedItemColors = (backgroundColor, fontColor);
            CustomHighlitedItem = true;
            return this;
        }

        /// <inheritdoc/>
        public IMenu SetPointer(short index)
        {
            if (Items.ElementAtOrDefault(index) == null)
                throw new ArgumentException($"Item at index {index} does not exists.", nameof(index));
            if (!Items.ElementAt(index).IsTraverserable)
                throw new ArgumentException($"Item at index {index} is not traverserable.", nameof(index));

            Pointer = index;
            PointerSet = true;

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

            if (!CustomHighlitedItem)
                HighlitedItemColors = GetDefaultHighlitedColors();

            if (!PointerSet)
                Pointer = MenuActions.GetFirstTraverserableMenuItemIndex(Items);

            IsBuilded = true;

            return this;
        }

        private static (ConsoleColor Background, ConsoleColor Foreground) GetDefaultHighlitedColors() // TODO: FIX
        {
            return (ConsoleColor.White, ConsoleColor.Black);
        }

        /// <inheritdoc/>
        public void Print() => MenuActions.Print(this);
    }
}
