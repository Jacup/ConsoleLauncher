namespace ConsoleLauncher.GUI
{
    using ConsoleLauncher.GUI.Enums;
    using ConsoleLauncher.GUI.Interfaces;
    using ConsoleLauncher.GUI.MenuItems;
    using ConsoleLauncher.Helpers;

    internal static class MenuActions
    {
        internal static short GetFirstTraverserableMenuItemIndex(IEnumerable<IMenuItem> items)
        {
            return (short)items.ToList().FindIndex(item => item.IsTraverserable);
        }

        internal static short GetLastTraverserableMenuItemIndex(IEnumerable<IMenuItem> items)
        {
            return (short)items.ToList().FindLastIndex(item => item.IsTraverserable);
        }

        internal static short GetNextTraverserableMenuItemIndex(IMenu menu)
        {
            if (menu.PointerIndex == menu.Items.Count - 1)
                return menu.PointerIndex;

            for (int i = menu.PointerIndex + 1; i < menu.Items.Count; i++)
            {
                if (menu.Items.ElementAt(i).IsTraverserable)
                    return (short)i;
            }

            return menu.PointerIndex;
        }

        internal static short GetPreviousTraverserableMenuItemIndex(IMenu menu)
        {
            if (menu.PointerIndex == 0)
                return menu.PointerIndex;

            for (int i = menu.PointerIndex - 1; i >= 0; i--)
            {
                if (menu.Items.ElementAt(i).IsTraverserable)
                    return (short)i;
            }

            return menu.PointerIndex;
        }

        internal static void Print(IMenu menu)
        {
            Validate(menu);
            ExecuteUI(menu);
        }

        internal static void Validate(IMenu menu)
        {
            if (!menu.IsBuilt)
                menu.Build();

            if (!menu.Items.Any())
                throw new ArgumentNullException(nameof(menu.Items), "There are no elements to print.");
        }

        private static void ExecuteUI(IMenu menu)
        {
            MenuAction action;
            MenuAction result;
            do
            {
                Render(menu);
                action = GetUserAction();
                PerformAction(out result, action, menu);
            }
            while (action != MenuAction.Return && result != MenuAction.Return);
        }

        private static void Render(IMenu menu)
        {
            Console.CursorVisible = false;
            Console.Clear();

            Launcher.Layout.Header.Print();
            PrintMenu(menu);
            Launcher.Layout.Footer.Print();
        }

        private static void PrintMenu(IMenu menu)
        {
            IMenuItem[] itemsToPrint = CreatePrintableCollection(menu);

            for (short i = 0; i < itemsToPrint.Length; i++)
            {
                var currentItem = itemsToPrint[i];
                (ConsoleColor Background, ConsoleColor Foreground) colors;

                if (i == menu.PointerIndex)
                {
                    ConsoleHelper.WriteHighlitedItem(
                        currentItem.Description,
                        menu.HighlitedItemColors.GetValueOrDefault(),
                        menu.PointerChar);

                    continue;
                }

                colors = currentItem.IsTraverserable
                    ? menu.ItemColors.GetValueOrDefault()
                    : menu.NonTraverserableItemColors.GetValueOrDefault();

                ConsoleHelper.WriteItem(
                    itemsToPrint[i].Description,
                    colors);
            }
        }

        // TODO: enable large collections of IMenuItems(more than buffer height).
        private static IMenuItem[] CreatePrintableCollection(IMenu menu)
        {
            int height = Console.BufferHeight - (Launcher.Layout.Header.Visible ? 1 : 0) - (Launcher.Layout.Footer.Visible ? 1 : 0);

            IMenuItem[] printableItems = new IMenuItem[height];

            if (menu.Items.Count <= height)
                return menu.Items.ToArray();

            return printableItems;
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

        private static void PerformAction(out MenuAction actionResult, MenuAction action, IMenu menu)
        {
            actionResult = MenuAction.None;

            switch (action)
            {
                case MenuAction.Select:
                    if (menu.Items.ElementAt(menu.PointerIndex) is ReturnItem)
                    {
                        actionResult = MenuAction.Return;
                        break;
                    }

                    menu.Items.ElementAt(menu.PointerIndex).Action?.Invoke();
                    break;
                case MenuAction.MoveUp:
                    menu.SetPointerIndex(GetPreviousTraverserableMenuItemIndex(menu));
                    break;
                case MenuAction.MoveDown:
                    menu.SetPointerIndex(GetNextTraverserableMenuItemIndex(menu));
                    break;
                case MenuAction.PageUp:
                    menu.SetPointerIndex(GetFirstTraverserableMenuItemIndex(menu.Items));
                    break;
                case MenuAction.PageDown:
                    menu.SetPointerIndex(GetLastTraverserableMenuItemIndex(menu.Items));
                    break;
                default:
                    break;
            }
        }
    }
}