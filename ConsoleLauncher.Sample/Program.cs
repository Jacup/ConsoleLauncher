namespace ConsoleLauncher.Sample
{
    using ConsoleLauncher.GUI.Interfaces;
    using ConsoleLauncher.GUI.MenuItems;

    internal class Program
    {
        static void Main(string[] args)
        {
            var menu = Launcher.Menu
                .AddExitItem()
                .AddItem(new MenuItem("One", false))
                .AddItem(new MenuItem("Two1"))
                .AddItem(new MenuItem("Two2", false))
                .AddItem(new MenuItem("Two3", false))
                .AddItem(new MenuItem("Settings", Submenu1))
                .AddItem(new MenuItem("Three"))
                .SetPointerCharacter('^')
                .Build();

            Launcher.Layout.Header.Visible = true;
            Launcher.Layout.Footer.Visible = true;
            Launcher.Layout.Footer.RightItem = new ComponentItem("RightFooter", true, (ConsoleColor.Black, ConsoleColor.Red));

            menu.Print();

            //new MenuItem("");
            //new MenuItem("", Submenu1);
            //new MenuItem("", () => Submenu1());
            //new MenuItem("", false);
        }

        private static void Submenu1()
        {
            Launcher.Menu
                .AddItem(new MenuItem("Switch header visibility", SwitchHeaderVisibility))
                .AddItem(new MenuItem("Four"))
                .SetHighlitedColors(ConsoleColor.Blue, ConsoleColor.Yellow)
                .AddReturnItem()
                .AddExitItem()
                .Print();
        }

        private static void SwitchHeaderVisibility() => Launcher.Layout.Header.Visible = !Launcher.Layout.Header.Visible;
    }
}