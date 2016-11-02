using Sefin.CsProB.Logic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProB.Logic
{
    public abstract class BaseServices:IDisposable
    {
        #region DataContext
        NorthwindContext _dataContext;
        protected NorthwindContext DataContext
        {
            get { return _dataContext ?? (_dataContext = new NorthwindContext()); }
        }
        #endregion

        #region IDisposable
        public virtual void Dispose()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }
        }
        #endregion
    }
}
