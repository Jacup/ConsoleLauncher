namespace ConsoleLauncher.Interfaces
{
    /// <summary>
    /// Single menu item that is used to create menu entry.
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// Gets description of menu item.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets action of menu item.
        /// </summary>
        public Action? Action { get; }

        /// <summary>
        /// Gets a value indicating whether item is traverserable.
        /// </summary>
        public bool Traverserable { get; }
    }
}
