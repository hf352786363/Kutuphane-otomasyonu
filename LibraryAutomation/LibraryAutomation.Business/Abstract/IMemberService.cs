using LibraryAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Business.Abstract
{
    public interface IMemberService
    {
        List<Member> GetAll();
        void Add(Member member);
        void Update(Member member);
        void Delete(Member member);
    }
}
