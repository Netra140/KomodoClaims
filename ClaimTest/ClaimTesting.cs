using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Repository;

namespace ClaimTest
{
    [TestClass]
    public class ClaimTesting
    {
        [TestMethod]
        public void AddTest()
        {
            ClaimRepo repository = new ClaimRepo();
            //Arrange
            repository._claims = new List<ClaimPoco>() { new ClaimPoco(1, "Car", "Highway wreck by drunk driver", 200.00, new DateTime(2019, 3, 12), new DateTime(2019, 3, 31)) };
            //Act
            repository.AddClaim(new ClaimPoco(2, "Home", "Housefire by arson", 10000.00, new DateTime(2020, 11, 15), new DateTime(2021, 6, 5)));
            //Assert
            Assert.AreEqual(2, repository._claims.Count);
        }
        [TestMethod]
        public void RemoveTest() {
            ClaimRepo repository = new ClaimRepo();

            repository._claims = new List<ClaimPoco>() { new ClaimPoco(1, "Car", "Highway wreck by drunk driver", 200.00, new DateTime(2019, 3, 12), new DateTime(2019, 3, 31)), new ClaimPoco(2, "Home", "Housefire by arson", 10000.00, new DateTime(2020, 11, 15), new DateTime(2021, 6, 5)) };

            repository.RemoveClaim();

            Assert.AreEqual(1, repository._claims.Count);
        }
        [TestMethod]
        public void GetNextTest()
        {
            ClaimRepo repository = new ClaimRepo();
            repository._claims = new List<ClaimPoco>() { new ClaimPoco(1, "Car", "Highway wreck by drunk driver", 200.00, new DateTime(2019, 3, 12), new DateTime(2019, 3, 31)), new ClaimPoco(2, "Home", "Housefire by arson", 10000.00, new DateTime(2020, 11, 15), new DateTime(2021, 6, 5)) };
            ClaimPoco result = repository.GetNextPoco();
            Assert.AreEqual(1, result.ClaimID);
        }
        [TestMethod]
        public void ListTest()
        {
            ClaimRepo repository = new ClaimRepo();
            repository._claims = new List<ClaimPoco>() { new ClaimPoco(1, "Car", "Highway wreck by drunk driver", 200.00, new DateTime(2019, 3, 12), new DateTime(2019, 3, 31)), new ClaimPoco(2, "Home", "Housefire by arson", 10000.00, new DateTime(2020, 11, 15), new DateTime(2021, 6, 5)) };
            List<ClaimPoco> result = repository.GetList();
            Assert.AreEqual(2,result.Count);
            
        }
    }
}
