using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services.Category
{
    public interface ICategoryService
    {
        IList<Entities.Category> GetCategories(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void AddCategory(Entities.Category category);
        IList<Entities.Category> CategoryList();
        Entities.Category GetCategoryById(int id);
        void UpdateCategory(Entities.Category category);
        void DeleteCategory(Entities.Category category);
    }
}
