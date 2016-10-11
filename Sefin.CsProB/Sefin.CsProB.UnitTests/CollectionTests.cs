using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;

namespace Sefin.CsProB.UnitTests
{
    [TestClass]
    public class CollectionTests
    {
        [TestMethod]
        public void TestCollectionPerfomance()
        {
            var list = Enumerable.Range(0, 10000000).ToList();

            var dictionary = list.ToDictionary(n=>n);

            int numeroDaTrovare = list.Count - 3;

            // list
            var timeStamp = DateTime.Now;
            var val = list.FirstOrDefault(n => n == numeroDaTrovare);

            var duration = DateTime.Now.Subtract(timeStamp).TotalMilliseconds;
            Trace.WriteLine($"List by id (linq) - Value {val}  - duration {duration}ms");

            timeStamp = DateTime.Now;
            val = 0;
            foreach (var currentValue in list)
            {
                if (currentValue == numeroDaTrovare)
                {
                    val = currentValue;
                    break;
                }
            }

            duration = DateTime.Now.Subtract(timeStamp).TotalMilliseconds;
            Trace.WriteLine($"List by id (foreach) - Value {val}  - duration {duration}ms");


            timeStamp = DateTime.Now;
            val = 0;
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i] == numeroDaTrovare)
                {
                    val = list[i];
                    break;
                }
            }

            duration = DateTime.Now.Subtract(timeStamp).TotalMilliseconds;
            Trace.WriteLine($"List by id (for - count) - Value {val}  - duration {duration}ms");

            timeStamp = DateTime.Now;
            val = 0;
            int length = list.Count;
            for (int i = 0; i < length; i++)
            {
                if (list[i] == numeroDaTrovare)
                {
                    val = list[i];
                    break;
                }
            }

            duration = DateTime.Now.Subtract(timeStamp).TotalMilliseconds;
            Trace.WriteLine($"List by id (for - length var) - Value {val}  - duration {duration}ms");

            // dictionary
            timeStamp = DateTime.Now;
            val = dictionary[numeroDaTrovare];

            duration = DateTime.Now.Subtract(timeStamp).TotalMilliseconds;
            Trace.WriteLine($"Dict by id - Value {val}  - duration {duration}ms");

            // dictionary by value
            timeStamp = DateTime.Now;
            //var res = dictionary.FirstOrDefault(el => el.Value == numeroDaTrovare);
            var res = dictionary.Values.FirstOrDefault(el => el == numeroDaTrovare);

            duration = DateTime.Now.Subtract(timeStamp).TotalMilliseconds;
            Trace.WriteLine($"Dict by value - Value {val}  - duration {duration}ms");


        }
    }
}
