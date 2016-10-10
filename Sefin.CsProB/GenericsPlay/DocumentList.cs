using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPlay
{
    public class DocumentList<T> where T: Document
    {
        public void Add(T doc) {
            
        }
    }
}
