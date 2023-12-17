namespace ConsoleLauncher.Tests
{
    using ConsoleLauncher.GUI;
    using ConsoleLauncher.GUI.MenuItems;
    using Moq;

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
            var menu = Launcher.Menu.AddItem(new MenuItem("")).Build();

            // Act & Assert
            Assert.DoesNotThrow(() => MenuActions.Validate(menu));
        }

        #endregion

        #region GetFirstTraverserableMenuItemIndexTests

        [Test]
        public void GetFirstTraverserableMenuItemIndexTest_AllItemsTraverserable_ShouldPointAtFirstElement()
        {
            // Arrange
            List<IMenuItem> menuItems = new()
            {
                new MenuItem("One"), new MenuItem("Two"), new MenuItem("Three")
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
            List<IMenuItem> menuItems = new()
            {
                new MenuItem("One", false), new MenuItem("Two"), new MenuItem("Three")
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
            List<IMenuItem> menuItems = new()
            {
                new MenuItem("One", false), new MenuItem("Two", false), new MenuItem("Three", false)
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
            List<IMenuItem> menuItems = new()
            {
                new MenuItem("One"), new MenuItem("Two"), new MenuItem("Three")
            };

            short expectedPointer = 2;

            // Act
            var actualPointer = MenuActions.GetLastTraverserableMenuItemIndex(menuItems);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetLastTraverserableMenuItemIndexTest_LastItemNotTraverserable_ShouldPointAtThirdElement()
        {
            // Arrange
            List<IMenuItem> menuItems = new()
            {
                new MenuItem("One", false), new MenuItem("Two"), new MenuItem("Three"), new MenuItem("Four", false)
            };

            short expectedPointer = 2;

            // Act
            var actualPointer = MenuActions.GetLastTraverserableMenuItemIndex(menuItems);

            // Assert
            Assert.AreEqual(expectedPointer, actualPointer);
        }

        [Test]
        public void GetLastTraverserableMenuItemIndexTest_FirstAndLastItemNotTraverserable_ShouldPointAtThirdElement()
        {
            // Arrange
            List<IMenuItem> menuItems = new()
            {
                new MenuItem("One", false), new MenuItem("Two"), new MenuItem("Three"), new MenuItem("Four", false)
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
            List<IMenuItem> menuItems = new()
            {
                new MenuItem("One", false), new MenuItem("Two", false), new MenuItem("Three", false)
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
                .AddItem(new MenuItem("One"))
                .AddItem(new MenuItem("Two"))
                .AddItem(new MenuItem("Three"))
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
                .AddItem(new MenuItem("One"))
                .AddItem(new MenuItem("Two", false))
                .AddItem(new MenuItem("Three"))
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
                .AddItem(new MenuItem("One"))
                .AddItem(new MenuItem("Two", false))
                .AddItem(new MenuItem("Three", false))
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
                .AddItem(new MenuItem("One", false))
                .AddItem(new MenuItem("Two", false))
                .AddItem(new MenuItem("Three", false))
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
                .AddItem(new MenuItem("One"))
                .AddItem(new MenuItem("Two"))
                .AddItem(new MenuItem("Three"))
                .SetPointerIndex(2)
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
                .AddItem(new MenuItem("One"))
                .AddItem(new MenuItem("Two"))
                .AddItem(new MenuItem("Three"))
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
                .AddItem(new MenuItem("One"))
                .AddItem(new MenuItem("Two", false))
                .AddItem(new MenuItem("Three"))
                .SetPointerIndex(2)
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
                .AddItem(new MenuItem("One"))
                .AddItem(new MenuItem("Two"))
                .AddItem(new MenuItem("Three"))
                .SetPointerIndex(2)
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
                .AddItem(new MenuItem("One", false))
                .AddItem(new MenuItem("Two", false))
                .AddItem(new MenuItem("Three"))
                .SetPointerIndex(2)
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
                .AddItem(new MenuItem("One", false))
                .AddItem(new MenuItem("Two", false))
                .AddItem(new MenuItem("Three", false))
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
