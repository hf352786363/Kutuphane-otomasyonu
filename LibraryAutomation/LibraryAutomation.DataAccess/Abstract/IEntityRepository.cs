using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.DataAccess.Concrete.EntityFramework;
using LibraryAutomation.Entity.Abstract;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomation.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<string> GetBookLanguage();
        IEnumerable<string> GetBookPublisher();
        IEnumerable<string> GetBookAuthor();
        IEnumerable<string> GetBookName();

    }
}
