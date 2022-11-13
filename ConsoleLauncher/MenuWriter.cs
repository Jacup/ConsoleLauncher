namespace ConsoleLauncher
{
    using ConsoleLauncher.Interfaces;
    using ConsoleLauncher.Layout;

    public class MenuWriter
    {
        public MenuWriter(IMenuFactory menu)
        {
            Print(menu);
        }

        public void Print(IMenuFactory menu)
        {
            if (menu.IsBuilded)
                menu.Build();

            if (Items.Count < 1)
                throw new ArgumentNullException("There is not any elements to print.");

            Console.CursorVisible = false;
            ConsoleKeyInfo keyAction;
            short pointer = 0;

            do
            {
                GenerateView(pointer);

                keyAction = Console.ReadKey(true);
                pointer = DoAction(keyAction, pointer);
            }
            while (keyAction.Key != ConsoleKey.Escape);
        }

        private void GenerateView(short pointer)
        {
            Console.Clear();

            Header.PrintHeader();
            PrintBody(pointer);

            if (Footer.IsVisible)
                Footer.PrintFooter();
        }

        private void PrintBody(short pointer)
        {
            for (short i = 0; i < Items.Count; i++)
            {
                if (pointer == i)
                {
                    if (!Items[i].Traverserable)
                    {
                        pointer++;
                        break;
                    }

                    Settings.SetColors(HighlitedEntryColors);

                    Console.WriteLine($"> " + Items[i].Description);

                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine($"  " + Items[i].Description);
            }
        }

        private short DoAction(ConsoleKeyInfo keyAction, short pointer)
        {
            switch (keyAction.Key)
            {
                case ConsoleKey.Enter:
                    Items[pointer].Action?.Invoke();
                    break;

                case ConsoleKey.PageUp:
                case ConsoleKey.UpArrow:
                    if (pointer > 0)
                        pointer--;
                    break;

                case ConsoleKey.PageDown:
                case ConsoleKey.DownArrow:
                    if (pointer < Items.Count - 1)
                        pointer++;
                    break;
            }

            return pointer;
        }


    }
}
