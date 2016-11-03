using Sefin.CsProB.Logic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProB.Logic
{
    public abstract class BaseServices
    {
        public BaseServices(NorthwindContext ctx) {
            _dataContext = ctx;
        }

        #region DataContext
        NorthwindContext _dataContext;
        protected NorthwindContext DataContext
        {
            get { return _dataContext ?? (_dataContext = new NorthwindContext()); }
        }
        #endregion

       
    }
}
