using Repository.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS411_Project.dal.Repositories
{
    public class ConditionRepo : IRepository<CONDITION>
    {
        private BooksDBEntities _context = null;

        public ConditionRepo()
        {
            _context = new BooksDBEntities();
        }
        public CONDITION getById(CONDITION object2add)
        {
            return _context.CONDITIONs.Find(object2add.CONDITION_ID);
        }

        public CONDITION[] getAll()
        {
            return _context.CONDITIONs.ToArray();
        }

        public void add(CONDITION CONDITION2add)
        {
            _context.CONDITIONs.Add(CONDITION2add);
            _context.SaveChanges();
        }

        public void update(CONDITION CONDITION2update)
        {
            _context.Entry(CONDITION2update).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void remove(CONDITION CONDITION2remove)
        {
            _context.CONDITIONs.Remove(CONDITION2remove);
            _context.SaveChanges();
        }

        public IQueryable<CONDITION> query(System.Linq.Expressions.Expression<Func<CONDITION, bool>> filter)
        {
            return _context.CONDITIONs.Where(filter);
        }
    }
}
