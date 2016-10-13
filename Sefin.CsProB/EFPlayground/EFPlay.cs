using EFPlayground.NW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace EFPlayground
{
    [Category("test")]
    public class EFPlay
    {
        public object IntroEF() {
            using (var ctx = new NorthwindContext())
            {
                //return ctx.Categories.ToList();

                ctx.Database.Log = txt => Trace.WriteLine(">>> " + txt); 

                //var cat = ctx.Categories.FirstOrDefault();

                //Trace.WriteLine($"Cat {cat.CategoryID} - {cat.CategoryName}");

                //var prods = ctx.Products.OrderBy(p => p.ProductName);
                //foreach (var prod in prods) {
                //    Trace.WriteLine($" > prod: {prod.ProductID}. {prod.ProductName} ({prod.Categories.CategoryName})");
                //}

                var prods = ctx.Products
                        .OrderBy(p => p.ProductName)
                        .Select(p => new {
                            p.ProductID,
                            p.ProductName,
                            p.Categories.CategoryName
                        });
                foreach (var prod in prods)
                {
                    Trace.WriteLine($" > prod: {prod.ProductID}. {prod.ProductName} ({prod.CategoryName})");
                }

                return null;

                var categ1 = ctx.Categories
                            .Select(c => new
                            {
                                c.CategoryID,
                                c.CategoryName
                            })
                            .OrderBy(c => c.CategoryName);

                return categ1.ToList();


            }

            return null;
        }
    }
}
