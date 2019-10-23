using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OneToOneSameTable
{
    public class CategoryRepositoryTests
    {
        [Fact]
        public void Add_WhenHaveNoParent()
        {
            ICategoryRepository repository = GetInMemoryCategoryRepository();
            Category category = new Category
            {
                CategoryId = 1,
                Name = "Category 1"
            };

           repository.Add(category);

            ICollection<Category> items = repository.GetAll();

            Assert.Equal(1, items.Count);
            Category item = items.First();
            Assert.Equal(1, item.CategoryId);
            Assert.Equal("Category 1", item.Name);
            Assert.Null(item.ParentId);
            Assert.Null(item.Parent);
        }

        [Fact]
        public void Add_WhenHaveParent()
        {
            ICategoryRepository repository = GetInMemoryCategoryRepository();
            Category category = new Category
            {
                CategoryId = 1,
                Name = "Category 1"
            };

            repository.Add(category);

            category = new Category
            {
                CategoryId = 2,
                Name = "Category 2",
                ParentId = 1
            };
            repository.Add(category);


            ICollection<Category> items = repository.GetAll();

            Assert.Equal(2, items.Count);

            Category itemParent = items.First();
            Assert.Equal(1, itemParent.CategoryId);
            Assert.Equal("Category 1", itemParent.Name);
            Assert.Null(itemParent.ParentId);
            Assert.Null(itemParent.Parent);

            Category itemChild = items.Last();
            Assert.Equal(2, itemChild.CategoryId);
            Assert.Equal("Category 2", itemChild.Name);
            Assert.Equal(1, itemChild.ParentId);
            Assert.Equal("Category 1", itemChild.Parent.Name);
        }


        private ICategoryRepository GetInMemoryCategoryRepository()
        {
            DbContextOptions<AppContext> options;
            DbContextOptionsBuilder<AppContext> builder = new DbContextOptionsBuilder<AppContext>();
            builder.UseInMemoryDatabase();
            options = builder.Options;
            AppContext context = new AppContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return new CategoryRepository(context);
        }
    }
}
