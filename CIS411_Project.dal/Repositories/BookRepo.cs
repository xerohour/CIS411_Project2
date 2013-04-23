using Repository.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace CIS411_Project.dal.Repositories
{
    public class BookRepo : IRepository<BOOK>
    {
        private BooksDBEntities _context = null;

        public BookRepo()
        {
            _context = new BooksDBEntities();
        }
        public BOOK getById(BOOK object2add)
        {
            return _context.BOOKs.Find(object2add.BOOK_ID);
        }

        public BOOK[] getAll()
        {
            return _context.BOOKs.ToArray();
        }

        public void add(BOOK book2add)
        {
            _context.BOOKs.Add(book2add);
            _context.SaveChanges();
        }

        public void update(BOOK book2update)
        {
            _context.Entry(book2update).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void remove(BOOK book2remove)
        {
            _context.BOOKs.Remove(book2remove);
            _context.SaveChanges();
        }

        public IQueryable<BOOK> query(System.Linq.Expressions.Expression<Func<BOOK, bool>> filter)
        {
            return _context.BOOKs.Where(filter);
        }
    }
}
