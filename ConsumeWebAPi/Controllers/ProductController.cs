using ConsumeWebAPi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ConsumeWebAPi.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5283/api");
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;

        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductViewModel> productsList = new List<ProductViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress
                + "/product/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productsList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);

            }
            return View(productsList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8,
                    "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress +
                    "/Product/Post", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Product Created.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            try
            {
                ProductViewModel product = new ProductViewModel()
                {
                    ProductName = "ProductName"
                };
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress
                    + "/product/Get" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<ProductViewModel>(data);

                }
                return View(product);
            }
            catch (Exception ex )
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
           
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel model) 
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content=new StringContent(data, Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress +
                "/Product/Put",content).Result;
            if (response.IsSuccessStatusCode) 
            {
                TempData["successMessage"] = "Product details updated";
                return RedirectToAction("Index");
            }

            return View(response); 
        }
    }
    
}
