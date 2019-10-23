using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneToOneSameTable
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual Category Parent { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        public virtual Collection<Category> Children { get; set; }

    }
}
