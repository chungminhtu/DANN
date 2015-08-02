using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DANN.Model;
using DANN.Service;
using System.Reflection;

namespace DANN.Test.Services
{

    [TestClass]
    public class GenericServiceTest<T> where T : BaseEntity, new()
    {
        public IEntityService<T> _service { get; set; }
        public Mock<IContext> _mockContext { get; set; }
        public Mock<DbSet<T>> _mockSet { get; set; }
        public IQueryable<T> ListObjectTest { get; set; }

        public int numberRecordTest { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            var ListObjectTemp = new List<T>();

            for (int i = 1; i <= numberRecordTest; i++)
            {
                var item = new T();
                foreach (PropertyInfo pInfo in typeof(T).GetProperties())
                {
                    if (pInfo.PropertyType == typeof(int))
                    {
                        CommonFunctions.TrySetProperty(item, pInfo.Name, i);
                    }
                    if (pInfo.PropertyType == typeof(DateTime))
                    {
                        CommonFunctions.TrySetProperty(item, pInfo.Name, DateTime.Now);
                    }
                    if (pInfo.PropertyType == typeof(string))
                    {
                        CommonFunctions.TrySetProperty(item, pInfo.Name, "Test" + i);
                    }
                    if (pInfo.PropertyType == typeof(bool))
                    {
                        CommonFunctions.TrySetProperty(item, pInfo.Name, false);
                    }
                }
                ListObjectTemp.Add(item);
            }

            ListObjectTest = ListObjectTemp.AsQueryable();

            _mockSet = new Mock<DbSet<T>>();
            _mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(ListObjectTest.Provider);
            _mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(ListObjectTest.Expression);
            _mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(ListObjectTest.ElementType);
            _mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(ListObjectTest.GetEnumerator());

            _mockContext = new Mock<IContext>();
            _mockContext.Setup(c => c.Set<T>()).Returns(_mockSet.Object);
        }

        public void Get_AllTest()
        {
            //Act
            List<T> results = _service.GetAll();

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(numberRecordTest, results.Count);
        }


        public void MaxTest()
        {
            //Act 
            int max = _service.MaxId();
            //Assert 
            Assert.AreEqual(numberRecordTest, max);
        }

        public void GetByIDTest()
        {
            //Act 
            T max = _service.GetById(numberRecordTest);
            //Assert 
            Assert.AreEqual(numberRecordTest, max.CodeKind_Id);
        }

        public void AddTest()
        {
            //Arrange
            int Id = 1;
            T codeKind = new T() { CodeKindName = "UK" };

            _mockSet.Setup(m => m.Add(codeKind)).Returns((T e) =>
            {
                e.CodeKind_Id = Id;
                return e;
            });


            //Act
            _service.Create(codeKind);

            //Assert
            Assert.AreEqual(Id, codeKind.CodeKind_Id);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        public void DeleteTest()
        {
            //Arrange
            _service.Delete(new T() { CodeKind_Id = 1, CodeKindName = "UK" });

            //Assert
            Assert.AreEqual(null, _service.GetById(1));
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
