using CSIS265FINAL.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIS265FINAL.UnitTests
{
    [TestClass]
    public class CarUnitTests
    {
        [TestMethod]
        public void CarTestNotNull()
        {
            Car temp = new Car();
            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void CarTestPropertyId()
        {
            Car temp = new Car
            {
                Id = 42
            };
            Assert.AreEqual(42, temp.Id);
        }


        [TestMethod]
        public void CarTestToString()
        {
            Car temp = new Car(20, "", "", "black", 730.75, 50);

            Assert.IsTrue(temp.ToString().Length > 0);
            Assert.IsTrue(temp.ToString().Contains("b"));
        }

    }
}
