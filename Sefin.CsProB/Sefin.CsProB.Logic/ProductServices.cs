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
        

        public int CountProducts()
        {            
            return DataContext.Products.Count();
        }

    }
}
