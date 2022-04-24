namespace ConsoleLauncher
{
    /// <summary>
    /// Field.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        /// <param name="left">Left string.</param>
        /// <param name="right">Right string.</param>
        internal Field(string? left, string? right)
        {
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        /// <param name="left">Left string.</param>
        internal Field(string left)
        {
            Left = left;
        }

        public string? Left { get; }

        public string? Right { get; }


    }
}
