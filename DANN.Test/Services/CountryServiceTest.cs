using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DANN.Model;
using DANN.Service;

namespace DANN.Test.Services
{

    [TestClass]
    public class DM_CodeKindServiceTest
    {
        private IEntityService<DM_CodeKind> _service;
        Mock<IContext> _mockContext;
        Mock<DbSet<DM_CodeKind>> _mockSet;
        IQueryable<DM_CodeKind> listDM_CodeKind;

        [TestInitialize]
        public void Initialize()
        {
            var temp = new List<DM_CodeKind>();

            for (int i = 1; i <= 99100; i++)
            {
                temp.Add(new DM_CodeKind() { CodeKind_Id = i, CodeKindName = "SomeThing" });
            }

            listDM_CodeKind = temp.AsQueryable();

            _mockSet = new Mock<DbSet<DM_CodeKind>>();
            _mockSet.As<IQueryable<DM_CodeKind>>().Setup(m => m.Provider).Returns(listDM_CodeKind.Provider);
            _mockSet.As<IQueryable<DM_CodeKind>>().Setup(m => m.Expression).Returns(listDM_CodeKind.Expression);
            _mockSet.As<IQueryable<DM_CodeKind>>().Setup(m => m.ElementType).Returns(listDM_CodeKind.ElementType);
            _mockSet.As<IQueryable<DM_CodeKind>>().Setup(m => m.GetEnumerator()).Returns(listDM_CodeKind.GetEnumerator());

            _mockContext = new Mock<IContext>();
            _mockContext.Setup(c => c.Set<DM_CodeKind>()).Returns(_mockSet.Object);
            //_mockContext.Setup(c => c.Countries).Returns(_mockSet.Object);

            _service = new DM_CodeKindService(_mockContext.Object);

        }

        [TestMethod]
        public void DM_CodeKind_Get_All()
        {
            //Act
            List<DM_CodeKind> results = _service.GetAll();

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(99100, results.Count);
        }


        [TestMethod]
        public void DM_CodeKind_Max()
        {
            //Act 
            int max = _service.MaxId();
            //Assert 
            Assert.AreEqual(99100, max);
        }

        [TestMethod]
        public void DM_CodeKind_GetByID()
        {
            //Act 
            DM_CodeKind max = _service.GetById(99100);
            //Assert 
            Assert.AreEqual(99100, max.CodeKind_Id);
        }


        [TestMethod]
        public void Can_Add_DM_CodeKind()
        {
            //Arrange
            int Id = 1;
            DM_CodeKind codeKind = new DM_CodeKind() { CodeKindName = "UK" };

            //_mockSet.Setup(m => m.Add(codeKind)).Returns((DM_CodeKind e) =>
            //{
            //    e.CodeKind_Id = Id;
            //    return e;
            //});


            //Act
            _service.Create(codeKind);

            //Assert
            Assert.AreEqual(_service.MaxId() + 1, codeKind.CodeKind_Id);
            // _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Can_Delete_DM_CodeKind()
        {
            _service = new DM_CodeKindService(_mockContext.Object);
            //Arrange
            _service.Delete(new DM_CodeKind() { CodeKind_Id = 1, CodeKindName = "UK" });

            //Assert
            Assert.IsNull(_service.GetById(1));
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
