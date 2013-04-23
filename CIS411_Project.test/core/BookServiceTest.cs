using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CIS411_Project.Core.Models;
using CIS411_Project.Core.Services;
using CIS411_Project.dal.Repositories;
using CIS411_Project.dal;

namespace CIS411_Project.test.core
{
    [TestClass]
    public class BookServiceTest
    {
        IService bookService;

        [TestInitialize]
        void bookSetup()
        {
            bookService = new BookService();

            User user = new User 
            { USER_FNAME = "Cory", 
              USER_LNAME = "Jenkings", 
              PASSWORD = "cory", 
              EMAIL = "cory@gmail.com", 
              USER_DISPLAYNAME = "C.J", 
              CREATED_TIMESTAMP = DateTime.Now, 
              REPUTATION = 509 };


        }

        [TestMethod]
        public void simpleBookServiceTest()
        {
            IService service = new BookService();
            ICollection<Books> books = service.listBooksByUser(1);
            //bool hasBooks = false;
            foreach (Books book in books)
            {
                //hasBooks = true;
                Assert.AreEqual(1, book.USER_ID);

            }
        }
    }
}
