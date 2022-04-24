namespace ConsoleLauncher
{
    /// <summary>
    /// Layout.
    /// </summary>
    public class Layout
    {
        internal Layout(Field header, Field footer)
        {
            Header = header;
            Footer = footer;
        }

        /// <summary>
        /// Create header.
        /// </summary>
        /// <param name="left">left side.</param>
        /// <param name="right">right side.</param>
        /// <returns>header.</returns>
        public static Field CreateHeader(string left, string right)
        {
            return new Field(left, right);
        }

        public static Field CreateFooter(string left, string right)
        {
            return new Field(left, right);
        }

        internal Field Header { get; }
        internal Field Footer { get; }

    }
}
