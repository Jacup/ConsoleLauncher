namespace ConsoleLauncher
{
    /// <summary>
    /// Single option entry listed in Menu.
    /// </summary>
    public class Option
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Option"/> class.
        /// </summary>
        /// <param name="name">Text to print as menu entry.</param>
        /// <param name="action">Action performed after selecting in menu.</param>
        public Option(string name, Action action)
        {
            Name = name;
            Action = action;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Option"/> class.
        /// </summary>
        /// <param name="name">Text to print as menu entry.</param>
        public Option(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets Action.
        /// </summary>
        public Action? Action { get; }
    }
}
