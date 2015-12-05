using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildIt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Moq;

namespace BuildIt.Tests
{
    [TestClass]
    public class InventoryTest
    {
        private Mock<InventoryContext> mock_context;
        private Mock<IDbSet<Inventory>> mock_Inventory;
        private List<Inventory> my_inventory;
        private ApplicationUser owner, user1;
        

        private void ConnectsMocksToDataSource()
        {
            var data = my_inventory.AsQueryable();

            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_context.Setup(m => m.Inventory).Returns(mock_Inventory.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<InventoryContext>();
            mock_Inventory = new Mock<IDbSet<Inventory>>();
            my_inventory = new List<Inventory>();
            owner = new ApplicationUser();
            user1 = new ApplicationUser();
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_Inventory = null;
            my_inventory = null;
        }


        [TestMethod]
        public void InventoryEnsureIcanCreateAnInventory()
        {
            Inventory inventory = new Inventory();
            Assert.IsNotNull(inventory);
        }

        [TestMethod]
        public void InventorEnsureInventoryPropertiresWork()
        {
            //Begin Arrange
            Inventory InventoryContent = new Inventory { FabricType = "linen", FabricColor = "tan", FabricAmount = 5, FabricUnit = "yards" };
            //Inventory.Project.Add(ProjectItems);
            //End Arrange

            //Begin Act
            //End Act

            //Begin Assert
            Assert.AreEqual("linen", InventoryContent.FabricType);
            Assert.AreEqual("tan", InventoryContent.FabricColor);
            Assert.AreEqual(5, InventoryContent.FabricAmount);
            Assert.AreEqual("yards", InventoryContent.FabricUnit);
            //End Assert
        }

        [TestMethod]
        public void InventoryEnsureICanDeleteAnInventory()
        {
            //Begin Arrange
            var data = my_inventory.AsQueryable();
            string title = "My Inventory";

            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.Expression).Returns(data.Expression);
           
            mock_Inventory.Setup(m => m.Add(It.IsAny<Inventory>())).Callback((Inventory i) => my_inventory.Add(i));
            mock_Inventory.Setup(m => m.Remove(It.IsAny<Inventory>())).Callback((Inventory i) => my_inventory.Remove(i));
            mock_context.Setup(m => m.Inventory).Returns(mock_Inventory.Object);
            //End Arrange

            //Begin Act
            var repo = new InventoryRepository();
            
            Inventory removed_Inventory = repo.CreateInventory(title, owner);
            //End Act

            //Begin Assert
            //End Assert
        }

      
    }
}
