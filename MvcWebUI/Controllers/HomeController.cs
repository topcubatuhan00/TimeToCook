using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using Newtonsoft.Json;

namespace MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Daha önce kaydedilmiş ürünlerin listesini localStorage'den al
            var savedProductsJson = HttpContext.Session.GetString("products");
            var savedProducts = string.IsNullOrEmpty(savedProductsJson)
                ? new List<Product>()
                : JsonConvert.DeserializeObject<List<Product>>(savedProductsJson);

            // Ürünleri ViewModel'e dönüştürerek View'e gönder
            var viewModel = new ProductListViewModel { Products = savedProducts };
            return View(viewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult RemoveProduct(int productId)
        {
            // Daha önce kaydedilmiş ürünlerin listesini localStorage'den al
            var savedProductsJson = HttpContext.Session.GetString("products");
            var savedProducts = string.IsNullOrEmpty(savedProductsJson)
                ? new List<Product>()
                : JsonConvert.DeserializeObject<List<Product>>(savedProductsJson);

            // Ürünü listeden bul ve sil
            var productToRemove = savedProducts.FirstOrDefault(p => p.Id == productId);
            if (productToRemove != null)
            {
                savedProducts.Remove(productToRemove);
            }

            // Güncellenmiş ürün listesini localStorage'e kaydet
            HttpContext.Session.SetString("products", JsonConvert.SerializeObject(savedProducts));

            return RedirectToAction("Index");
        }

        public IActionResult Save(ProductAddModel productModel)
        {
            // Daha önce kaydedilmiş ürünlerin listesini localStorage'den al
            var savedProductsJson = HttpContext.Session.GetString("products");
            var savedProducts = string.IsNullOrEmpty(savedProductsJson)
                ? new List<Product>()
                : JsonConvert.DeserializeObject<List<Product>>(savedProductsJson);

            // Yeni ürünü ekle
            savedProducts.Add(new Product
            {
                Name = productModel.Name,
                Photo = productModel.Photo,
                Amount = productModel.Amount,
                SKTDate = productModel.SKTDate,
                CreatedDate = DateTime.Now.ToString("dd.MM.yyyy")
            });

            // Güncellenmiş ürün listesini localStorage'e kaydet
            HttpContext.Session.SetString("products", JsonConvert.SerializeObject(savedProducts));

            return RedirectToAction("Index");
        }
    }
}