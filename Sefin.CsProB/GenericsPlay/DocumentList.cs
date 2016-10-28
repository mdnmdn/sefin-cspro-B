using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPlay
{

    public class DocumentList<T> where T: Document
    {

        Dictionary<int, T> _storage = new Dictionary<int, T>();

        public void Add(T doc) {
            _storage[doc.Id] = doc;
        }

        public T Get(int id)
        {
            //return (T)_storage[id];
            //return _storage[id] as T;
            return _storage[id];
        }

        public List<T> Sort(Predicate<T> predicate) {

            var results = new List<T>();

            // FINTO ORDINAMENTO
            T maxDoc = null;
            foreach (var doc in this._storage.Values) {
                if (predicate(maxDoc, doc)) {
                    maxDoc = doc;
                }
            }

            return results;
        }

        //public void Process(int id) {
        //    var doc = _storage[id];
        //    GenericsPlayground.ProcessDocument(doc);
        //}
    }

    public delegate bool Predicate<T>(T doc1, T doc2);

    public class ExtendedDocumentList<T,K> : DocumentList<T> where T:Document {

    }

    
    public class InvoceList : DocumentList<Invoice> {

    }
    
}
