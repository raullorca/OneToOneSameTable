using System.Collections.Generic;
using System.Linq;

namespace OneToOneSameTable
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppContext context;

        public CategoryRepository(AppContext context)
        {
            this.context = context;
        }

        public Category Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }

        public ICollection<Category> GetAll()
        {
            return context.Categories.ToList();
        }
    }
}
