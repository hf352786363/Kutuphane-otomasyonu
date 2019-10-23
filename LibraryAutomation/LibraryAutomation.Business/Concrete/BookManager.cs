using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.Business.Abstract;
using LibraryAutomation.DataAccess.Abstract;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomation.Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public IEnumerable<string> GetBookLanguage()
        {
            return _bookDal.GetBookLanguage();
        }

        public IEnumerable<string> GetBookPublisher()
        {
            return _bookDal.GetBookPublisher();
        }

        public IEnumerable<string> GetBookAuthor()
        {
            return _bookDal.GetBookAuthor();
        }

        public IEnumerable<string> GetBookName()
        {
            return _bookDal.GetBookName();
        }

        public void Add(Book book)
        {
            _bookDal.Add(book);
        }

        public void Update(Book book)
        {
            _bookDal.Update(book);
        }

        public void Delete(Book book)
        {
            _bookDal.Delete(book);
        }
    }
}
