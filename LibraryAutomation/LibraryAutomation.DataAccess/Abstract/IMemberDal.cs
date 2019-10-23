using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomation.DataAccess.Abstract
{
    public interface IMemberDal:IEntityRepository<Member>
    {
    }
}
