namespace ConsoleLauncher
{
    using ConsoleLauncher.Interfaces;

    /// <summary>
    /// Printable menu with set of MenuItems.
    /// </summary>
    public class MenuFactory : IMenuFactory
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

        private static (ConsoleColor Background, ConsoleColor Foreground) HighlitedEntryColors { get; set; } = (Console.ForegroundColor, Console.BackgroundColor);

        /// <inheritdoc/>
        public IMenuFactory AddItem(MenuItem menuItem)
        {
            Items.Add(menuItem);

            return this;
        }

        /// <inheritdoc/>
        public IMenuFactory Setup()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IMenuFactory AddExitItem()
        {
            ExitItemFlag = true;

            return this;
        }

        /// <inheritdoc/>
        public IMenuFactory AddReturnItem()
        {
            ReturnItemFlag = true;

            return this;
        }

        /// <inheritdoc/>
        public IMenuFactory Build()
        {
            if (ReturnItemFlag)
                Items.Add(new("Return", () => { return; }));
            if (ExitItemFlag)
                Items.Add(new("Exit", () => Environment.Exit(0)));

            IsBuilded = true;

            return this;
        }

        /// <inheritdoc/>
        public void Print()
        {
            _ = new MenuWriter(this);
        }
    }
}
