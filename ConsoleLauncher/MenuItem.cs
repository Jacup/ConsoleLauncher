namespace ConsoleLauncher
{
    using ConsoleLauncher.Interfaces;

    /// <summary>
    /// Single item that is used to create menu entry.
    /// </summary>
    public class MenuItem : IMenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="name">Text to print as menu entry.</param>
        /// <param name="action">Action taken when item is choosen.</param>
        /// <param name="traverserable">Indicates whether item is traverserable.</param>
        public MenuItem(string name, Action action, bool traverserable = true)
        {
            Description = name;
            Action = action;
            Traverserable = traverserable;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="name">Text to print as menu entry.</param>
        /// <param name="traverserable">Indicates whether item is traverserable.</param>
        public MenuItem(string name, bool traverserable = true)
        {
            Description = name;
            Traverserable = traverserable;
        }

        /// <inheritdoc/>
        public string Description { get; private set; }

        /// <inheritdoc/>
        public Action? Action { get; private set; }

        /// <inheritdoc/>
        public bool Traverserable { get; private set; }
    }
}
