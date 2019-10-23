using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.DataAccess.Abstract;
using LibraryAutomation.Entity.Abstract;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomation.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault();

            }
        }

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IEnumerable<string> GetBookLanguage()
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Books.Select(p => p.KitapDil).Distinct().ToList();
            }
        }

        public IEnumerable<string> GetBookPublisher()
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Books.Select(p => p.KitapYayinEvi).Distinct().ToList();
            }
        }

        public IEnumerable<string> GetBookAuthor()
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Books.Select(p => p.KitapYazari).Distinct().ToList();
            }
        }

        public IEnumerable<string> GetBookName()
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Books.Select(p => p.KitapNo + p.KitapAd + "**" + p.KitapYazari + "**" + p.KitapYayinEvi + "**" + p.KitapBaskiYil + "**" + p.KitapSayfaSayi + "**" + p.KitapAciklama + "**" + p.KitapDil).Distinct().ToList();
            }
        }
    }
}
//   "SELECT * FROM Relics INNER JOIN Members ON Relics.UyeNo = Members.UyeNo INNER JOIN Books ON Books.KitapNo=Relics.KitapNo WHERE Relics.EmanetNo == EmanetNo"