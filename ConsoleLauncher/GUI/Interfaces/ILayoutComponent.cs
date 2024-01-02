namespace ConsoleLauncher.GUI.Interfaces
{
    /// <summary>
    /// Layout component.
    /// </summary>
    public interface ILayoutComponent : IVisibilityChanger, IPrintable, IColorChanger
    {
        /// <summary>
        /// Gets or sets the component item aligned to the left side.
        /// </summary>
        public IComponentItem? LeftItem { get; set; }

        /// <summary>
        /// Gets or sets the component item aligned to the center.
        /// </summary>
        public IComponentItem? CenterItem { get; set; }

        /// <summary>
        /// Gets or sets the component item aligned to the right side.
        /// </summary>
        public IComponentItem? RightItem { get; set; }

        /// <summary>
        /// Gets the top position of component.
        /// </summary>
        public int TopPosition { get; }
    }
}
