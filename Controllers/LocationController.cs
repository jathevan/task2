using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using task2.Models;

namespace task2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILogger<LocationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Data>> Get()
        {
            List<Data> dataSet = new List<Data>();
            //Access Key
            const string accessKey = "169fb872fb726ed30d8a98e50614b312";
          
            //Have your api call in try/catch block.
            try
            {
                //Now we will have our using directives which would have a HttpClient
                using HttpClient client = new HttpClient();
                //Now get your response from the client from get request to baseurl.
                //Use the await keyword since the get request is asynchronous, and want it run before next asychronous operation.
                using HttpResponseMessage res = await client.GetAsync("http://api.ipstack.com/134.201.250.155?access_key=" + accessKey).ConfigureAwait(false);
                //Now we will retrieve content from our response, which would be HttpContent, retrieve from the response Content property.
                using HttpContent content = res.Content;
                //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                string data = await content.ReadAsStringAsync().ConfigureAwait(false);
                //If the data is not null, parse the data to a C# object
                if (data != null)
                {
                    //Parse your data into a object.
                    var dataObj = JObject.Parse(data);
                    var ip = $"{dataObj["ip"]}";
                    var city = $"{dataObj["city"]}";
                    dataSet.Add(new Data(ip, city));
                    return dataSet;
                }
                else
                {
                    //If data is null log it into console.
                    Console.WriteLine("Data is null!");
                }
            }
            //Catch any exceptions and log it into the console.
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return dataSet;
        }
    }
}