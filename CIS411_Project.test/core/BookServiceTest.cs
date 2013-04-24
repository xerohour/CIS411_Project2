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
        BookRepo bRepo;
        UserRepo uRepo;
        USER userA;
        BOOK bookA;

        [TestInitialize]
        public void bookSetup()
        {
            bookService = new BookService();
            bRepo = new BookRepo();
            uRepo = new UserRepo();

            userA = new USER 
            {

              USER_FNAME = "Cory", 
              USER_LNAME = "Jenkings", 
              PASSWORD = "cory", 
              USER_EMAIL = "cory@gmail.com", 
              USER_DISPLAYNAME = "C.J", 
              CREATED_TIMESTAMP = DateTime.Now, 
              REPUTATION = 509};

            uRepo.add(userA);

            bookA = new BOOK
            {
                USER_ID=333,
                BOOK_PRICE = 20,
                BOOK_PUBLISHER = "idk",
                BOOK_TITLE = "my life",
                BOOK_AUTHOR = "Ermin",
                BOOK_EDITION = 10,
                BOOK_DESC = "A book with words and pictures",
                CREATED_TIMESTAMP = DateTime.Now,
                ISBN10 = 1111111111,
                ISBN13 = 1111111111111,
                CATEGORY_ID=1,
                CONDITION_ID=1
            };
            bRepo.add(bookA);

        }

        [TestMethod]
        public void bookServiceTest()
        {
            IService service = new BookService();
            ICollection<Books> books = service.listBooksByUser(333);
            foreach (Books book in books)
            {
                Assert.AreEqual(333, book.USER_ID);
                if (book.BOOK_TITLE == "Mario and Luigi")
                {
                    Assert.AreEqual(20, book.BOOK_PRICE);
                }
            }
        }
    }
}
