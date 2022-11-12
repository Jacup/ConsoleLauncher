namespace ConsoleLauncher
{
    using ConsoleLauncher.Interfaces;

    /// <summary>
    /// Printable menu with set of MenuOptions.
    /// </summary>
    public class Menu : IMenu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        internal Menu()
        {
            Items = new List<MenuItem>();
        }

        /// <inheritdoc/>
        public List<MenuItem> Items { get; private set; }

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
        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
