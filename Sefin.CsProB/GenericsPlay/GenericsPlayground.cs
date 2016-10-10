using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPlay
{
    public class GenericsPlayground
    {
        public void Intro() {
            List<Customer> customerList = new List<Customer>();
            customerList.Add(new Customer());

            var cust = customerList[0];

            // arraylist

            ArrayList arrayList = new ArrayList();
            arrayList.Add(new Customer());
            arrayList.Add(new Document());
            arrayList.Add(123);

            Document val = (Document)arrayList[1];

            // hastable
            Hashtable hashtable = new Hashtable();

            // dictionary
            

        }

        public void CollectionPerfomance() {

            var docs = new Document[] {
                new Document {Id = 1 },
                new Document {Id = 2 },
                new Document {Id = 3 },
                new Document {Id = 4 },
                new Document {Id = 5 },
            };

            var list = new List<Document>();
            list.AddRange(docs);

            var dictionary = new Dictionary<int, Document>();
            foreach (var doc in docs)
                dictionary.Add(doc.Id, doc);

            // per posizione
            var doc1 = list[0];

            // per id
            var doc2 = list.FirstOrDefault(d => d.Id == 4);
            //list.fin

            var doc2Dict = dictionary[4];

            // Hashset
            var set = new HashSet<string>();
            set.Add("sdfsadf");
            set.Add("asdfasd");
            set.Add("pppp");

            set.Contains("pppp");

        }

        public void CustomListPlay() {

            var cl = new CustomList<Document>();
            cl.Add(new Document());
            Document doc = cl.Get(2);

            //var clNum = new CustomList<int>();
            var clString = new CustomList<string>();
            //new CustomList<int?>();

        }

        public void DocumentList() {

            var invoiceList = new DocumentList<Invoice>();
            invoiceList.Add(new Invoice());

            //invoiceList.Add(new Document());

            var docList = new DocumentList<Document>();
            docList.Add(new Document());
            docList.Add(new Invoice());
        }
    }

    public class Customer { }
    

}
