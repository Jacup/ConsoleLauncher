namespace ConsoleLauncher.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
                .AddItem(new("One", false))
                .AddItem(new("Two"))
                .Build();


            // Act & Assert
            Assert.Throws<ArgumentException>(() => menu.SetPointer(pointer));
        }

        [Test]
        public void SetPointerTest_EveryItemIsNotTraverserable_ShouldReturnException()
        {
            // Arrange
            short pointer = 1;

            var menu = Launcher.Menu
                .AddItem(new("One", false))
                .AddItem(new("Two", false))
                .Build();


            // Act & Assert
            Assert.Throws<ArgumentException>(() => menu.SetPointer(pointer));
        }

        [Test]
        public void SetPointerTest_ElementAtPointerDoesNotExists_ShouldThrowException()
        {
            // Arrange
            short pointer = 2;

            var menu = Launcher.Menu
                .AddItem(new("One"))
                .AddItem(new("Two", false))
                .Build();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => menu.SetPointer(pointer));
        }

        [Test]
        public void SetPointerTest_ElementAtPointerIsTraverserable_ShouldSetPointerCorrectly()
        {
            // Arrange
            short pointer = 2;

            var menu = Launcher.Menu
                .AddItem(new("One"))
                .AddItem(new("Two", false))
                .AddItem(new("Three"))
                .Build();

            // Act
            menu.SetPointer(pointer);

            //Assert
            Assert.AreEqual(pointer, menu.Pointer);
        }

        #endregion
    }
}
