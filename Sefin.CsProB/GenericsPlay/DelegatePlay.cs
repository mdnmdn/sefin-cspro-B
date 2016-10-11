using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPlay
{
    public delegate void FunzioneSenzaParametri();

    public delegate int OperazioneInteri(int val1, int val2);

    [Serializable]
    public delegate T Transformazione<T>(T val);


    [Category("test")]
    public class DelegatePlay
    {
        public void Intro() {
            FunzioneSenzaParametri f;

            f = MioMetodo;

            f();
        }

        void MioMetodo()
        {
        }


        void TestOperazioniTraInteri() {
            OperazioneInteri[] ops = new OperazioneInteri[] {
                Somma,Sottrai,Moltiplica
            };

            var result = ops[1](213, 23);
        }

        int Somma(int a, int b) { return a + b; }
        int Sottrai(int a, int b) { return a - b; }
        int Moltiplica(int val1, int val2) => val1 * val2;



        void TestTransformation() {

            var transforms = new Transformazione<string>[] {
                Upper,Double,AddAt
            };

            var result = ProcessTransformations("wow!", transforms);

        }

        T ProcessTransformations<T>(T initialVal, Transformazione<T>[] ops) {
            T val = initialVal;
            foreach (var op in ops) val = op(val);
            return val;
        }

        string Upper(string txt) => txt.ToUpper();
        string Lower(string txt) => txt.ToLower();
        string Double(string txt) => txt + txt;
        string AddAt(string txt) => "@" + txt;


        void TestFakeDocumentList() {
            var docList = new DocumentList<Document>();

            var docListPerSize = docList.Sort(DocumentiPerSize);

            var docListPerDate = docList.Sort(DocumentiPerDate);
        }

        bool DocumentiPerSize(Document doc1, Document doc2) {
            return doc1.Size > doc2.Size;
        }

        bool DocumentiPerDate(Document doc1, Document doc2)
        {
            return doc1.Date > doc2.Date;
        }



        public void TestSort() {

            var docList = new List<Document> {
                new Document { Id = 12, Name ="Invoice XXXX"},
                new Document { Id = 34, Name ="Invoice XXXX"},
                new Document { Id = 1, Name ="Invoice AAAA"},
                new Document { Id = 27, Name ="Bill mmm"},
            };

            Trace.WriteLine("Original sort");
            Trace.WriteLine(String.Join(", ", docList));

            docList.Sort(OrderById);
            Trace.WriteLine("Sort by Id");
            Trace.WriteLine(String.Join(", ", docList));

            docList.Sort(OrderByName);
            Trace.WriteLine("Sort by Name");
            Trace.WriteLine(String.Join(", ", docList));

            var orderByID = true;

            Comparison<Document> comparer;

            if (orderByID) comparer = OrderById;
            else comparer = OrderByName;

            docList.Sort(comparer);

        }

        int OrderById(Document doc1, Document doc2) {
            //Trace.WriteLine($"   > doc1: {doc1}   doc2: {doc2}");

            if (doc1.Id > doc2.Id) return 1;
            return -1;
        }

        int OrderByName(Document doc1, Document doc2) {
            return doc1.Name.CompareTo(doc2.Name);
        }


        public void LambdaPlay() {

            var docList = new List<Document> {
                new Document { Id = 12, Name ="Invoice XXXX"},
                new Document { Id = 34, Name ="Invoice XXXX"},
                new Document { Id = 1, Name ="Invoice AAAA"},
                new Document { Id = 27, Name ="Bill mmm"},
            };

            Trace.WriteLine("Original sort");
            Trace.WriteLine(String.Join(", ", docList));

            // -----
            Comparison<Document> orderByNameDescending =
                    (d1, d2) => d2.Name.CompareTo(d1.Name);

            docList.Sort(orderByNameDescending);

            docList.Sort((d1, d2) => d2.Name.CompareTo(d1.Name));

            Trace.WriteLine("Sort by Name descending");
            Trace.WriteLine(String.Join(", ", docList));

            // -----------------
            Comparison<Document> orderByIdDescending =
                    (doc1, doc2) => {
                        if (doc2.Id > doc1.Id) return 1;
                        if (doc2.Id == doc1.Id) return 0;
                        return -1;
                    };

            docList.Sort(orderByIdDescending);
            Trace.WriteLine("Sort by Id descending");
            Trace.WriteLine(String.Join(", ", docList));


            // Extension methods
            int num = 33.Double().Double().Double().Double();

            num = NumberExtender.Double(33);
        }

        public void LambdaPlay2() {

            Func<Document, Document, int> comparerLike =
                (a, b) => 23;

            Action action = () => Trace.WriteLine("I'm an action!");

            Action<string> stampaStringa =
                    txt => Trace.WriteLine("print: " + txt);

        }

        public void ClosurePlay() {

            int val = 5;

            Action process = () => Trace.WriteLine("val: " + val);

            process();

            Action[] actions = new Action[10];

            for (val = 0; val < 10; val++) {
                actions[val] = process;
            }

            foreach (var action in actions) {
                action();
            }
        }

        public void ClosurePlay2()
        {

            Action[] actions = new Action[10];

            for (var i = 0; i < 10; i++)
            {
                var val = i;
                actions[val] = () => Trace.WriteLine("val: " + val);
            }

            foreach (var action in actions)
            {
                action();
            }
        }

        public void ClosurePlayMultiThread()
        {
            //var val = 0;
            for (var i = 0; i < 10; i++)
            {
                var val = i;
                System.Threading.ThreadPool.QueueUserWorkItem(
                    _ => Trace.WriteLine("val: " + val)
                    );
            }

            
        }
    }

    public static class NumberExtender {

        public static int Double(this int number) {
            return number * 2;
        }
    }

    
}
