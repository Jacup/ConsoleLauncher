namespace ConsoleLauncher.GUI
{
    /// <summary>
    /// Footer used to print at bottom of the screen.
    /// </summary>
    public class Footer : LayoutComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Footer"/> class.
        /// </summary>
        public Footer()
            : base()
        {
            TopPosition = Console.WindowHeight - 1;
        }
    }
}