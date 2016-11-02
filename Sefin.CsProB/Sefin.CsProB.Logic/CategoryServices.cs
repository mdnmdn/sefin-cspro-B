using Sefin.CsProB.Logic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProB.Logic
{
    public class CategoryServices : BaseServices
    {

        public int CountCategories()
        {
            return DataContext.Categories.Count();
        }

        public List<Categories> ListCategories()
        {
            return DataContext.Categories.ToList();
        }

        public Categories GetCategory(int categoryId)
        {
            return DataContext.Categories.Find(categoryId);
        }

        
    }
}
