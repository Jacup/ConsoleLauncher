namespace ConsoleLauncher.GUI
{
    /// <summary>
    /// Header used to be printed at top of the screen.
    /// </summary>
    public class Header : LayoutComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// </summary>
        public Header()
            : base()
        {
            TopPosition = Console.CursorTop;
            CenterItem = new TitleItem();
            RightItem = new ClockItem();
        }
    }
}