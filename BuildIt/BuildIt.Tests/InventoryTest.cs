﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private Mock<InventoryContext> mock_content;
        private Mock<IDbSet<Inventory>> mock_Inventory;
        private List<Inventory> my_inventory;
        

        private void ConnectsMocksToDataSource()
        {
            var data = my_inventory.AsQueryable();

          //  mock_Inventory.As<IQueryable<Inventory>().Setup(m => mock_Inventory.Provider).Returns(data.Provider);
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
            ///create a Mock Inventory then delete it
        }

      
    }
}
