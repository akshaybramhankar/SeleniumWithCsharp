using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ScrapingWithSelenuim.Models;

namespace ScrapingWithSelenuim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapeController : ControllerBase
    {
        // GET: api/Scrape
        [HttpGet]
        public OkObjectResult Get()
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                // Iss line pe doubt hai kyu yaha pe jo Path aara hoga wo shayad linux mai exist nahi karta hoga.
                IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                driver.Navigate().GoToUrl(@"https://www.google.com/");
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return Ok(new ScrapeResponse() { Success = false, Message = ex.Message });
            }
        }

        // GET: api/Scrape/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Scrape
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Scrape/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
