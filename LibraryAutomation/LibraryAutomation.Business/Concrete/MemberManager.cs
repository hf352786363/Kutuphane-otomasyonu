using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.Business.Abstract;
using LibraryAutomation.DataAccess.Abstract;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomation.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;

        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public List<Member> GetAll()
        {
            return _memberDal.GetAll();
        }

        public void Add(Member member)
        {
            _memberDal.Add(member);
        }

        public void Update(Member member)
        {
            _memberDal.Update(member);
        }

        public void Delete(Member member)
        {
            _memberDal.Delete(member);
        }
    }
}
