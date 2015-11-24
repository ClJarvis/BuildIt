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
            Project project = new Project { Name = "My First Project" };


            Assert.AreEqual("My First Project", project.Name);

        }
    }
}
