using EFPlayground.NW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;

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


                var prods = ctx.Products.Include(p => p.Categories)
                            .Include(p => p.Categories.Products)
                        .OrderBy(p => p.ProductName);
                foreach (var prod in prods)
                {
                    Trace.WriteLine($" > prod: {prod.ProductID}. {prod.ProductName} ({prod.Categories.CategoryName})");
                }

                return null;

                var prods1 = ctx.Products
                        .OrderBy(p => p.ProductName)
                        .Select(p => new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Categories.CategoryName
                        });
                foreach (var prod in prods1)
                {
                    Trace.WriteLine($" > prod: {prod.ProductID}. {prod.ProductName} ({prod.CategoryName})");
                }

                //return null;

                var categ1 = ctx.Categories
                            .Select(c => new
                            {
                                c.CategoryID,
                                c.CategoryName
                            })
                            .OrderBy(c => c.CategoryName);

                //return categ1.ToList();


                var prodCategories = from p in ctx.Products
                                     join c in ctx.Categories
                                        on p.CategoryID equals c.CategoryID into ps
                                     from c1 in ps.DefaultIfEmpty()
                                     select new
                                     {
                                         p.ProductID,
                                         p.ProductName,
                                         c1.CategoryName
                                     };

                //return prodCategories.ToList();

                var id = -1;

                var prodCat2 = ctx.Products
                                .Where(p => p.Suppliers.CompanyName !=  "pippo")
                                .Join(ctx.Categories,
                                    p => p.CategoryID,
                                    c => c.CategoryID,
                                    (p, c) => new
                                    {
                                        p.ProductID,
                                        p.ProductName,
                                        c.CategoryName
                                    });
                Trace.WriteLine("q: " + prodCat2);

                //(p,c) => new { Prod = p, Categ = c } );
                //return prodCat2.ToList();


                var filter = "bev";
                var categs2 = ctx.Categories.ToList()
                        .Where(c => c.CategoryName.Contains(filter))
                        .Select(c => new { c.CategoryID, c.CategoryName });

                return categs2.ToList();
            }

            return null;
        }


        public object Paginating() {
            using (var ctx = new NorthwindContext()) {

                var orders = ctx.Orders.Select(o => new {
                    o.OrderID,
                    o.OrderDate,
                    o.Customers.CustomerID,
                    o.Customers.ContactName,
                    NumProds = o.Order_Details.Count()
                });

                orders = orders.OrderBy(o => o.OrderDate)
                            .Skip(100).Take(20);

                return orders.ToList();
                

            }
        }


        public object TestEf2() {
            using (var ctx = new NorthwindContext()) {

                var prods1 = ctx.Products
                        .Where( p => p.ProductName.StartsWith("S"))
                        .Select(p => new {
                                p.ProductID,
                                p.ProductName,
                                p.UnitPrice,
                                p.Categories.CategoryName
                            });

                //return prods1;

                var prods2 = ctx.Products
                            .Include(p => p.Categories)
                            .Include(p => p.Order_Details)
                           .Where(p => p.ProductName.StartsWith("S"));

                //foreach (var p in prods2) {
                //    Trace.WriteLine($"{p.ProductID}. {p.ProductName} ({p.Categories.CategoryName}) "+
                //        $" Ordini: {p.Order_Details.Count()}");
                //}

                var prods3 = ctx.Products
                               .Where(p => p.Categories.CategoryName.Contains("S"))
                                .Select(p => new {
                                    p.ProductID,
                                    p.ProductName,
                                    p.UnitPrice,
                                    p.Categories.CategoryName,
                                    NumOrdini = p.Order_Details.Count(),
                                    NumProdottiOrdinati = p.Order_Details.Sum(od => od.Quantity),
                                    Orders = p.Order_Details
                                });

                //var p1 = prods3.FirstOrDefault();

                return prods3.ToList();
                //foreach (var p in prods3)
                //{
                //    Trace.WriteLine($"{p.ProductID}. {p.ProductName} ({p.Categories.CategoryName}) ");
                //}

            }

            return null;
        }

        /*

   * Stampa Id, Nome del prodotto 11
   * Stampa Id, Nome,CategoryName del prodotto 11
   * Id, Nome di Tutti i prodotti della categoria 2
   * Id, Nome, CategoryName di Tutti i prodotti della categoria 2
   * Id, Nome, CategoryName di Tutti i prodotti delle categorie che iniziano per C
   * Id, Nome delle categoria che hanno prodotti in riordino (flag reorder?)
   * Id, Nome, CategoryName di Tutti i prodotti da riordinare (unitinstock e reorder level)
   * Id, Nome delle categoria che hanno prodotti da riordinare (unitinstock e reorder level)
   * Id, Nome e num prodotti di tutte le categorie


   */
    }
}
