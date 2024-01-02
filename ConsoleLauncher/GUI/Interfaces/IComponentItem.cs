namespace ConsoleLauncher.GUI.Interfaces
{
    /// <summary>
    /// Represents item that can be placed in the Layout Component.
    /// </summary>
    public interface IComponentItem : IVisibilityChanger, IColorChanger
    {
        /// <summary>
        /// Gets or sets the content of layout component.
        /// </summary>
        string Content { get; set; }
    }
}