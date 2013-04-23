using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIS411_Project.Core.Models;

namespace CIS411_Project.Core.Services
{
    public interface IService
    {
        ICollection<Books> listBooks();
        ICollection<Books> listBooksByUser(int userId);
        Books getBookById(int bookId);
        User insertUser(User newUser);
        //ICollection<Condition> getBookCondition();
        //ICollection<Category> getBookCategory();
    }
}
