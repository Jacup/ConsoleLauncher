namespace ConsoleLauncher.GUI
{
    using System.Diagnostics;
    using ConsoleLauncher.GUI.Interfaces;

    /// <summary>
    /// Title ComponentItem.
    /// </summary>
    public class TitleItem : ComponentItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TitleItem"/> class.
        /// </summary>
        public TitleItem()
            : base(Process.GetCurrentProcess().ProcessName)
        {
        }
    }
}
