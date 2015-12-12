using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildIt.Models;
using System.Collections.Generic;
using BuildIt.DAL;


namespace BuildIt.Tests
{
    [TestClass]
    public class ProjectTests
    {
       
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
     //       Project project = new Project { Name = "My First Project", ProjectId = 001};

            //End Arrange

            //Begin Act
          
            //End Act

            //Begin Assert
   //         Assert.AreEqual("My First Project", project.Name);
   //         Assert.AreEqual(001, project.ProjectId);

            //End Assert
        }
    }
}
