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
    public class UserTest
    {
        UserRepo uRepo;
        USER userA;

        [TestInitialize]
        public void setup()
        {

            uRepo = new UserRepo();
            userA = new USER
            {
                USER_ID = 1,
                USER_FNAME = "Ermin",
                USER_LNAME = "Avdagic",
                USER_DISPLAYNAME = "Me",
                USER_EMAIL = "eavdagic@gmail.com",
                PASSWORD = "ermin",
                REPUTATION = 1,
                CREATED_TIMESTAMP = DateTime.Now
            };
            uRepo.add(userA);

            uRepo.add(new USER
            {
                USER_ID = 2,
                USER_FNAME = "Jon",
                USER_LNAME = "Smith",
                USER_EMAIL = "jon@gmail.com",
                USER_DISPLAYNAME = "JonSmith",
                REPUTATION = 5,
                PASSWORD = "jon",
                CREATED_TIMESTAMP = DateTime.Now
            });

        }

        [TestMethod]
        public void userGetByID()
        {
            USER userB = uRepo.getById(new USER { USER_ID = 1 });
            Assert.AreEqual(userA.USER_FNAME, userB.USER_FNAME);
            Assert.AreEqual(userA.USER_LNAME, userB.USER_LNAME);
        }

        [TestMethod]
        public void userGetAll()
        {
            USER[] usersA = uRepo.getAll();
            Assert.AreEqual(true, usersA.Length > 0);

            uRepo.add(new USER
            {
                USER_ID = 3,
                USER_FNAME = "Sara",
                USER_LNAME = "Johnson",
                USER_DISPLAYNAME = "SaraJ",
                USER_EMAIL = "sara@gmail.com",
                REPUTATION = 10,
                CREATED_TIMESTAMP = DateTime.Now,
                PASSWORD = "sara"
            });

            uRepo.add(new USER
            {
                USER_ID = 4,
                USER_FNAME = "Joe",
                USER_LNAME = "Franklin",
                USER_DISPLAYNAME = "JoeFrank",
                USER_EMAIL = "JFrank@gmail.com",
                REPUTATION = 90,
                CREATED_TIMESTAMP = DateTime.Now,
                PASSWORD = "joe"
            });

            USER[] usersB = uRepo.getAll();
            Assert.AreEqual(true, usersB.Length > usersA.Length);
        }

        /*[TestCleanup]
        public void cleanUp()
        {
            IQueryable<USER> users = uRepo.query(a => a.USER_ID == 1 || a.USER_ID == 2 || a.USER_ID == 3 || a.USER_ID == 4);
            foreach (USER user in users)
            {
                uRepo.remove(user);
            }
        }*/

        [TestCleanup]
        public void cleanUp()
        {
            USER user;

            user = uRepo.getById(new USER { USER_ID = 1 });
            if (user != null)
                uRepo.remove(user);
            user = uRepo.getById(new USER { USER_ID = 1 });
            Assert.AreEqual(null, user);

            user = uRepo.getById(new USER { USER_ID = 2 });
            if (user != null)
                uRepo.remove(user);
            user = uRepo.getById(new USER { USER_ID = 2 });
            Assert.AreEqual(null, user);

            user = uRepo.getById(new USER { USER_ID = 3 });
            if (user != null)
                uRepo.remove(user);
            user = uRepo.getById(new USER { USER_ID = 3 });
            Assert.AreEqual(null, user);

            user = uRepo.getById(new USER { USER_ID = 4 });
            if (user != null)
                uRepo.remove(user);
            user = uRepo.getById(new USER { USER_ID = 4 });
            Assert.AreEqual(null, user);

        }
    }
}
