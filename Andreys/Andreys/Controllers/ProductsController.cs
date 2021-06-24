using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Andreys.Data;
using Andreys.Data.Common;
using Andreys.Data.Models;
using Andreys.Models.Products;
using Andreys.Services.Contacts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Andreys.Controllers
{
   public class ProductsController : Controller
    {
        private readonly IValidator validator;
        private readonly AndreysDbContext data;

        public ProductsController(IValidator validator,AndreysDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        public HttpResponse Add() => View();

        [HttpPost]
        public HttpResponse Add(ProductAddInputModel model)
        {
            var validateErrors = this.validator.ValidateProduct(model);
            if (validateErrors.Any())
            {
                return Error(validateErrors);
            }
            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Category = Enum.Parse<Category>(model.Category),
                Gender = Enum.Parse<Gender>(model.Gender),
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();

            return Redirect("/");
        }
        [Authorize]
        public HttpResponse Details(int id)
        {
            var product = this.data.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return Error("Invalid product has been chosen.");
            }

            return View(product);
        }
        [Authorize]
        public HttpResponse Delete(int id)
        {
            var product = this.data.Products.Find(id);

            this.data.Products.Remove(product);
            this.data.SaveChanges();

            return Redirect("/");
        }
    }
}
