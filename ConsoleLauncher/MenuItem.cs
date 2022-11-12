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
        /// <param name="action">Action performed after selecting in menu.</param>
        public MenuItem(string name, Action action)
        {
            Description = name;
            Action = action;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="name">Text to print as menu entry.</param>
        public MenuItem(string name)
        {
            Description = name;
        }

        /// <inheritdoc/>
        public string Description { get; private set; }

        /// <inheritdoc/>
        public Action? Action { get; private set; }
    }
}
