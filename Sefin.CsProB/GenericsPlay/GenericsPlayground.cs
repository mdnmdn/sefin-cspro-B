using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPlay
{
    [Category("test")]
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


            var valore = GetDefault<string>();

            AddCache("123", new Document());

            var doc = GetCache<Document>("123");
        }


        public T GetDefault<T>() {
            return default(T);
        }

        public void TestCache() {
            var doc = GetCache<Document>("sdfasdfa");
            
        }

        public T GetCache<T>(string key) where T:class {
            object res = null; //carico da cache...
            return res as T;
        }

        public void AddCache<T>(string key, T data) where T : class
        {
            
        }


        public T Cached<T>(string key, Func<T> loader) where T: class
        {
            var cache = System.Runtime.Caching.MemoryCache.Default;

            T result = cache[key] as T;

            if (result == null) {
                result = loader();
                //cache.Add(null,null, new System.Runtime.Caching.CacheItemPolicy { }
                cache[key] = result;
            }

            return result;
        }


        public void TestCached()
        {
            Trace.WriteLine("Before 1");
            var docs = Cached("doclist", () => LoadDocuments());

            Trace.WriteLine("After 1");

            List<Document> docs2 = Cached("doclist", () => LoadDocuments());

            Trace.WriteLine("After 2");

            DataTable data = Cached("data", () => LoadTable());

        }


        /// <summary>
        /// simula il caricamento di una lista di doc da db
        /// </summary>
        List<Document> LoadDocuments() {
            Trace.WriteLine("LoadDocuments");
            return new List<Document>() {

            };
        }

        DataTable LoadTable()
        {
            Trace.WriteLine("LoadTable");
            return new DataTable();
        }


        /// <summary>
        /// BAD!
        /// </summary>
        static public void ProcessDocument<T>(T doc) where T : Document {
            var invoice = doc as Invoice;
            if (invoice != null) {
                // TODO: cose per fatture
            }

            var bill = doc as WayBill;
            if (bill != null) {
                // TODO: cose pe bolle
            }
        }
    }

    public class Customer { }

}
