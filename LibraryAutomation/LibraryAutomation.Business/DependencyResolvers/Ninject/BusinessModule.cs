using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.Business.Abstract;
using LibraryAutomation.Business.Concrete;
using LibraryAutomation.DataAccess.Abstract;
using LibraryAutomation.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace LibraryAutomation.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService>().To<BookManager>().InSingletonScope();
            Bind<IBookDal>().To<EfBookDal>().InSingletonScope();

            Bind<IRelicService>().To<RelicManager>().InSingletonScope();
            Bind<IRelicDal>().To<EfRelicDal>().InSingletonScope();

            Bind<IMemberService>().To<MemberManager>().InSingletonScope();
            Bind<IMemberDal>().To<EfMemberDal>().InSingletonScope();


        }
    }
}
