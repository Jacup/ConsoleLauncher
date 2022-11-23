namespace ConsoleLauncher
{
    using ConsoleLauncher.Enums;
    using ConsoleLauncher.Interfaces;
    using ConsoleLauncher.Layout;

    internal static class MenuActions
    {
        internal static short GetFirstTraverserableMenuItemIndex(List<MenuItem> items) => (short)items.FindIndex(item => item.IsTraverserable);

        internal static short GetLastTraverserableMenuItemIndex(List<MenuItem> items) => (short)items.FindLastIndex(item => item.IsTraverserable);

        internal static short GetNextTraverserableMenuItemIndex(IMenu menu)
        {
            if (menu.Pointer == menu.Items.Count - 1)
                return menu.Pointer;

            for (int i = menu.Pointer + 1; i < menu.Items.Count; i++)
            {
                if (menu.Items.ElementAt(i).IsTraverserable)
                    return (short)i;
            }

            return menu.Pointer;
        }

        internal static short GetPreviousTraverserableMenuItemIndex(IMenu menu)
        {
            if (menu.Pointer == 0)
                return menu.Pointer;

            for (int i = menu.Pointer - 1; i >= 0; i--)
            {
                if (menu.Items.ElementAt(i).IsTraverserable)
                    return (short)i;
            }

            return menu.Pointer;
        }

        internal static void Print(IMenu menu)
        {
            Validate(menu);
            Execute(menu);
        }

        internal static void Validate(IMenu menu)
        {
            if (!menu.IsBuilded)
                menu.Build();

            if (!menu.Items.Any())
                throw new ArgumentNullException(nameof(menu.Items), "There is not any elements to print.");
        }

        private static void Execute(IMenu menu)
        {
            MenuAction action;

            do
            {
                Render(menu);
                action = GetUserAction();
                PerformAction(action, menu);
            }
            while (action != MenuAction.Return);
        }

        private static void Render(IMenu menu)
        {
            Console.CursorVisible = false;
            Console.Clear();

            Header.PrintHeader();
            PrintBody(menu);
            Footer.PrintFooter();
        }

        private static void PrintBody(IMenu menu)
        {
            for (short i = 0; i < menu.Items.Count; i++)
            {
                if (i == menu.Pointer)
                {
                    Settings.SetColors(menu.HighlitedItemColors);

                    Console.WriteLine($"> {menu.Items.ElementAt(i).Description}");

                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine($"  {menu.Items.ElementAt(i).Description}");
            }
        }

        private static MenuAction GetUserAction()
        {
            var pressedKey = Console.ReadKey(true);

            return pressedKey.Key switch
            {
                ConsoleKey.Enter => MenuAction.Select,
                ConsoleKey.UpArrow => MenuAction.MoveUp,
                ConsoleKey.DownArrow => MenuAction.MoveDown,
                ConsoleKey.PageUp => MenuAction.PageUp,
                ConsoleKey.PageDown => MenuAction.PageDown,
                ConsoleKey.Escape => MenuAction.Return,
                _ => MenuAction.None,
            };
        }

        private static void PerformAction(MenuAction action, IMenu menu) // not sure if it is needed.
        {
            switch (action)
            {
                case MenuAction.Select:
                    menu.Items.ElementAt(menu.Pointer).Action?.Invoke();
                    break;
                case MenuAction.MoveUp:
                    menu.SetPointer(GetPreviousTraverserableMenuItemIndex(menu));
                    break;
                case MenuAction.MoveDown:
                    menu.SetPointer(GetNextTraverserableMenuItemIndex(menu));
                    break;
                case MenuAction.PageUp:
                    menu.SetPointer(GetFirstTraverserableMenuItemIndex(menu.Items));
                    break;
                case MenuAction.PageDown:
                    menu.SetPointer(GetLastTraverserableMenuItemIndex(menu.Items));
                    break;
                default:
                    break;
            }
        }
    }
}