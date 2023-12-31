﻿using Microsoft.EntityFrameworkCore;
using MobileAPI.DAO;
using MobileAPI.Model;

namespace MobileAPI.Repository
{
    public class MemberRepository
    {
        private readonly MobileDataContext _mobileDBContext;

        public MemberRepository(MobileDataContext mobileDBContext)
        {
            this._mobileDBContext = mobileDBContext;
        }

        public void RegisterMember(Member member)
        {
            _mobileDBContext.Member.Add(member);
            _mobileDBContext.SaveChanges();
        }

        public void SaveOTPCodeToDatabase(int id, string otp)
        {
            var entity = _mobileDBContext.Member.Find(id);

            if (entity != null)
            {
                entity.Otp = otp;
                _mobileDBContext.SaveChanges();
            }
        }

        public PurchaseHistory GetPurchaseHistory(int id)
        {
            var entity = _mobileDBContext.PurchaseHistory.FirstOrDefault(a => a.MemberId == id);
            PurchaseHistory purchaseHistory = new PurchaseHistory();
            if (entity != null)
            {
                purchaseHistory.PurchaseId = entity.PurchaseId;
                purchaseHistory.MemberId = entity.MemberId;
                purchaseHistory.PurchaseDetails = entity.PurchaseDetails;
                purchaseHistory.Date = entity.Date;
            }
            return purchaseHistory;
        }
    }
}
