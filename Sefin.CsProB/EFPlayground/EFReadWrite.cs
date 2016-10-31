using EFPlayground.NW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPlayground
{
    [Category("test")]
    public class EFReadWrite
    {
        public void Insert()
        {
            using (var ctx = new NorthwindContext())
            {

                var newCat = new Categories
                {
                    CategoryName = "Extra dolci"
                };

                Trace.WriteLine($"Add {newCat.CategoryID}. {newCat.CategoryName}");
                ctx.Categories.Add(newCat);

                ctx.SaveChanges();
                Trace.WriteLine($"Done: {newCat.CategoryID}. {newCat.CategoryName}");

            }
        }

        public void InsertWithChilds()
        {
            using (var ctx = new NorthwindContext())
            {

                var newCat = new Categories
                {
                    CategoryName = "Extra dolci"
                };

                Trace.WriteLine($"Add {newCat.CategoryID}. {newCat.CategoryName}");
                ctx.Categories.Add(newCat);

                var newProd1 = new Products
                {
                    ProductName = "Torta extra fondente"
                };
                var newProd2 = new Products
                {
                    ProductName = "Barretta miele e meringa"
                };

                newCat.Products.Add(newProd1);
                newCat.Products.Add(newProd2);

                ctx.SaveChanges();
                Trace.WriteLine($"Done: {newCat.CategoryID}. {newCat.CategoryName}");

            }
        }

        public void InsertWithChilds2()
        {
            using (var ctx = new NorthwindContext())
            {
                try
                {
                    var newCat = new Categories
                    {
                        CategoryName = "Extra dolci"
                    };

                    Trace.WriteLine($"Add {newCat.CategoryID}. {newCat.CategoryName}");
                    ctx.Categories.Add(newCat);

                    var newProd1 = new Products
                    {
                        ProductName = "Torta extra fondente",
                        Categories = newCat
                    };
                    var newProd2 = new Products
                    {
                        ProductName = "Barretta miele e meringa",
                        Categories = newCat
                    };

                    ctx.Products.Add(newProd1);
                    ctx.Products.Add(newProd2);

                    ctx.SaveChanges();
                    Trace.WriteLine($"Done: {newCat.CategoryID}. {newCat.CategoryName}");
                }
                catch (Exception ex) {
                    Trace.WriteLine(ex.ToString());
                }

            }
        }

        public void Update() {
            using (var ctx = new NorthwindContext())
            {
                //var cat = ctx.Categories.Where(c => c.CategoryID == 17).Single();
                //var cat = ctx.Categories.Single(c => c.CategoryID == 17);
                var cat = ctx.Categories.Find(17);

                var entryCat = ctx.Entry(cat);

                cat.Description = "moooolto dolce";

                entryCat = ctx.Entry(cat);

                ctx.SaveChanges();

                entryCat = ctx.Entry(cat);

                //entryCat = ctx.Entry(new Categories());

            }
        }
    }
}
