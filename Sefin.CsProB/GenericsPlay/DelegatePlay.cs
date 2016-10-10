using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPlay
{
    public delegate void FunzioneSenzaParametri();

    public delegate int OperazioneInteri(int val1, int val2);

    public delegate T Transformazione<T>(T val);

    

    public class DelegatePlay
    {
        void Intro() {
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
    }

    
}
