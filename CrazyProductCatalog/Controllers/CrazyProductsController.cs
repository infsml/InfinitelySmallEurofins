using CrazyProductCatalog.Models.Data;
using CrazyProductCatalog.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace CrazyProductCatalog.Controllers
{
    public class CrazyProductsController : ApiController
    {
        private CrazyProductDBContext db = new CrazyProductDBContext();

        /*//Design and implement End points
        //URI
        //Resource : Products
        //Action : GET
        //URI : GET {domain}/api/CrazyProducts
        // GET .../api/CrazyProducts
        public List<CrazyProduct> GetCrazyProducts()
        {
            return db.CrazyProducts.ToList();
        }
        // GET .../api/CrazyProducts/1
        public IHttpActionResult GetCrazyProduct(int id)
        {
            var product = db.CrazyProducts.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        // GET .../api/CrazyProducts/category/mobiles
        [Route("Api/CrazyProducts/category/{category}")]
        public IHttpActionResult GetCrazyProductByCategory(string category)
        {
            var product = db.CrazyProducts.Where(c=>c.Category == category).ToList();
            if(product == null||product.Count==0) return NotFound();
            return Ok(product);
        }
        [Route("Api/CrazyProducts/country/{country}")]
        public IHttpActionResult GetCrazyProductByCountry(string country)
        {
            var product = db.CrazyProducts.Where(c => c.Country == country).ToList();
            if (product == null || product.Count == 0) return NotFound();
            return Ok(product);
        }
        [Route("Api/CrazyProducts/description/{description}")]
        public IHttpActionResult GetCrazyProductByDescription(string description)
        {
            var product = db.CrazyProducts.Where(c => c.Description == description).ToList();
            if (product == null || product.Count == 0) return NotFound();
            return Ok(product);
        }
        [Route("Api/CrazyProducts/name/{name}")]
        public IHttpActionResult GetCrazyProductByName(string name)
        {
            var product = db.CrazyProducts.Where(c => c.Name == name).ToList();
            if (product == null || product.Count == 0) return NotFound();
            return Ok(product);
        }
        [Route("Api/CrazyProducts/expensive")]
        public IHttpActionResult GetCrazyProductExpensive()
        {
            var product = db.CrazyProducts.OrderByDescending(c=>c.Price).First();
            if (product == null) return NotFound();
            return Ok(product);
        }
        [Route("Api/CrazyProducts/cheapest")]
        public IHttpActionResult GetCrazyProductCheapest()
        {
            var product = db.CrazyProducts.OrderBy(c=>c.Price).First();
            if (product == null) return NotFound();
            return Ok(product);
        }
        [Route("Api/CrazyProducts/price")]
        public IHttpActionResult GetCrazyProductByPrice(int minPrice,int maxPrice)
        {
            var product = db.CrazyProducts.Where(c => c.Price >minPrice && c.Price < maxPrice).ToList();
            if (product == null || product.Count == 0) return NotFound();
            return Ok(product);
        }*/
        [EnableQuery]
        public IHttpActionResult GetProducts()
        {
            return Ok(db.CrazyProducts.AsQueryable());
        }

        public IHttpActionResult Post(CrazyProduct product)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            db.CrazyProducts.Add(product);
            db.SaveChanges();

            //status cod 201 - location - content
            return Created($"api/CrazyProducts/{product.Id}", product);
        }
        public IHttpActionResult Delete(int id)
        {
            var product = db.CrazyProducts.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.CrazyProducts.Remove(product); db.SaveChanges();
            return Ok();
        }
    }
}
