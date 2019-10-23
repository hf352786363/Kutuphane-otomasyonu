using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.Entity.Abstract;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomation.DataAccess.Abstract
{
    public interface IRelicDal:IEntityRepository<Relic>
    {
    }
}
