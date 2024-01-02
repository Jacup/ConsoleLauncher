namespace ConsoleLauncher.Setup
{
    /// <summary>
    /// Contains Launcher color setup.
    /// </summary>
    public class Colors
    {
        internal Colors()
        {
        }

        /// <summary>
        /// Gets or sets color of Menu Item background.
        /// </summary>
        public ConsoleColor MenuItemBackgroundColor { get; set; } = Console.BackgroundColor;

        /// <summary>
        /// Gets or sets color of Menu Item foreground.
        /// </summary>
        public ConsoleColor MenuItemForegroundColor { get; set; } = Console.ForegroundColor;

        /// <summary>
        /// Gets or sets color of Non Traverserable Menu Item background.
        /// </summary>
        public ConsoleColor MenuItemNonTraverserableBackgroudColor { get; set; } = Console.BackgroundColor;

        /// <summary>
        /// Gets or sets color of Non Traverserable Menu Item foreground.
        /// </summary>
        public ConsoleColor MenuItemNonTraverserableForegroundColor { get; set; } = ConsoleColor.DarkGray;

        /// <summary>
        /// Gets or sets color of Highlited Menu Item background.
        /// </summary>
        public ConsoleColor MenuItemHighlitedBackgroudColor { get; set; } = ConsoleColor.White;

        /// <summary>
        /// Gets or sets color of Highlited Menu Item foreground.
        /// </summary>
        public ConsoleColor MenuItemHighlitedForegroundColor { get; set; } = ConsoleColor.Black;

        internal (ConsoleColor Background, ConsoleColor Foreground)? DefaultNonTraverserableColors()
        {
            return (MenuItemNonTraverserableBackgroudColor, MenuItemNonTraverserableForegroundColor);
        }

        internal (ConsoleColor Background, ConsoleColor Foreground)? DefaultItemColors()
        {
            return (MenuItemBackgroundColor, MenuItemForegroundColor);
        }

        internal (ConsoleColor Background, ConsoleColor Foreground)? DefaultHighlitedColors()
        {
            return (MenuItemHighlitedBackgroudColor, MenuItemHighlitedForegroundColor);
        }
    }
}