using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StructureMapWebAPIDemo.Controllers;
using StructureMapWebAPIDemo.Lib.DataModels;
using StructureMapWebAPIDemo.Lib.Interfaces;
using StructureMapWebAPIDemo.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace StructureMapWebAPIDemo.Tests.Controllers
{
    [TestClass]
    public class MoviesControllerTests
    {
        [TestMethod]
        public void Test_MovieExists_ValidID()
        {
            //Arrange
            var repository = new MovieRepository();
            var controller = new MoviesController(repository);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var movieID = 2;

            //Act
            HttpResponseMessage response = controller.GetByID(movieID);

            //Assert
            Movie movie;
            Assert.IsTrue(response.TryGetContentValue(out movie));
            Assert.AreEqual(movieID, movie.ID);
        }

        [TestMethod]
        public void Test_MovieExists_InvalidID()
        {
            //Arrange
            var repository = new MovieRepository();
            var controller = new MoviesController(repository);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var movieID = 6;

            //Act
            HttpResponseMessage response = controller.GetByID(movieID);

            //Assert
            Movie movie;
            Assert.IsFalse(response.TryGetContentValue(out movie));
        }
    }
}
