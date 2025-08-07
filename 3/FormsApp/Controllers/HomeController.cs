using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FormsApp.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
    }

    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;
        ViewBag.searchString = searchString;
        if (!String.IsNullOrEmpty(category))
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();

        }

        if (!String.IsNullOrEmpty(searchString))
        {
            products = products.Where(p => p.Name!.ToLower().Contains(searchString)).ToList();
        }


        var model = new ProductViewModel
        {
            Products = products,
            Categories = Repository.Categories,
            selectedCategory = category



        };
        return View(model);

    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");


        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile? imageFile)
    {

        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
        }
        if (imageFile == null)
        {
            ModelState.AddModelError("Image", "Lütfen bir resim yükleyin.");
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
        }



        if (imageFile != null && imageFile.Length > 0)
        {

            var extention = Path.GetExtension(imageFile.FileName);
            var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extention}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }


            model.Image = randomFileName;
        }




        Repository.CreateProduct(model);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {


        var product = Repository.Products.Where(i => i.ProductId == id).FirstOrDefault();
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");



        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product model, IFormFile? imageFile)
    {
        if (!ModelState.IsValid)
        {
            
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
        }

        var product = Repository.Products.Where(i => i.ProductId == model.ProductId).FirstOrDefault();
         if (product == null)
        {
            return NotFound();
        }
        if (product.Name != model.Name)
        {
            product.Name = model.Name;
        }
        if (product.Price != model.Price)
        {
            product.Price = model.Price;
        }
        if (product.IsActive != model.IsActive)
        {
            product.IsActive = model.IsActive;
        }
        if (product.CategoryId != model.CategoryId)
        {
            product.CategoryId = model.CategoryId;
        }
        if (imageFile != null && imageFile.Length > 0)
        {
            var extention = Path.GetExtension(imageFile.FileName);
            var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extention}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            product.Image = randomFileName;
        }


        return RedirectToAction("Index");

    }


    public IActionResult Delete(int id)
    {
        var product = Repository.Products.Where(i => i.ProductId == id).FirstOrDefault();


        return View(product);

    }
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        Repository.Products.RemoveAll(i => i.ProductId == id);
        return RedirectToAction("Index");


    }

}
