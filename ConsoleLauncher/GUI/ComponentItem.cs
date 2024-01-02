namespace ConsoleLauncher.GUI.Interfaces
{
    /// <summary>
    /// Represents item that can be placed in the Layout Component.
    /// </summary>
    public class ComponentItem : IComponentItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentItem"/> class.
        /// </summary>
        /// <param name="content">Content to be displayed.</param>
        /// <param name="visible">Visibility of item. Does no override component visibility.</param>
        /// <param name="colors">Custom colors for item.</param>
        public ComponentItem(string content, bool visible = true, (ConsoleColor Background, ConsoleColor Foreground)? colors = null)
        {
            Content = content;
            Visible = visible;
            Colors = colors;
        }

        /// <summary>
        /// Gets or sets the content of layout component.
        /// </summary>
        public string Content { get; set; }

        /// <inheritdoc/>
        public bool Visible { get; set; }

        /// <inheritdoc/>
        public (ConsoleColor Background, ConsoleColor Foreground)? Colors { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Content.ToString();
        }
    }
}