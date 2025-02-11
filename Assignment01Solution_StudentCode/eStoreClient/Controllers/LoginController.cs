using BusinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace eStoreClient.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public LoginController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "https://localhost:7200/api/members";
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Member member)
        {
            //get admin from appsettings.json
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Set base path
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Load appsettings.json
            .Build();

            // Read admin settings
            string adminUsername = config["admin:username"];
            string adminPassword = config["admin:password"];
            if (member.Email == adminUsername && member.Password == adminPassword)
            {
                HttpContext.Session.SetString("role", "admin");
            }
            else
            {
                HttpResponseMessage memberResponse = await client.GetAsync(MemberApiUrl);
                List<Member> listMembers = await memberResponse.Content.ReadFromJsonAsync<List<Member>>();
                member = listMembers.SingleOrDefault(m => m.Email == member.Email && m.Password == member.Password);
                if (member == null)
                {
                    return RedirectToAction("Index");
                }
                HttpContext.Session.SetString("role", "user");
                HttpContext.Session.SetString("memberId", member.MemberId.ToString());
            }
            
            
            return RedirectToAction("Index", "Home");
        }

    }
}
