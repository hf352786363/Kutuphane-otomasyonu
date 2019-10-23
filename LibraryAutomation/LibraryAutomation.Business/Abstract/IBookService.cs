using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomation.Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        IEnumerable<string> GetBookLanguage();
        IEnumerable<string> GetBookPublisher();
        IEnumerable<string> GetBookAuthor();
        IEnumerable<string> GetBookName();
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}
