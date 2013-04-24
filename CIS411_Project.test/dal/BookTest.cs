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

        [TestInitialize]
        public void setup()
        {
            bRepo = new BookRepo();
         
            bRepo.add(new BOOK
            {   USER_ID=333,
                CATEGORY_ID=1,
                BOOK_AUTHOR="Yoooo",
                BOOK_DESC="Mario",
                BOOK_EDITION=10,
                BOOK_PRICE=20,
                BOOK_PUBLISHER="KOKO",
                BOOK_TITLE="Mario and Luigi",
                ISBN10=12345678910,
                ISBN13=12345678910111,
                CREATED_TIMESTAMP=DateTime.Now,
                CONDITION_ID=1
            });

        }
        [TestMethod]
        public void bookTitle()
        {
            BOOK b00k = bRepo.getById(new BOOK { BOOK_ID = 58 });
            BOOK b00k2 = bRepo.getById(new BOOK {BOOK_ID = 59});
            Assert.AreNotEqual(b00k.BOOK_TITLE, b00k2.BOOK_TITLE);
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