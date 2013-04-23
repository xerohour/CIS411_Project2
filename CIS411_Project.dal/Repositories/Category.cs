using Repository.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS411_Project.dal.Repositories
{
    public class CategoryRepo : IRepository<CATEGORY>
    {
        private BooksDBEntities _context = null;

        public CategoryRepo()
        {
            _context = new BooksDBEntities();
        }
        public CATEGORY getById(CATEGORY object2add)
        {
            return _context.CATEGORies.Find(object2add.CATEGORY_ID);
        }

        public CATEGORY[] getAll()
        {
            return _context.CATEGORies.ToArray();
        }

        public void add(CATEGORY CATEGORY2add)
        {
            _context.CATEGORies.Add(CATEGORY2add);
            _context.SaveChanges();
        }

        public void update(CATEGORY CATEGORY2update)
        {
            _context.Entry(CATEGORY2update).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void remove(CATEGORY CATEGORY2remove)
        {
            _context.CATEGORies.Remove(CATEGORY2remove);
            _context.SaveChanges();
        }

        public IQueryable<CATEGORY> query(System.Linq.Expressions.Expression<Func<CATEGORY, bool>> filter)
        {
            return _context.CATEGORies.Where(filter);
        }
    }
}
