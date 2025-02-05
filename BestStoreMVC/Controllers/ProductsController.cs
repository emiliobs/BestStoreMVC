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
    }
}