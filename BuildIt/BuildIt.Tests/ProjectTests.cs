using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildIt.Models;

namespace BuildIt.Tests
{
    [TestClass]
    public class ProjectTests
    {
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
            Project project = new Project { Name = "My First Project" };
            //End Arrange

            //Begin Act
            //End Act

            //Begin Assert
            Assert.AreEqual("My First Project", project.Name);

            //End Assert
        }
    }
}
