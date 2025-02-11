using BusinessObject.DataAccess;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.ImplRepo
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(Member Member) => MemberDAO.DeleteMember(Member);

        public Member GetMemberByEmail(string email) => MemberDAO.FindMemberByEmail(email);

        public Member GetMemberById(int id) => MemberDAO.FindMemberById(id);

        public List<Member> GetMembers() => MemberDAO.GetMembers();

        public List<Order> GetOrders(int MemberId) => OrderDAO.FindAllOrdersByMemberId(MemberId);

        public void SaveMember(Member Member) => MemberDAO.SaveMember(Member);

        public List<Member> Search(string keyword) => MemberDAO.Search(keyword);

        public void UpdateMember(Member Member) => MemberDAO.UpdateMember(Member);
    }
}
