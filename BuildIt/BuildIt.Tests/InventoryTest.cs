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
        private Mock<IDbSet<Inventory>> mock_Inventories;
        private List<Inventory> my_inventories;
        public ApplicationUser owner, user1;
        private List<Project> my_projects;
        private Mock<IDbSet<Project>> mock_Projects;


        private void ConnectsMocksToDataSource()
        {
            var data = my_inventories.AsQueryable();

            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_context.Setup(m => m.Inventories).Returns(mock_Inventories.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<InventoryContext>();
            mock_Inventories = new Mock<IDbSet<Inventory>>();
            mock_Projects = new Mock<IDbSet<Project>>();
            my_inventories = new List<Inventory>();
            my_projects = new List<Project>();
            owner = new ApplicationUser();
            user1 = new ApplicationUser();
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_Inventories = null;
            my_inventories = null;
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
            var data = my_inventories.AsQueryable();
            string title = "My Inventory";

            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.Expression).Returns(data.Expression);
           
            mock_Inventories.Setup(m => m.Add(It.IsAny<Inventory>())).Callback((Inventory i) => my_inventories.Add(i));
            mock_Inventories.Setup(m => m.Remove(It.IsAny<Inventory>())).Callback((Inventory i) => my_inventories.Remove(i));
            mock_context.Setup(m => m.Inventories).Returns(mock_Inventories.Object);

            InventoryRepository repo = new InventoryRepository(mock_context.Object);
            //End Arrange

            //Begin Act
           // var repo = new InventoryRepository();
            
            Inventory removed_Inventory = repo.CreateInventory(title, owner);
            //End Act

            //Begin Assert
            Assert.IsNotNull(removed_Inventory);
            mock_Inventories.Verify(m => m.Add(It.IsAny<Inventory>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Once());
            Assert.AreEqual(1, repo.GetInventoryCount());
            repo.DeleteInventory(removed_Inventory);
            mock_Inventories.Verify(x => x.Remove(It.IsAny<Inventory>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Exactly(2));
            Assert.AreEqual(0, repo.GetInventoryCount());

            //End Assert
        }

        [TestMethod]
        public void EnsureICanDeleteAProjectFromAnInventory()
        {
            //Begin Arrange
            var data = my_projects.AsQueryable();
            string ProjectName = "My Inventory";
            
           // InventoryRepository repo = new InventoryRepository(mock_context.Object);
            Project project = new Project { ProjectName = "ToDo", ProjectId = 1 };
            my_projects.Remove(new Project { ProjectName = "My Current Project", Owner = user1});

            mock_Projects.As<IQueryable<Project>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_Projects.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_Projects.As<IQueryable<Project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_Projects.As<IQueryable<Project>>().Setup(m => m.Expression).Returns(data.Expression);


            mock_Projects.Setup(m => m.Add(It.IsAny<Project>())).Callback((Project p) => my_projects.Add(p));
            mock_Projects.Setup(m => m.Remove(It.IsAny<Project> ())).Callback((Project p) => my_projects.Remove(p));
            mock_context.Setup(m => m.Projects).Returns(mock_Projects.Object);

            InventoryRepository repo = new InventoryRepository(mock_context.Object);
            //End Arrange

            //Begin Act

            Project removed_project = repo.CreateProject("My Material Inventory", owner);
           // Project mock_project = new Project();
            //End Act
            //Begin Assert
            Assert.IsNotNull(removed_project);
            mock_Projects.Verify(m => m.Add(It.IsAny<Project>()));   /////////////////////
            mock_context.Verify(x => x.SaveChanges(), Times.AtLeastOnce());
            Assert.AreEqual(1, repo.GetProjectCount());
            repo.DeleteProject(removed_project);
            mock_Inventories.Verify(x => x.Remove(It.IsAny<Inventory>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Exactly(2));
            Assert.AreEqual(0, repo.GetProjectCount());
            //End Assert    
        }

        [TestMethod]
        public void ListEnsureICanEditAProject()
        {
            //Begin Arrange
            var data = my_projects.AsQueryable();
            InventoryRepository repo = new InventoryRepository(mock_context.Object);
            Project list = new Project { ProjectName = "ToDo", ProjectId = 1 };
            my_projects.Remove(new Project { ProjectName = "My First Project", Owner = user1, ProjectId = 1 });

            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.Provider).Returns(data.Provider);
            mock_Inventories.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_Inventories.As<IQueryable<Inventory>>().Setup(m => m.Expression).Returns(data.Expression);

            mock_Inventories.Setup(m => m.Add(It.IsAny<Inventory>())).Callback((Inventory p) => my_inventories.Add(p));
            mock_Inventories.Setup(m => m.Remove(It.IsAny<Inventory>())).Callback((Inventory p) => my_inventories.Remove(p));
            mock_context.Setup(m => m.Inventories).Returns(mock_Inventories.Object);
            //End Arrange

            //Begin Act

            Inventory removed_project = repo.CreateInventory("My Inventory", owner);

            Project Updatedproject = new Project { ProjectName = "ToDo", ProjectId = 1 };
            my_projects.Add(new Project { ProjectName = "My Next Board", Owner = user1, ProjectId = 1 });
            //End Act

            //Begin Assert
            Assert.IsNotNull(removed_project);
            mock_Inventories.Verify(m => m.Add(It.IsAny<Inventory>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Once());
            Assert.AreEqual(0, repo.GetInventoryCount());
            
            mock_Inventories.Verify(x => x.Remove(It.IsAny<Inventory>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Exactly(2));
            Assert.AreEqual(0, repo.GetInventoryCount());
            string expected = my_projects.ToString();
            string actual = "my new project";
          
            Assert.AreEqual(expected, actual);
            //End Assert
        }

      
    }
}
