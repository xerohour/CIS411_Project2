using Microsoft.VisualStudio.TestTools.UnitTesting;
using CIS411_Project.dal;
using CIS411_Project.dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CIS411_Project.test.dal
{
    [TestClass]
    public class BookTest
    {
        BookRepo bRepo;
        BOOK bookA;


        [TestInitialize]
        public void setup()
        {
            bRepo = new BookRepo();
            bookA = new BOOK
            {
                BOOK_ID = 1,
                BOOK_TITLE = "derp",
                BOOK_DESC = "book",
                BOOK_AUTHOR = "jesus",
                BOOK_EDITION = 1,
                BOOK_PUBLISHER = "god",
                ISBN10 = 123,
                ISBN13 = 13,
                CONDITION_ID = 10,
                CATEGORY_ID = 1,
                BOOK_PRICE = 5.99,
                CREATED_TIMESTAMP = DateTime.Now
            };

            bRepo.add(bookA);
        }
        [TestMethod]
        public void bookTitle()
        {
            Assert.AreEqual(bookA.BOOK_TITLE, "derp");
        }


        [TestCleanup]
        public void cleanUp()
        {
            BOOK book;
            book = bRepo.getById(new BOOK { BOOK_ID = 2 });
            if (book != null)
                bRepo.remove(book);
        }


    }
}