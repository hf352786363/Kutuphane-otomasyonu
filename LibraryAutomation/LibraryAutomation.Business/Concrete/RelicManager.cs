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
    public class RelicManager : IRelicService
    {
        private IRelicDal _relicDal;

        public RelicManager(IRelicDal relicDal)
        {
            _relicDal = relicDal;
        }

        public List<Relic> GetAll()
        {
            return _relicDal.GetAll();
        }

        public void Add(Relic relic)
        {
            _relicDal.Add(relic);
        }
    }
}
