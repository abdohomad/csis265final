using System;
using System.Collections.Generic;
using CSIS265FINAL.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSIS265FINAL.UnitTests
{
    [TestClass]
    public class CarDaoUnitTests
    {
        private string connectionString
            = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\vsprojects\\CSIS265FINAL\\CSIS265FINAL\\App_Data\\Csis265final.mdf;Integrated Security=True";

        private string connectionKey = "localhost";


        public void TestCarDaoNotNullConnKeyPassed()
        {
            try
            {
                CarDao dao = new CarDao(connectionKey);
                Assert.IsNotNull(dao);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCarDaoNotNullDefaultConnKey()
        {
            try
            {
                CarDao dao = new CarDao();
                Assert.IsNotNull(dao);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }



        [TestMethod]
        public void TestCarDaoSelectOne()
        {
            try
            {
                CarDao dao = new CarDao();
                Car filter = new Car(15, "", "", "", -1.1, -3);
                Car rtnObj = (Car)dao.SelectOneObject(filter);
                Assert.IsNotNull(rtnObj);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }


        [TestMethod]
        public void TestCarDaoInsertOne()
        {
            try
            {
                CarDao dao = new CarDao();
                Car obj = new Car(-1, "toyota", "avalon", "black", 334, 21);
                Car rtnObj = (Car)dao.Insert(obj);
                Assert.IsTrue(rtnObj.Id > 0);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }


        [TestMethod]
        public void TestCarDaoUpdateAndSelectOne()
        {
            try
            {
                CarDao dao = new CarDao();
                Car filter = new Car(44, "toyota", "camry", "pink", 527.00, 1);
                Car rtnObj = (Car)dao.Update(filter);

              filter = new Car(44, "", "", "", -3.14, -1);
              rtnObj = (Car)dao.SelectOneObject(filter);

                Assert.IsTrue(rtnObj.Make.Contains("o"));
                Assert.IsTrue(rtnObj.Model.Contains("m"));
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
              
            }
        }



        [TestMethod]
        public void TestCarDaoDeleteAndSelectOne()
        {
            try
            {
                CarDao dao = new CarDao();
                Car filter = new Car(11, "", "","", -1.001, -3);
                dao.Delete(filter);

                filter = new Car(11, "", "", "", -1.001, -3);
                Car rtnObj = (Car)dao.SelectOneObject(filter);

                Assert.IsNull(rtnObj);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCarDaoSelectMany()
        {
            try
            {
                CarDao dao = new CarDao();
                Car filter = new Car(2, "", "", "", -223.3, -45);



                IList<object> objList = (IList<object>)dao.SelectManyObject(filter);
                Assert.IsNotNull(objList);
                Assert.IsTrue(objList.Count > 0);
            }
            catch (DALException ex)
            {
                System.Console.WriteLine(ex.Message);
                Assert.IsTrue(false);
            }
        }



    }
}
