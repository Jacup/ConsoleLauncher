using ConsoleLauncher.GUI.Interfaces;
using ConsoleLauncher.Helpers;

namespace ConsoleLauncher.GUI
{
    /// <summary>
    /// Generic Layout component.
    /// </summary>
    public abstract class LayoutComponent : ILayoutComponent
    {
        /// <inheritdoc/>
        public int TopPosition { get; set; }

        /// <inheritdoc/>
        public bool Visible { get; set; }

        /// <inheritdoc/>
        public IComponentItem? LeftItem { get; set; }

        /// <inheritdoc/>
        public IComponentItem? CenterItem { get; set; }

        /// <inheritdoc/>
        public IComponentItem? RightItem { get; set; }

        /// <inheritdoc/>
        public (ConsoleColor Background, ConsoleColor Foreground)? Colors { get; set; }

        /// <inheritdoc/>
        public void Print()
        {
            if (!Visible)
                return;

            if (LeftItem != null && LeftItem.Visible)
                Write(LeftItem, Console.WindowLeft);

            if (CenterItem != null && CenterItem.Visible)
                Write(CenterItem, (Console.WindowWidth - CenterItem.Content.Length) / 2);

            if (RightItem != null && RightItem.Visible)
                Write(RightItem, Console.WindowWidth - RightItem.Content.Length);

            Console.ResetColor();
        }

        private void Write(IComponentItem item, int left)
        {
            Console.SetCursorPosition(left, TopPosition);
            ConsoleHelper.SetColors(GetColors(item));
            Console.Write(item.Content);
        }

        private (ConsoleColor Background, ConsoleColor Foreground) GetColors(IComponentItem item)
        {
            if (item.Colors.HasValue)
                return item.Colors.GetValueOrDefault();
            else if (Colors.HasValue)
                return Colors.GetValueOrDefault();
            else
                return Launcher.Settings.Colors.DefaultItemColors().GetValueOrDefault();
        }
    }
}
