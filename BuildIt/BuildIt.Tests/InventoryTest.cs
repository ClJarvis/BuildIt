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
        public ApplicationUser owner, user1;
        private List<Project> my_project;
        private Mock<IDbSet<Project>> mock_Project;


        private void ConnectsMocksToDataSource()
        {
            var data = my_inventory.AsQueryable();

            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_context.Setup(m => m.Inventories).Returns(mock_Inventory.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<InventoryContext>();
            mock_Inventory = new Mock<IDbSet<Inventory>>();
            mock_Project = new Mock<IDbSet<Project>>();
            my_inventory = new List<Inventory>();
            my_project = new List<Project>();
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
            mock_context.Setup(m => m.Inventories).Returns(mock_Inventory.Object);

            InventoryRepository repo = new InventoryRepository(mock_context.Object);
            //End Arrange

            //Begin Act
           // var repo = new InventoryRepository();
            
            Inventory removed_Inventory = repo.CreateInventory(title, owner);
            //End Act

            //Begin Assert
            Assert.IsNotNull(removed_Inventory);
            mock_Inventory.Verify(m => m.Add(It.IsAny<Inventory>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Once());
            Assert.AreEqual(1, repo.GetInventoryCount());
            repo.DeleteInventory(removed_Inventory);
            mock_Inventory.Verify(x => x.Remove(It.IsAny<Inventory>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Exactly(2));
            Assert.AreEqual(0, repo.GetInventoryCount());

            //End Assert
        }

        [TestMethod]
        public void EnsureICanDeleteAProjectFromAnInventory()
        {
            //Begin Arrange
            var data = my_project.AsQueryable();
            string ProjectName = "My Inventory";
            
           // InventoryRepository repo = new InventoryRepository(mock_context.Object);
            Project project = new Project { ProjectName = "ToDo", ProjectId = 1 };
            my_project.Remove(new Project { ProjectName = "My Current Project", Owner = user1});

            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_Inventory.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.Expression).Returns(data.Expression);


            mock_Inventory.Setup(m => m.Add(It.IsAny<Inventory>())).Callback((Inventory p) => my_inventory.Add(p));
            mock_Inventory.Setup(m => m.Remove(It.IsAny<Inventory> ())).Callback((Inventory p) => my_inventory.Remove(p));
            mock_context.Setup(m => m.Inventories).Returns(mock_Inventory.Object);

            InventoryRepository repo = new InventoryRepository(mock_context.Object);
            //End Arrange

            //Begin Act

            Project removed_project = repo.CreateProject("My Material Inventory", owner);

            //End Act
            //Begin Assert
            Assert.IsNotNull(removed_project);
            mock_Project.Verify(m => m.Add(It.IsAny<Project>()));   /////////////////////
            mock_context.Verify(x => x.SaveChanges(), Times.Once());
            Assert.AreEqual(0, repo.GetProjectCount());
            repo.DeleteProject(removed_project);
            mock_Inventory.Verify(x => x.Remove(It.IsAny<Inventory>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Exactly(2));
            Assert.AreEqual(0, repo.GetProjectCount());
            //End Assert    
        }

        [TestMethod]
        public void ListEnsureICanEditAProject()
        {
            //Begin Arrange
            var data = my_project.AsQueryable();
            InventoryRepository repo = new InventoryRepository(mock_context.Object);
            Project list = new Project { ProjectName = "ToDo", ProjectId = 1 };
            my_project.Remove(new Project { ProjectName = "My First Project", Owner = user1, ProjectId = 1 });

            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_Inventory.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_Inventory.As<IQueryable<Inventory>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_Inventory.Setup(m => m.Add(It.IsAny<Inventory>())).Callback((Inventory p) => my_inventory.Add(p));
            mock_Inventory.Setup(m => m.Remove(It.IsAny<Inventory>())).Callback((Inventory p) => my_inventory.Remove(p));
            mock_context.Setup(m => m.Inventories).Returns(mock_Inventory.Object);
            //End Arrange

            //Begin Act

            Inventory removed_project = repo.CreateInventory("My Inventory", owner);

            Project Updatedproject = new Project { ProjectName = "ToDo", ProjectId = 1 };
            my_project.Add(new Project { ProjectName = "My Next Board", Owner = user1, ProjectId = 1 });
            //End Act

            //Begin Assert
            Assert.IsNotNull(removed_project);
            mock_Inventory.Verify(m => m.Add(It.IsAny<Inventory>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Once());
            Assert.AreEqual(0, repo.GetInventoryCount());
            
            mock_Inventory.Verify(x => x.Remove(It.IsAny<Inventory>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Exactly(2));
            Assert.AreEqual(0, repo.GetInventoryCount());
            string expected = my_project.ToString();
            string actual = "my new project";
          
            Assert.AreEqual(expected, actual);
            //End Assert
        }

      
    }
}
