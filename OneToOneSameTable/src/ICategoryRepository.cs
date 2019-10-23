using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OneToOneSameTable
{

    public interface ICategoryRepository
    {
        ICollection<Category> GetAll();
        Category Add(Category category);
    }
}
