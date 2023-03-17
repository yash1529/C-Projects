using Microsoft.AspNetCore.Mvc;
using database_mvc.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace database_mvc.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext ProductController_dataContext;
        public ProductController(ProductContext dataContext)
        {
            ProductController_dataContext = dataContext;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel credits)
        {
            if(credits.Username!=null && credits.Username=="yash")
            {
                if(credits.Password!=null && credits.Password == "12345")
                {
                    return RedirectToAction("Index");
                }
            }
            return View(credits);
        }
        public ActionResult Index()
        {
            //calling two models in a single view
            ViewData["Products"] = GetItems();
            ViewData["CatProduct"] = GetItemsCat();
            return View();
        }


        private List<Product> GetItems()
        {
            var Items = ProductController_dataContext.Products.ToList();

            return Items;
        }
        private List<ProductCat> GetItemsCat()
        {

            var Items = ProductController_dataContext.ProductCats.ToList();
            return Items;
        }
        public IActionResult Create()
        {
            List<ProductCat> CategoryList = new List<ProductCat>();
            var mylist = (from c in ProductController_dataContext.ProductCats
                          select new SelectListItem()
                          {
                              Value = c.Id.ToString(),
                              Text=c.Pname
                          }).ToList();
            mylist.Insert(0, new SelectListItem { Value = string.Empty, Text = "---Select Category---" });
            ViewBag.ListofCategoriess = mylist;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListAndModel item)
        {

            //to validate the model
            if (ModelState.IsValid)
            {

                ProductController_dataContext.Add(item);

                await ProductController_dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<ProductCat> CategoryList = new List<ProductCat>();
            var mylist = (from c in ProductController_dataContext.ProductCats
                          select new SelectListItem()
                          {
                              Value = c.Id.ToString(),
                              Text = c.Pname
                          }).ToList();
            mylist.Insert(0, new SelectListItem { Value = string.Empty, Text = "---Select Category---" });
            ViewBag.ListofCategoriess = mylist;

            return View(item);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            List<ProductCat> CategoryList = new List<ProductCat>();
            var mylist = (from c in ProductController_dataContext.ProductCats
                          select new SelectListItem()
                          {
                              Value = c.Id.ToString(),
                              Text = c.Pname
                          }).ToList();
            mylist.Insert(0, new SelectListItem { Value = string.Empty, Text = "---Select Category---" });
            ViewBag.ListofCategoriess = mylist;



            var item = await ProductController_dataContext.Products
                .FirstOrDefaultAsync(m => m.PId == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Product item)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    ProductController_dataContext.Update(item);
                    await ProductController_dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductController_dataContext.Products.Any(e => e.PId == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public async Task<IActionResult> Delete(int? id)
        {


            var item = await ProductController_dataContext.Products
                .FirstOrDefaultAsync(m => m.PId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await ProductController_dataContext.Products.FindAsync(id);
            ProductController_dataContext.Products.Remove(item);
            await ProductController_dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> DeleteCategory(int? id)
        //{
        //    var item = await ProductController_dataContext.ProductCats
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (item == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(item);
        //}

        //[HttpPost, ActionName("DeleteCategory")]
        //[Obsolete]
        //public IActionResult DeleteCategory(int id)
        //{
            
        //    foreach(Product item in ProductController_dataContext.Products)
        //    {
        //        if (item.Pcategory == id)
        //        {
        //            ProductController_dataContext.Products.Remove(item);
        //        }
        //    }
        //    var query = @"delete from YProductCategory where Id=@id";
        //    var Id = id;
        //    ProductController_dataContext.Database.ExecuteSqlCommand(query, new SqlParameter("@Id", id));

        //    ProductController_dataContext.SaveChanges();
        //    return View("Index");
        //}
    }
}
