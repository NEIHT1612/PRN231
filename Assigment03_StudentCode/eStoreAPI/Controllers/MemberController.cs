using BusinessObject;
using eStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.ImplRepo;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberRepository repository = new MemberRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetCustomers() => repository.GetMembers();

        [HttpGet("SearchByUnitPrice/{keyword}")]
        public ActionResult<IEnumerable<Member>> Search(string keyword) => repository.Search(keyword);

        [HttpGet("{id}")]
        public ActionResult<Member> GetCustomerById(string id) => repository.GetMemberById(id);

        [HttpGet("Email/{email}")]
        public ActionResult<Member> GetCustomerByEmail(string email) => repository.GetMemberByEmail(email);

        [HttpPost]
        public IActionResult PostMember(PutMember memberreq)
        {
            var member = new Member
            {
                MemberName = memberreq.MemberName,
                City = memberreq.City,
                Country = memberreq.Country,

            };

            repository.SaveMember(member);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(string id)
        {
            var c = repository.GetMemberById(id);
            if (c == null)
            {
                return NotFound();
            }
            repository.DeleteMember(c);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutMember(string id, PutMember memberReq)
        {
            var mTmp = repository.GetMemberById(id);
            if (mTmp == null)
            {
                return NotFound();
            }

            mTmp.MemberName = memberReq.MemberName;
            mTmp.City = memberReq.City;
            mTmp.Country = memberReq.Country;
            mTmp.Birthday = memberReq.Birthday;
            if (memberReq.Password != null && mTmp.PasswordHash != memberReq.Password)
            {
                mTmp.PasswordHash = memberReq.Password;
            }

            repository.UpdateMember(mTmp);
            return NoContent();
        }
    }
}
