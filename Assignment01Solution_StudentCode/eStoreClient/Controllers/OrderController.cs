using BusinessObject.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace eStoreClient.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient client = null;
        private string OrderApiUrl = "";
        private string MemberApiUrl = "";
        private string OrderDetailApiUrl = "";

        public OrderController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            OrderApiUrl = "https://localhost:7200/api/orders";
            MemberApiUrl = "https://localhost:7200/api/members";
            OrderDetailApiUrl = "https://localhost:7200/api/orderdetails";

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage orderResponse = await client.GetAsync(OrderApiUrl);
            List<Order> listOrders = await orderResponse.Content.ReadFromJsonAsync<List<Order>>();

            HttpResponseMessage memberResponse = await client.GetAsync(MemberApiUrl);
            List<Member> listMembers = await memberResponse.Content.ReadFromJsonAsync<List<Member>>();
            ViewData["Members"] = listMembers;

            return View(listOrders);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int orderID)
        {
            HttpResponseMessage orderDetailResponse = await client.GetAsync($"{OrderDetailApiUrl}/order/{orderID}/{orderID}");
            OrderDetail listOrderDetails = await orderDetailResponse.Content.ReadFromJsonAsync<OrderDetail>();
            return View(listOrderDetails);
        }
    }
}
