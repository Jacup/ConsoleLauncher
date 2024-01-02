namespace ConsoleLauncher.Tests
{
    [TestFixture]
    internal class MenuFactoryTests
    {
        #region SetPointerTests

        [Test]
        public void SetPointerTest_ElementAtPointerIsNotTraverserable_ShouldReturnException()
        {
            // Arrange
            short pointer = 0;

            var menu = Launcher.Menu
                .AddItem(new MenuItem("One", false))
                .AddItem(new MenuItem("Two"))
                .SetPointerIndex(pointer);


            // Act & Assert
            Assert.Throws<ArgumentException>(() => menu.Build());
        }

        [Test]
        public void SetPointerTest_EveryItemIsNotTraverserable_ShouldReturnException()
        {
            // Arrange
            short pointer = 1;

            var menu = Launcher.Menu
                .AddItem(new MenuItem("One", false))
                .AddItem(new MenuItem("Two", false))
                .SetPointerIndex(pointer);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => menu.Build());
        }

        [Test]
        public void SetPointerTest_ElementAtPointerDoesNotExists_ShouldThrowException()
        {
            // Arrange
            short pointer = 2;

            var menu = Launcher.Menu
                .AddItem(new MenuItem("One"))
                .AddItem(new MenuItem("Two", false))
                .SetPointerIndex(pointer);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => menu.Build());
        }

        [Test]
        public void SetPointerTest_ElementAtPointerIsTraverserable_ShouldSetPointerCorrectly()
        {
            // Arrange
            short pointer = 2;

            var menu = Launcher.Menu
                .AddItem(new MenuItem("One"))
                .AddItem(new MenuItem("Two", false))
                .AddItem(new MenuItem("Three"))
                .Build();

            // Act
            menu.SetPointerIndex(pointer);

            //Assert
            Assert.AreEqual(pointer, menu.PointerIndex);
        }

        #endregion
    }
}
