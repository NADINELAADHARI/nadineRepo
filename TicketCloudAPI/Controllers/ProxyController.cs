using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using TicketCloudAPI.Models;

namespace TicketCloudAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProxyController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string localApiUrl = "https://xxx.ngrok.io/api/tickets"; // remplace par ton lien ngrok

        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var response = await _httpClient.GetAsync(localApiUrl);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpPost]
        public async Task<IActionResult> PostTicket([FromBody] TicketModel ticket)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(ticket);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync(localApiUrl, content);
            var result = await response.Content.ReadAsStringAsync();

            return Content(result, "application/json");
        }
    }

}
