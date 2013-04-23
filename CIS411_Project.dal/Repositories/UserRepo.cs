using Repository.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS411_Project.dal.Repositories
{
    public class UserRepo : IRepository<USER>
    {
        private BooksDBEntities _context = null;

        public UserRepo()
        {
            _context = new BooksDBEntities();
        }
        public USER getById(USER object2add)
        {
            return _context.USERs.Find(object2add.USER_ID);
        }

        public USER[] getAll()
        {
            return _context.USERs.ToArray();
        }

        public void add(USER USER2add)
        {
            _context.USERs.Add(USER2add);
            _context.SaveChanges();
        }

        public void update(USER USER2update)
        {
            _context.Entry(USER2update).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void remove(USER USER2remove)
        {
            _context.USERs.Remove(USER2remove);
            _context.SaveChanges();
        }

        public IQueryable<USER> query(System.Linq.Expressions.Expression<Func<USER, bool>> filter)
        {
            return _context.USERs.Where(filter);
        }
    }
}
