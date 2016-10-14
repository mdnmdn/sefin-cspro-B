using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPlayground.test
{
    class Class1
    {
        public void Test() {
            var ctx = new EFPlayground.test.Entities();
            var ddd = ctx.CustOrdersOrders("");
            //ddd.FirstOrDefault().

        }
    }
}
