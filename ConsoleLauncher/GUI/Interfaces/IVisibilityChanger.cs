namespace ConsoleLauncher.GUI.Interfaces
{
    /// <summary>
    /// Represents the capability to change visibility of object.
    /// </summary>
    public interface IVisibilityChanger
    {
        /// <summary>
        /// Gets or sets a value indicating whether the object is visible.
        /// </summary>
        public bool Visible { get; set; }
    }
}