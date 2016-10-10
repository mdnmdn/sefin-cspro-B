using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPlay
{
    public class Document
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }

    public class Invoice : Document {
        public int Number { get; set; }
        public int Year { get; set; }
    }

    public class WayBill : Document {
       public string BillCode { get; set; }
    }

    public class InternationInvoice : Invoice {
    }
}
