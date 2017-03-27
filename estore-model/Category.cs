using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace estore_model
{
    [Table("Category")]
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
        public int SortOrder { get; set; }
    }
}
