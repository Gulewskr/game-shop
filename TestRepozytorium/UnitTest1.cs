using gameshop.Core.Domain;
using gameshop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepozytorium
{
    [TestClass]
    public class UnitTest1
    {
        protected CategoryRepository _CategoryRepository;

        [TestMethod]
        [Description("Check if Browse all return list")]
        [Owner("Rafa³")]
        [Priority(3)]
        [TestCategory("Read")]
        public async Task BrowseAll_should_return_listd()
        {
            //var cdbs = new Mock<DbSet<Category>>();
            var _categoriesMock = new List<Category>
            {
                new Category(){ Id = 1, Name = "Logic" },
                new Category(){ Id = 2, Name = "Sport" },
                new Category(){ Id = 3, Name = "Racing" },
                new Category(){ Id = 4, Name = "Action" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(_categoriesMock.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(_categoriesMock.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(_categoriesMock.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(_categoriesMock.GetEnumerator());

            var appDbContextMock = new Mock<AppDbContext>();
            appDbContextMock.Setup(c => c.Categories).Returns(mockSet.Object);

            var categoriesRepo = new CategoryRepository(appDbContextMock.Object);
            var categories = await categoriesRepo.BrowseAllAsync();

            Assert.AreEqual(4, categories.Count());
        }
    }
}
