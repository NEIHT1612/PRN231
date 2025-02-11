using BusinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            var memberJson = new StringContent(JsonSerializer.Serialize(member), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(MemberApiUrl, memberJson);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage memberResponse = await client.GetAsync($"{MemberApiUrl}/{id}");
            Member member = await memberResponse.Content.ReadFromJsonAsync<Member>();

            return View(member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Member member)
        {
            var memberJson = new StringContent(JsonSerializer.Serialize(member), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(MemberApiUrl+"/"+member.MemberId, memberJson);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{MemberApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            HttpResponseMessage memberResponse = await client.GetAsync($"{MemberApiUrl}/{id}");
            Member member = await memberResponse.Content.ReadFromJsonAsync<Member>();

            return View(member);
        }

    }
}
