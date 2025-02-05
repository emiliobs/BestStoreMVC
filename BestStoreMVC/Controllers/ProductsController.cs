using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BestStoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this._context = context;
            this._environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.OrderByDescending(p => p.Id).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (productDto.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "The image file is required.");
            }

            if (!ModelState.IsValid)
            {
                return View(productDto);
            }

            // Save the image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(productDto.ImageFile!.FileName);

            string imageFullPath = _environment.WebRootPath + "/products/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                productDto.ImageFile.CopyTo(stream);
            }

            // Save the new  product in the database
            Product product = new Product
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Category = productDto.Category,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            if (product is null)
            {
                return RedirectToAction("Index", "Products");
            }

            // Create productDtos from product
            var productDto = new ProductDto
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
            };

            ViewData["ProductID"] = product.Id;
            ViewData["ImageFileName"] = product.ImageFileName;
            ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");

            return View(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
            {
                return RedirectToAction("Index", "Products");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ProductID"] = product.Id;
                ViewData["ImageFileName"] = product.ImageFileName;
                ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");

                return View(productDto);
            }

            // Update the image file file if we have a new image file
            string newFileName = product.ImageFileName;

            if (productDto.ImageFile is not null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(productDto.ImageFile.FileName);
                string imageFullPath = _environment.WebRootPath + "/products/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    productDto.ImageFile.CopyTo(stream);
                }

                // delete thge old image file
                string oldImageFullPath = _environment.WebRootPath + "/products/" + product.ImageFileName;
                if (System.IO.File.Exists(oldImageFullPath))
                {
                    System.IO.File.Delete(oldImageFullPath);
                }
            }

            // Update the product in the database
            product.Name = productDto.Name;
            product.Brand = productDto.Brand;
            product.Category = productDto.Category;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            product.ImageFileName = newFileName;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Products");
        }
    }
}