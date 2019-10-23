using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.DataAccess.Abstract;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomation.DataAccess.Concrete.EntityFramework
{
    public class EfRelicDal : EfEntityRepositoryBase<Relic, LibraryContext>, IRelicDal
    {
    }
}
