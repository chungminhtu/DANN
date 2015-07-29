using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DANN.Model;
using DANN.Service;
using System.Web.Mvc;
using DANN.Web.Controllers;


namespace DANN.Test.Controllers
{
    [TestClass]
    public class DM_CodeControllerTest
    {
        private Mock<IDM_CodeService> _dmCodeServiceMock;
        DMCodeController objController;
        List<DM_Code> listDM_Code;

        [TestInitialize]
        public void Initialize()
        {

            _dmCodeServiceMock = new Mock<IDM_CodeService>();
            objController = new DMCodeController(_dmCodeServiceMock.Object, _dmCodeServiceMock.Object, _dmCodeServiceMock.Object);
            listDM_Code = new List<DM_Code>() {
           new DM_Code() { Id = 1, Name = "US" },
           new DM_Code() { Id = 2, Name = "India" },
           new DM_Code() { Id = 3, Name = "Russia" }
          };
        }



        [TestMethod]
        public void DM_Code_Get_All()
        {
            //Arrange
            _dmCodeServiceMock.Setup(x => x.GetAll()).Returns(listDM_Code);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<DM_Code>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);

        }

        [TestMethod]
        public void Valid_DM_Code_Create()
        {
            //Arrange
            DM_Code c = new DM_Code() { Name = "test1" };

            //Act
            var result = (RedirectToRouteResult)objController.Create(c);

            //Assert
            _dmCodeServiceMock.Verify(m => m.Create(c), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void Invalid_DM_Code_Create()
        {
            // Arrange
            DM_Code c = new DM_Code() { Name = "" };
            objController.ModelState.AddModelError("Error", "Something went wrong");

            //Act
            var result = (ViewResult)objController.Create(c);

            //Assert
            _dmCodeServiceMock.Verify(m => m.Create(c), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }

    }
}
