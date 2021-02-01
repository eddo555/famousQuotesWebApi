using FamousQuotesApi.Data;
using FamousQuotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FamousQuotesApi.Controllers
{
    public class ValuesController : ApiController
    {
        FamousQuotesApiDbContext famousQuotesDbContext = new FamousQuotesApiDbContext();
        // GET api/values
        [HttpGet]
        public IEnumerable<Menu> Get()
        {
            return famousQuotesDbContext.Menus.Include("SubMenus");
        }
        [HttpGet]
        [Route("api/values/GetSubMenu")]
        public IEnumerable<SubMenu> GetSubMenu()
        {
            return famousQuotesDbContext.SubMenus;
        }
       

        // GET api/values/5
        [HttpGet]
        [Route("api/values/GetQuote/{id}")]
        public IHttpActionResult GetQuote(int id)
        {
            var quote = famousQuotesDbContext.SubMenus.Find(id);
            return Ok(quote);
        }

        // POST api/values
        public void Post([FromBody] SubMenu quote)
        {
            famousQuotesDbContext.SubMenus.Add(quote);
            famousQuotesDbContext.SaveChanges();
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] SubMenu quote)
        {
            var newInput  = famousQuotesDbContext.SubMenus.FirstOrDefault(x => x.SubMenuId == id);

            newInput.Name = quote.Name;
            newInput.Type = quote.Type;
            newInput.Quote = quote.Quote;
            newInput.Menu_MenuId = quote.Menu_MenuId;

            famousQuotesDbContext.SaveChanges();
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            var removeQuote = famousQuotesDbContext.SubMenus.Find(id);
            famousQuotesDbContext.SubMenus.Remove(removeQuote);

            famousQuotesDbContext.SaveChanges();
            return Ok("Quote deleted");
        }
    }
}
