using Ninject;
using Sefin.CsProB.Logic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProB.Logic
{
    public class ProductServices : BaseServices
    {
        private IKernel _kernel;

        public ProductServices(NorthwindContext ctx, IKernel kernel):base(ctx) {
            _kernel = kernel;
        }

        public int CountProducts()
        {            
            return DataContext.Products.Count();
        }

        public void ProcessProducts() {
            _kernel.Get<CategoryServices>();
            var categoryService = new CategoryServices(DataContext);
        }

    }
}
