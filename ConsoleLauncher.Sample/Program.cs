namespace ConsoleLauncher.Sample
{
    using ConsoleLauncher.Layout;
    using System.Net.Http.Headers;

    internal class Program
    {
        static void Main(string[] args)
        {

            var menu = Launcher.Menu
                .AddItem(new("One", false))
                .AddItem(new("Two1"))
                .AddItem(new("Two2", false))
                .AddItem(new("Two3", false))
                .AddItem(new("Two4"))
                .AddItem(new("Three"))
                .AddItem(new("Method", Method1))
                .SetItemColors(ConsoleColor.DarkBlue, ConsoleColor.Magenta)
                .SetNonTraverserableItemColors(ConsoleColor.White, ConsoleColor.Red)
                .AddExitItem()
                .Build();

            menu.Print();


            //Launcher.Menu
            //    .AddItem(new("One"))
            //    .AddItem(new("Two"))
            //    .AddExitItem()
            //    .AddReturnItem()
            //    .AddItem(new("Three"))
            //    .AddItem(new("Four", Method1))
            //    .Print();

            new MenuItem("");
            new MenuItem("", Method1);
            new MenuItem("", () => Method1());
            new MenuItem("", false);

        }

        private static void Method1()
        {
            Launcher.Menu
                .AddItem(new("One"))
                .AddReturnItem()
                .AddExitItem()
                .AddItem(new("Four"))
                .SetHighlitedColors(ConsoleColor.Blue, ConsoleColor.Yellow)
                .Print();
        }
    }
}