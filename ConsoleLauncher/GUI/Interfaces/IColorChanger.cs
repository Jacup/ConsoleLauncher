namespace ConsoleLauncher.GUI.Interfaces
{
    /// <summary>
    /// Represents funtion of changing color of object.
    /// </summary>
    public interface IColorChanger
    {
        /// <summary>
        /// Gets or sets colors of object.
        /// </summary>
        public (ConsoleColor Background, ConsoleColor Foreground)? Colors { get; set; }
    }
}