﻿using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImplRepo
{
    public class MemberRepository : IMemberRepository
    {
        void IMemberRepository.DeleteMember(Member member) => MemberDAO.DeleteMember(member);


        Member IMemberRepository.GetMemberByEmail(string email) => MemberDAO.FindMemberByEmail(email);


        Member IMemberRepository.GetMemberById(string id) => MemberDAO.FindMemberById(id);

        List<Member> IMemberRepository.GetMembers() => MemberDAO.GetMembers();


        List<Order> IMemberRepository.GetOrders(string MemberId) => OrdersDAO.FindAllOrdersByMemberId(MemberId);


        void IMemberRepository.SaveMember(Member member) => MemberDAO.SaveMember(member);


        List<Member> IMemberRepository.Search(string keyword) => MemberDAO.Search(keyword);


        void IMemberRepository.UpdateMember(Member member) => MemberDAO.UpdateMember(member);

    }
}
