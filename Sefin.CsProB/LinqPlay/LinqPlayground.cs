using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlay
{
    [Category("test")]
    public class LinqPlayground
    {
        public void Intro()
        {

            var strings = new string[] {
                "uno","due","tre","quattro","cinque"
            };

            strings.WriteLog();


            var res1 = strings.Select(s => s);
            res1.WriteLog();

            var res2 = strings.Select(s => s.Length);
            res2.WriteLog();

            var res3 = strings.Select(s => s.ToUpper());
            res3.WriteLog();

            var numbers = new int[] {
                4,7,23,14,11,1,2
            };

            numbers.WriteLog();

            var res4 = numbers.Select(i => i * 2);
            res4.WriteLog();

            var res5 = numbers.Select(i => new DateTime(2016, 10, i));
            res5.WriteLog();

            var res6 = numbers.Select(i => new DateTime(2016, 10, i))
                              .Select(d => d.ToString("yyyy-MM-dd"));
            res6.WriteLog();

            var res7 = numbers
                .Select(i => new DateTime(2016, 10, i).ToString("yyyy-MM-dd"));

            // ----- WHERE  -----

            var res8 = strings.Where(s => s.Length > 3);
            res8.WriteLog();

            var res9 = strings.Where(s => s.Length > 3)
                              .Select(s => s.ToUpper())
                              .Select(s => "@" + s);
            res9.WriteLog();

            var res10 = strings.Select(s => s.ToUpper())
                               .Where(s => s.Length > 3)
                               .Select(s => "@" + s);
            res10.WriteLog();

            var res11 = strings.Where(s => s.Contains("e"))
                               .Select(s => s.ToUpper())
                               .Where(s => s.Length <= 3)
                               .Select(s => "@" + s);
            res11.WriteLog();

            Trace.WriteLine("---------");
            var res12 = strings.Select(s => s.Log("toupper").ToUpper())
                               .Where(s => s.Log("where1").Length <= 3)
                               .Select(s => "@" + s.Log("@@"))
                               .Where(s => s.Log("where2").Contains("E"));

            Trace.WriteLine(" dopo query");
            res12.WriteLog();
            res12.WriteLog();
            res12.WriteLog();
            res12.WriteLog();

            var res13 = res12.Select(s => s.Substring(0, 2));
            res13.WriteLog();

            IEnumerable<string> res14 = strings.Select(s => s.Log("toupper").ToUpper())
                               .Where(s => s.Log("where1").Length <= 3)
                               .Select(s => "@" + s.Log("@@"))
                               .Where(s => s.Log("where2").Contains("E"))
                               .OrderBy(s => s.Length)
                               .ToList();

            res14.WriteLog();
            res14.WriteLog();
            res14.WriteLog();

        }

        public void LinqSyntax()
        {
            var strings = new string[] {
                "uno","due","tre","quattro","cinque"
            };

            // SELECT ...  FROM strings as s
            var res1 = from s in strings
                       where s.Contains("e") && s.Length <= 3
                       select s.ToUpper();

            res1.WriteLog();

            var res2 = (from s in strings
                        where s.Contains("e")
                        orderby s.Length descending
                        select s.ToUpper());

            res2.WriteLog();

            var res3 = from t in (from s in strings
                                  where s.Contains("e")
                                  orderby s.Length descending
                                  select s.ToUpper())
                       where !t.Contains("z")
                       select t.Substring(0, 4);

            var res4 = from s in strings.Where(s => s.Contains("e"))
                       orderby s.Length
                       select s;


        }

        public void Anonymous()
        {
            var strings = new string[] {
                "uno","due","tre","quattro","cinque"
            };


            var res = strings.Select(s => 
                            new {
                                Val = s,
                                s.Length,
                                StringUpper = s.ToUpper()
                            });

            res.WriteLog();

            //var list = res.ToList();
            //list.WriteLog();
            //var first = list[0];

            var res1 = strings.Select(s => new
            {
                Val = s,
                s.Length,
                StringUpper = s.ToUpper()
            })
            .Where(o => o.StringUpper.Contains("E"))
            .Where(o => o.Length <= 3)
            .Select(o => new
            {
                o,
                o.StringUpper,
                o.Length
            });

            res1.WriteLog();

        }
    }
    public static class MyHelpers
    {

        public static void WriteLog<T>(this IEnumerable<T> data)
        {
            Trace.WriteLine("[" + String.Join(", ", data) + "]");
        }

        public static T Log<T>(this T data, string logName)
        {
            Trace.WriteLine($"   {logName}>{data}");
            return data;
        }

    }
}
