using Sefin.CsProB.Logic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProB.Logic
{
    public class CategoryServices
    {
        public int CountCategories() {
            using (var ctx = new NorthwindContext()) {
                return ctx.Categories.Count();
            }
        }
    }
}
