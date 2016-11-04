using Sefin.CsProB.Commons;
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
        private IAppContext _appContext;

        public ProductServices(NorthwindContext ctx, IAppContext appContext):base(ctx) {
            _appContext = appContext;
        }

        public int CountProducts()
        {            
            return DataContext.Products.Count();
        }

        public void ProcessProducts() {
            // _kernel.Get<CategoryServices>();
            //var categoryService = new CategoryServices(DataContext);
            var catSvc = _appContext.ResolveObject<CategoryServices>();
        }

    }
}
