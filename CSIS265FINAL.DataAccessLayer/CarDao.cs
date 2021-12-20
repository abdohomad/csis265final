using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace CSIS265FINAL.DataAccessLayer
{
    public class CarDao : BaseDao, IPersistable
    {
        private log4net.ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected string insertOneSql = "INSERT INTO CAR (MAKE, MODEL, COLOR, WEIGHT, MPG) VALUES (@makeParm, @modelParm, @colorParm, @wgtParm, @mpgParm) SELECT SCOPE_IDENTITY();";
        protected string selectOneSql = "SELECT ID,MAKE, MODEL, COLOR, WEIGHT, MPG FROM CAR WHERE ID = @idParm; ";
        protected string selectManySql = "SELECT ID, MAKE, MODEL, COLOR, WEIGHT, MPG FROM CAR WHERE MAKE LIKE @makeParm;";
        protected string updateOneSql = "UPDATE CAR SET MAKE = @makeParm, MODEL = @modelParm , COLOR = @colorParm, WEIGHT = @wgtParm, MPG = @mpgParm WHERE ID = @idParm;";
        protected string deleteOneSql = "DELETE  FROM CAR WHERE ID = @idParm; ";


        public CarDao() : base()
        {
            logger.Debug("INSIDE CAR DEFAULT CONSTRUCTOR");
        }

        public CarDao(string connectionString) : base(connectionString)
        {
            logger.Debug("INSIDE CAR 1-ARG CONSTRUCTOR");
        }

        public object SelectOneObject(object car)
        {
            try
            {
                Car myFilter = (Car)car;
                Car rtnObj = null;

                conn = new SqlConnection(connectionString);
                conn.Open();

                sql = selectOneSql;

                cmd = new SqlCommand(sql, conn);

                SqlParameter idParm = new SqlParameter();
                idParm.ParameterName = "@idParm";
                idParm.Value = myFilter.Id;

                cmd.Parameters.Add(idParm);

                rdr = cmd.ExecuteReader();
                CarMapper mapper = new CarMapper(rdr);
                while (rdr.Read())
                {
                    rtnObj = (Car)mapper.DoMapping();
                }
                return rtnObj;
            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DALException("Could not read CAR table");
            }
            finally
            {
                Cleanup();
            }


        }


        public object Insert(object car)
        {
            try
            {
                Car rtnObj = (Car)car;
                int id = 0;

                conn = new SqlConnection(connectionString);
                conn.Open();
                sql = insertOneSql;

                adpt = new SqlDataAdapter();

                SqlParameter makeParm = new SqlParameter
                {
                    ParameterName = "@makeParm",
                    Value = rtnObj.Make
                };

                SqlParameter modelParm = new SqlParameter
                {
                    ParameterName = "@modelParm",
                    Value = rtnObj.Model
                };

                SqlParameter colorParm = new SqlParameter
                {
                    ParameterName = "@colorParm",
                    Value = rtnObj.Color
                };

                SqlParameter wgtparm = new SqlParameter
                {
                    ParameterName = "@wgtParm",
                    Value = rtnObj.Weight
                };

                SqlParameter mpgParm = new SqlParameter
                {
                    ParameterName = "@mpgParm",
                    Value = rtnObj.Mpg
                };


                adpt.InsertCommand = new SqlCommand(sql, conn);
                adpt.InsertCommand.Parameters.Add(makeParm);
                adpt.InsertCommand.Parameters.Add(modelParm);
                adpt.InsertCommand.Parameters.Add(colorParm);
                adpt.InsertCommand.Parameters.Add(wgtparm);
                adpt.InsertCommand.Parameters.Add(mpgParm);


                id = Convert.ToInt32(adpt.InsertCommand.ExecuteScalar());
                rtnObj.Id = id;
                logger.Debug($"{rtnObj} was added to the database");
                
                return rtnObj;
            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
                throw ex;

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DALException("Could not insert the car into the database");
            }
            finally
            {
                Cleanup();
                
            }
        }

        public IList<object> SelectManyObject(object car)
        {
            try
            {
                IList<object> objList = new List<object>();
                Car myCar = (Car)car;
                Car rtnObj = null;

                conn = new SqlConnection(connectionString);
                conn.Open();

                sql = selectManySql;

                cmd = new SqlCommand(sql, conn);

                SqlParameter makeParm = new SqlParameter();
                makeParm.ParameterName = "@makeParm";
                makeParm.Value = '%' + myCar.Make + '%';

                cmd.Parameters.Add(makeParm);

                rdr = cmd.ExecuteReader();
                CarMapper mapper = new CarMapper(rdr);

                while (rdr.Read())
                {
                    rtnObj = (Car)mapper.DoMapping();
                    objList.Add(rtnObj);
                }
                return objList;
            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DALException("Could not read Car table");
            }
            finally
            {
                Cleanup();
            }
        }

       public object Delete(object car)
       {
            try
            {
                Car rtnObj = (Car)car;

                conn = new SqlConnection(connectionString);
                conn.Open();

                sql = deleteOneSql;

                adpt = new SqlDataAdapter();

                SqlParameter idParm = new SqlParameter
                {
                    ParameterName = "@idParm",
                    Value = rtnObj.Id
                };

                adpt.DeleteCommand = new SqlCommand(sql, conn);
                adpt.DeleteCommand.Parameters.Add(idParm);

                adpt.DeleteCommand.ExecuteScalar();
                return rtnObj;
            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DALException("Could not update the car in the database");
            }
            finally
            {
                Cleanup();
            }
        }

        public object Update(object car)
        {
            try
            {
                Car rtnObj = (Car)car;

                conn = new SqlConnection(connectionString);
                conn.Open();

                sql = updateOneSql;

                adpt = new SqlDataAdapter();
                
                SqlParameter makeParm = new SqlParameter
                {
                    ParameterName = "@makeParm",
                    Value = rtnObj.Make
                };

                SqlParameter modelParm = new SqlParameter
                {
                    ParameterName = "@modelParm",
                    Value = rtnObj.Model
                };

                SqlParameter colorParm = new SqlParameter
                {
                    ParameterName = "@colorParm",
                    Value = rtnObj.Color
                };

                SqlParameter wgtParm = new SqlParameter
                {
                    ParameterName = "@wgtParm",
                    
                    Value = rtnObj.Weight
                };

                SqlParameter mpgParm = new SqlParameter
                {
                    ParameterName = "@mpgParm",
                    Value = rtnObj.Mpg
                };

                SqlParameter idParm = new SqlParameter
                {
                    ParameterName = "@idParm",
                    Value = rtnObj.Id
                };

                adpt.UpdateCommand = new SqlCommand(sql, conn);
                adpt.UpdateCommand.Parameters.Add(makeParm);
                adpt.UpdateCommand.Parameters.Add(modelParm);
                adpt.UpdateCommand.Parameters.Add(colorParm);
                adpt.UpdateCommand.Parameters.Add(wgtParm);
                adpt.UpdateCommand.Parameters.Add(mpgParm);

                adpt.UpdateCommand.Parameters.Add(idParm);

                adpt.UpdateCommand.ExecuteScalar();

                return rtnObj;
            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DALException("Could not update the car in the database");
            }
            finally
            {
                Cleanup();
            }
        }

    }

}
