using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Functions101.Models.Toons;
using System.Linq;

namespace Snoopy.Function
{
    public class HttpWebApi
    {
        private readonly ToonsContext _context;

        public HttpWebApi(ToonsContext context)
        {
            _context = context;
        }

        [FunctionName("HttpWebApi")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "hello")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("GetToons")]
        public IActionResult GetToons(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "toons")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP GET/posts trigger function processed a request in GetToons().");

            var toons = _context.People.ToArray();

            return new OkObjectResult(toons);
        }

        [FunctionName("GetToon")]
        public IActionResult GetToon(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "toons/{id}")] HttpRequest req,
        ILogger log, int id)
        {
            log.LogInformation("C# HTTP GET/posts trigger function processed a request.");
            if (id < 1)
            {
                return new NotFoundResult();
            }
            var toon = _context.People.FindAsync(id).Result;
            if (toon == null)
            {
                return new NotFoundResult();
            }
            log.LogInformation(toon.Id.ToString());
            return new OkObjectResult(toon);
        }

        [FunctionName("CreateToon")]
        public async Task<IActionResult> CreateToon(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "toons")] HttpRequest req,
        ILogger log)
        {
            log.LogInformation("C# HTTP POST/posts trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<Person>(requestBody);
            var toon = new Person()
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Occupation = input.Occupation,
                Gender = input.Gender,
                PictureUrl = input.PictureUrl,
                Votes = input.Votes
            };
            _context.Add(toon);
            await _context.SaveChangesAsync();
            log.LogInformation(requestBody);
            return new OkObjectResult(toon);
        }

        [FunctionName("UpdateToon")]
        public async Task<IActionResult> UpdateToon(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "toons/{id}")] HttpRequest req,
        ILogger log, int id) {
            log.LogInformation("C# HTTP PUT/posts trigger function processed a request.");
            if (id < 1)
            {
                return new NotFoundResult();
            }
            var toon = await _context.People.FindAsync(id);
            if (toon == null)
            {
                return new NotFoundResult();
            }
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<Person>(requestBody);
            toon.FirstName = input.FirstName;
            toon.LastName = input.LastName;
            toon.Occupation = input.Occupation;
            toon.Gender = input.Gender;
            toon.PictureUrl = input.PictureUrl;
            toon.Votes = input.Votes;
            _context.Update(toon);
            await _context.SaveChangesAsync();
            log.LogInformation(requestBody);
            return new OkObjectResult(toon);
        }

        [FunctionName("DeleteToon")]
        public IActionResult DeleteToon(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "toons/{id}")] HttpRequest req,
        ILogger log, int id) {
            log.LogInformation("C# HTTP DELETE/posts trigger function processed a request.");
            if (id < 1)
            {
                return new NotFoundResult();
            }
            var toon = _context.People.FindAsync(id).Result;
            if (toon == null)
            {
                return new NotFoundResult();
            }
            _context.Remove(toon);
            _context.SaveChangesAsync();
            return new OkResult();
        }

    }
}
