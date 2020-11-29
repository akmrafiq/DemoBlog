using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Repositories.Category;

namespace Blog.Core.Services.Category
{
    public class CategoryService:ICategoryService
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();
        public void AddCategory(Entities.Category category)
        {
            var count = _categoryRepository.GetCount(x => x.Name == category.Name);

            if (count > 0)
            {
                throw new InvalidOperationException("Category Already Exists");
            }
            _categoryRepository.Insert(category);
        }

        public IList<Entities.Category> CategoryList()
        {
            return _categoryRepository.GetList(c => c.IsActive == true && c.IsDeleted == false);
        }

        public Entities.Category GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void UpdateCategory(Entities.Category category)
        {
            var count = _categoryRepository.GetCount(c => c.Name == category.Name && c.Id != category.Id);

            if (count > 0)
            {
                throw new InvalidOperationException("Category Already Exists");
            }
            _categoryRepository.Update(category);
        }

        public void DeleteCategory(Entities.Category category)
        {
            category.IsActive = false;
            category.IsDeleted = true;
            category.UpdateDate = DateTime.UtcNow;

            _categoryRepository.Update(category);
        }

        public IList<Entities.Category> GetCategories(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            Expression<Func<Entities.Category, bool>> filter = null;
            filter = x => x.IsActive == true && x.IsDeleted == false && x.Name.Contains(searchText);
            return _categoryRepository.Get(
                out total,
                out totalFiltered,
                filter,
                x => x.OrderByDescending(b => b.Id),
                null,
                null,
                pageIndex,
                pageSize);
        }
    }
}
