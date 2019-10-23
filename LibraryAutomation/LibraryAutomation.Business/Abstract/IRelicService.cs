using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomation.Business.Abstract
{
    public interface IRelicService
    {
        List<Relic> GetAll();
        void Add(Relic relic);
    }
}
