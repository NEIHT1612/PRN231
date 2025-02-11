using DataAccess.Repository.ImplRepo;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.DataAccess;

namespace eStoreAPI.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberAPI : ControllerBase
    {
        private IMemberRepository repository = new MemberRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetMembers() => repository.GetMembers();

        [HttpGet("SearchByCompanyOrEmail/{keyword}")]
        public ActionResult<IEnumerable<Member>> Search(string keyword) => repository.Search(keyword);

        [HttpGet("{id}")]
        public ActionResult<Member> GetMemberById(int id) => repository.GetMemberById(id);

        [HttpGet("Email/{email}")]
        public ActionResult<Member> GetMemberByEmail(string email) => repository.GetMemberByEmail(email);

        [HttpPost]
        public IActionResult PostMember(Member memberreq)
        {
            var member = new Member
            {
                CompanyName = memberreq.CompanyName,
                Email = memberreq.Email,
                City = memberreq.City,
                Country = memberreq.Country,
                Password = memberreq.Password,
            };
            repository.SaveMember(member);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
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
        public IActionResult PutMember(int id, Member memberReq)
        {
            var mTmp = repository.GetMemberById(id);
            if (mTmp == null)
            {
                return NotFound();
            }

            mTmp.CompanyName = memberReq.CompanyName;
            mTmp.Email = memberReq.Email;
            mTmp.City = memberReq.City;
            mTmp.Country = memberReq.Country;

            if (memberReq.Password != null && mTmp.Password != memberReq.Password)
            {
                mTmp.Password = memberReq.Password;
            }

            repository.UpdateMember(mTmp);
            return NoContent();
        }
    }
}
