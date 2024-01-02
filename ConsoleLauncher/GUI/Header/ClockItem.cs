namespace ConsoleLauncher.GUI
{
    using ConsoleLauncher.GUI.Interfaces;

    /// <summary>
    /// Clock ComponentItem.
    /// </summary>
    public class ClockItem : ComponentItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClockItem"/> class.
        /// </summary>
        /// <param name="timeFormat">Format used to print time.</param>
        public ClockItem(string timeFormat = "HH:mm")
            : base(DateTime.Now.ToString(timeFormat))
        {
        }
    }
}
