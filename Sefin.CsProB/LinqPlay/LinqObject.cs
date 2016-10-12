using Sefin.CsPro.Commons;
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
    public class LinqObject
    {
        public object ComplexObjects()
        {
            var db = new NorthwindDatabase();

            var res = db.Categories.Select(c => c.CategoryName);
            res.WriteLog();

            var res1 = db.Categories.Select(c => new
            {
                c.Id,
                c.CategoryName
            });

            res1.WriteLog();

            var searchText = "bev";
            var res2 = db.Categories
                        .Where(c => 0 <=
                                c.CategoryName
                                    .IndexOf(searchText,
                                        StringComparison.CurrentCultureIgnoreCase))
                        .Select(c => c.CategoryName);
            res2.WriteLog();


            var res3 = db.Products.Where(p => p.Category.Id == 1)
                                .Select(p => new
                                {
                                    p.Id,
                                    p.ProductName,
                                    CategoryId = p.Category.Id,
                                    p.Category.CategoryName
                                });

            //res3.WriteLog();

            var num = res.Count();
            Trace.WriteLine("num products = " + num);

            var list = res3.ToList();
            var count1 = list.Count;
            var count2 = list.Count();

            Trace.WriteLine($"count on list {count1} - {count2} ");

            var prods = db.Products;

            prods = prods.Where(p => p.Category.Id == 1);

            int totalProds = prods.Sum(p => p.UnitsInStock);
            decimal avgPrice = prods.Average(p => p.UnitPrice);
            var totalValue = prods.Sum(p => p.UnitPrice * p.UnitsInStock);

            Trace.WriteLine($"prods: {totalProds} , avg: {avgPrice} , tot: {totalValue}");

            var p1 = prods.First(); // almeno 1 dato o più
            var p2 = prods.FirstOrDefault(); // il primo se c'è
            //var p3 = prods.Single(); // l'unico elemento altrimenti error
            //var p4 = prods.SingleOrDefault(); // l'unico se c'è o null
            var p4 = prods.SingleOrDefault(p => p.Id == 7);

            Trace.WriteLine("-------");
            var categories = db.Categories.OrderBy(c => c.CategoryName);

            foreach (var cat in categories)
            {
                var prodCount = db.Products
                                        .Where(p => p.Category.Id == cat.Id)
                                        .Count();

                prodCount = db.Products.Count(p => p.Category.Id == cat.Id);

                Trace.WriteLine($" > {cat.CategoryName}   {prodCount} prods");
            }

            var category = db.Categories.First();

            Trace.WriteLine("-------");
            var catProductCount = db.Categories
                        .OrderBy(c => c.CategoryName)
                        .Select(c => new
                        {
                            c.CategoryName,
                            NumProds = db.Products.Count(p => p.Category.Id == c.Id)
                        });

            catProductCount.WriteLog();

            return catProductCount;
        }

    }
}
