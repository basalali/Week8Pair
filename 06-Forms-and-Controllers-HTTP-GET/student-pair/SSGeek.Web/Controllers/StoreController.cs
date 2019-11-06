using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SSGeek.Web.Extensions;

namespace SSGeek.Web.Controllers
{
    public class StoreController : Controller
    {
        private IProductDAO productDAO;

        public StoreController(IProductDAO productDAO)
        {

            this.productDAO = productDAO;

        }
        public IActionResult Index()
        {
            IList<Product> products = productDAO.GetProducts();
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            Product product = new Product();
            product = productDAO.GetProduct(id);

            return View(product);
        }


        public ActionResult AddToCart(Product product)
        {
            ShoppingCart result = AddToList(product, product.Quantity);
            return View(result);
        }

        private ShoppingCart AddToList(Product product, int quantity)
        {
            ShoppingCart result = new ShoppingCart();

            ShoppingCart current = HttpContext.Session.Get<ShoppingCart>("ShoppingCart"); 

            if(current == null)
            {
                current = result;
            }

            current.AddToCart(product, quantity);
            HttpContext.Session.Set<ShoppingCart>("ShoppingCart", current);
            return current;
        }
      
    
    }
}