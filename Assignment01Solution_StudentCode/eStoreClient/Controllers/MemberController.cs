using BusinessObject.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace eStoreClient.Controllers
{
    public class MemberController : Controller
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public MemberController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "https://localhost:7200/api/members";
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage memberResponse = await client.GetAsync(MemberApiUrl);
            List<Member> listMembers = await memberResponse.Content.ReadFromJsonAsync<List<Member>>();

            return View(listMembers);
        }
    }
}
