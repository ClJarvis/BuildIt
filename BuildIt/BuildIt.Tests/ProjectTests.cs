using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildIt.Models;


namespace BuildIt.Tests
{
    [TestClass]
    public class ProjectTests
    {
        /// <summary>
        ///////////////////////Inventory Tests //////////////////////////////////
        /// </summary>
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


        /// <summary>
        /// //////////////////Project Tests ////////////////////////////////////////
        /// </summary>
        [TestMethod]
        public void EnsureICanCreatAnInstanceAProject()
        {
            Project project = new Project();
            Assert.IsNotNull(project);
        }


        [TestMethod]
        public void EnsureProjectPropertiesWork()
        {
            //Begin Arrange
            Project project = new Project { Name = "My First Project", ProjectId = 001 };
            
            //End Arrange

            //Begin Act
            //End Act

            //Begin Assert
            Assert.AreEqual("My First Project", project.Name);
            Assert.AreEqual(001, project.ProjectId);

            //End Assert
        }
    }
}
