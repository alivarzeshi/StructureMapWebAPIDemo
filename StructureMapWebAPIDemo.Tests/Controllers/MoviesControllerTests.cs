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
using System.Web.Http.Results;

namespace StructureMapWebAPIDemo.Tests.Controllers
{
    [TestClass]
    public class MoviesControllerTests
    {
        [TestMethod]
        public void Test_GetByID_ValidID()
        {
            //Arrange
            var mockMovieRepo = new Mock<IMovieRepository>();
            var movieID = 2;
            mockMovieRepo.Setup(x => x.GetByID(movieID)).Returns(new Movie() { ID = 2 });
            var controller = new MoviesController(mockMovieRepo.Object);

            //Act
            IHttpActionResult response = controller.GetByID(movieID);
            var contentResult = response as OkNegotiatedContentResult<Movie>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(movieID, contentResult.Content.ID);
        }

        [TestMethod]
        public void Test_GetByID_InvalidID()
        {
            //Arrange
            var mockMovieRepo = new Mock<IMovieRepository>();
            var movieID = 6;
            mockMovieRepo.Setup(x => x.GetByID(movieID)).Returns((Movie)null);
            var controller = new MoviesController(mockMovieRepo.Object);


            //Act
            IHttpActionResult response = controller.GetByID(movieID);
            var contentResult = response as NotFoundResult;

            //Assert
            Assert.IsNotNull(contentResult);
        }
    }
}
