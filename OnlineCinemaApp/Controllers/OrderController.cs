using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineCinemaApp.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinemaApp.Controllers
{
    public class OrderController : Controller
    {
        public OrderController()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "https://localhost:44301/api/Admin/GetAllActiveOrders";
            HttpResponseMessage response = client.GetAsync(URL).Result;
            var data = response.Content.ReadAsAsync<List<Order>>().Result;
            return View(data);
        }
        public IActionResult Details(Guid orderId)
        {
            HttpClient client = new HttpClient();
            string URL = "https://localhost:44301/api/Admin/GetDetailsForOrder";
            var model = new
            {
                Id = orderId
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(URL, content).Result;
            var data = response.Content.ReadAsAsync<Order>().Result;
            return View(data);
        }
        public FileContentResult CreateInvoice(Guid orderId)
        {
            HttpClient client = new HttpClient();
            string URL = "https://localhost:44301/api/Admin/GetDetailsForOrder";
            var model = new
            {
                Id = orderId
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(URL, content).Result;
            var data = response.Content.ReadAsAsync<Order>().Result;

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");
            var document = DocumentModel.Load(templatePath);

            document.Content.Replace("{{OrderNumber}}", data.Id.ToString());
            document.Content.Replace("{{User}}", data.User.UserName);

            StringBuilder sb = new StringBuilder();
            var totalPrice = 0.0;
            foreach(var item in data.Products)
            {
                totalPrice += item.Quantity * item.SelectedProduct.ProductPrice;
                sb.AppendLine(item.SelectedProduct.ProductName + " with quantity of: " + item.Quantity + " and price of: " + item.SelectedProduct.ProductPrice );
            }
            document.Content.Replace("{{ProductList}}", sb.ToString());
            document.Content.Replace("{{TotalPrice}}", totalPrice.ToString());

            var stream = new MemoryStream();
            document.Save(stream, new PdfSaveOptions());

            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");
        }
    }
}
