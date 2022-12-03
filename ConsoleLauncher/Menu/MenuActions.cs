namespace ConsoleLauncher
{
    using ConsoleLauncher.Enums;
    using ConsoleLauncher.Helpers;
    using ConsoleLauncher.Interfaces;
    using ConsoleLauncher.Layout;

    internal static class MenuActions
    {
        internal static short GetFirstTraverserableMenuItemIndex(List<MenuItem> items) => (short)items.FindIndex(item => item.IsTraverserable);

        internal static short GetLastTraverserableMenuItemIndex(List<MenuItem> items) => (short)items.FindLastIndex(item => item.IsTraverserable);

        internal static short GetNextTraverserableMenuItemIndex(IMenu menu)
        {
            if (menu.Index == menu.Items.Count - 1)
                return menu.Index;

            for (int i = menu.Index + 1; i < menu.Items.Count; i++)
            {
                if (menu.Items.ElementAt(i).IsTraverserable)
                    return (short)i;
            }

            return menu.Index;
        }

        internal static short GetPreviousTraverserableMenuItemIndex(IMenu menu)
        {
            if (menu.Index == 0)
                return menu.Index;

            for (int i = menu.Index - 1; i >= 0; i--)
            {
                if (menu.Items.ElementAt(i).IsTraverserable)
                    return (short)i;
            }

            return menu.Index;
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
            PrintMenu(menu);
            Footer.PrintFooter();
        }

        private static void PrintMenu(IMenu menu)
        {
            for (short i = 0; i < menu.Items.Count; i++)
            {
                var currentItem = menu.Items.ElementAt(i);
                (ConsoleColor Background, ConsoleColor Foreground) colors;

                if (i == menu.Index)
                {
                    ConsoleHelper.WriteHighlitedItem(
                        currentItem.Description,
                        menu.HighlitedItemColors.GetValueOrDefault());

                    continue;
                }

                colors = currentItem.IsTraverserable
                    ? menu.ItemColors.GetValueOrDefault()
                    : menu.NonTraverserableItemColors.GetValueOrDefault();

                ConsoleHelper.WriteItem(
                    menu.Items.ElementAt(i).Description,
                    colors);
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
                    menu.Items.ElementAt(menu.Index).Action?.Invoke();
                    break;
                case MenuAction.MoveUp:
                    menu.SetIndex(GetPreviousTraverserableMenuItemIndex(menu));
                    break;
                case MenuAction.MoveDown:
                    menu.SetIndex(GetNextTraverserableMenuItemIndex(menu));
                    break;
                case MenuAction.PageUp:
                    menu.SetIndex(GetFirstTraverserableMenuItemIndex(menu.Items));
                    break;
                case MenuAction.PageDown:
                    menu.SetIndex(GetLastTraverserableMenuItemIndex(menu.Items));
                    break;
                default:
                    break;
            }
        }
    }
}