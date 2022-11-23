namespace ConsoleLauncher.Tests
{
    [TestFixture]
    internal class MenuActionsTests
    {
        #region ValidateTests

        [Test]
        public void ValidateTest_EmptyItemsList_ShouldThrowException()
        {
            // Arrange
            var menu = Launcher.Menu.Build();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => MenuActions.Validate(menu));
        }

        [Test]
        public void ValidateTest_NonEmptyItemsList_ShouldNotThrowException()
        {
            // Arrange
            var menu = Launcher.Menu.AddItem(new("")).Build();

            // Act & Assert
            Assert.DoesNotThrow(() => MenuActions.Validate(menu));
        }

        #endregion

        #region GetFirstTraverserableMenuItemIndexTests

        [Test]
        public void GetFirstTraverserableMenuItemIndexTest_AllItemsTraverserable_ShouldPointAtFirstElement()
        {
            // Arrange
            List<MenuItem> menuItems = new()
            {
                new("One"), new("Two"), new("Three")
            };

            short expectedPointer = 0;

            // Act
            var actualPointer = MenuActions.GetFirstTraverserableMenuItemIndex(menuItems);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetFirstTraverserableMenuItemIndexTest_FirstItemNotTraverserable_ShouldPointAtSecondElement()
        {
            // Arrange
            List<MenuItem> menuItems = new()
            {
                new("One", false), new("Two"), new("Three")
            };

            short expectedPointer = 1;

            // Act
            var actualPointer = MenuActions.GetFirstTraverserableMenuItemIndex(menuItems);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetFirstTraverserableMenuItemIndexTest_AllItemsNotTraverserable_ShouldReturnNegative()
        {
            // Arrange
            List<MenuItem> menuItems = new()
            {
                new("One", false), new("Two", false), new("Three", false)
            };

            short expectedPointer = -1;

            // Act
            var actualPointer = MenuActions.GetFirstTraverserableMenuItemIndex(menuItems);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        #endregion

        #region GetLastTraverserableMenuItemIndexTests

        [Test]
        public void GetLastTraverserableMenuItemIndexTest_AllItemsTraverserable_ShouldPointAtLastElement()
        {
            // Arrange
            List<MenuItem> menuItems = new()
            {
                new("One"), new("Two"), new("Three")
            };

            short expectedPointer = 2;

            // Act
            var actualPointer = MenuActions.GetLastTraverserableMenuItemIndex(menuItems);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetLastTraverserableMenuItemIndexTest_FirstItemNotTraverserable_ShouldPointAtThirdElement()
        {
            // Arrange
            List<MenuItem> menuItems = new()
            {
                new("One", false), new("Two"), new("Three"), new("Four", false)
            };

            short expectedPointer = 2;

            // Act
            var actualPointer = MenuActions.GetLastTraverserableMenuItemIndex(menuItems);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetLastTraverserableMenuItemIndexTest_FirstItemNotTraverserable_ShouldPointAtFirstElement()
        {
            // Arrange
            List<MenuItem> menuItems = new()
            {
                new("One", false), new("Two"), new("Three"), new("Four", false)
            };

            short expectedPointer = 2;

            // Act
            var actualPointer = MenuActions.GetLastTraverserableMenuItemIndex(menuItems);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetLastTraverserableMenuItemIndexTest_AllItemsNotTraverserable_ShouldReturnNegative()
        {
            // Arrange
            List<MenuItem> menuItems = new()
            {
                new("One", false), new("Two", false), new("Three", false)
            };

            short expectedPointer = -1;

            // Act
            var actualPointer = MenuActions.GetLastTraverserableMenuItemIndex(menuItems);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        #endregion

        #region GetNextTraverserableMenuItemIndex

        [Test]
        public void GetNextTraverserableMenuItemIndexTest_NextItemTraverserable_ShouldReturnNextElementIndex()
        {
            // Arrange
            var menu = Launcher.Menu
                .AddItem(new("One"))
                .AddItem(new("Two"))
                .AddItem(new("Three"))
                .Build();

            short expectedPointer = 1;

            // Act
            var actualPointer = MenuActions.GetNextTraverserableMenuItemIndex(menu);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetNextTraverserableMenuItemIndexTest_NextItemNotTraverserable_ShouldReturnNextElementIndex()
        {
            // Arrange
            var menu = Launcher.Menu
                .AddItem(new("One"))
                .AddItem(new("Two", false))
                .AddItem(new("Three"))
                .Build();

            short expectedPointer = 2;

            // Act
            var actualPointer = MenuActions.GetNextTraverserableMenuItemIndex(menu);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetNextTraverserableMenuItemIndexTest_NextItemsNotTraverserable_ShouldReturnCurrentIndex()
        {
            // Arrange
            var menu = Launcher.Menu
                .AddItem(new("One"))
                .AddItem(new("Two", false))
                .AddItem(new("Three", false))
                .Build();

            short expectedPointer = 0;

            // Act
            var actualPointer = MenuActions.GetNextTraverserableMenuItemIndex(menu);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetNextTraverserableMenuItemIndexTest_AllItemsNotTraverserable_ShouldReturnNegative()
        {
            // Arrange
            var menu = Launcher.Menu
                .AddItem(new("One", false))
                .AddItem(new("Two", false))
                .AddItem(new("Three", false))
                .Build();

            short expectedPointer = -1;

            // Act
            var actualPointer = MenuActions.GetNextTraverserableMenuItemIndex(menu);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetNextTraverserableMenuItemIndexTest_PointerAtLastElement_ShouldReturnCurrentIndex()
        {
            // Arrange
            var menu = Launcher.Menu
                .AddItem(new("One"))
                .AddItem(new("Two"))
                .AddItem(new("Three"))
                .SetPointer(2)
                .Build();

            short expectedPointer = 2;

            // Act
            var actualPointer = MenuActions.GetNextTraverserableMenuItemIndex(menu);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        #endregion

        #region GetPreviousTraverserableMenuItemIndex

        [Test]
        public void GetPreviousTraverserableMenuItemIndexTest_PointerAtFirstElement_ShouldReturnCurrentIndex()
        {
            // Arrange
            var menu = Launcher.Menu
                .AddItem(new("One"))
                .AddItem(new("Two"))
                .AddItem(new("Three"))
                .Build();

            short expectedPointer = 0;

            // Act
            var actualPointer = MenuActions.GetPreviousTraverserableMenuItemIndex(menu);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetPreviousTraverserableMenuItemIndexTest_PreviousItemNotTraverserable_ShouldReturnNextValidElementIndex()
        {
            // Arrange
            var menu = Launcher.Menu
                .AddItem(new("One"))
                .AddItem(new("Two", false))
                .AddItem(new("Three"))
                .SetPointer(2)
                .Build();

            short expectedPointer = 0;

            // Act
            var actualPointer = MenuActions.GetPreviousTraverserableMenuItemIndex(menu);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetPreviousTraverserableMenuItemIndexTest_PreviousItemTraverserable_ShouldReturnNextElementIndex()
        {
            // Arrange
            var menu = Launcher.Menu
                .AddItem(new("One"))
                .AddItem(new("Two"))
                .AddItem(new("Three"))
                .SetPointer(2)
                .Build();

            short expectedPointer = 1;

            // Act
            var actualPointer = MenuActions.GetPreviousTraverserableMenuItemIndex(menu);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetPreviousTraverserableMenuItemIndexTest_NextItemsNotTraverserable_ShouldReturnCurrentIndex()
        {
            // Arrange
            var menu = Launcher.Menu
                .AddItem(new("One", false))
                .AddItem(new("Two", false))
                .AddItem(new("Three"))
                .SetPointer(2)
                .Build();

            short expectedPointer = 2;

            // Act
            var actualPointer = MenuActions.GetPreviousTraverserableMenuItemIndex(menu);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetPreviousTraverserableMenuItemIndexTest_AllItemsNotTraverserable_ShouldReturnNegative()
        {
            // Arrange
            var menu = Launcher.Menu
                .AddItem(new("One", false))
                .AddItem(new("Two", false))
                .AddItem(new("Three", false))
                .Build();

            short expectedPointer = -1;

            // Act
            var actualPointer = MenuActions.GetPreviousTraverserableMenuItemIndex(menu);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        #endregion

    }
}
