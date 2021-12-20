using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Configuration;
using System.Data.SqlClient;

namespace CSIS265FINAL.DataAccessLayer
{
    public abstract class BaseDao
    {

        protected static readonly ILog logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected static readonly string DEFAULT_CONNECTION_KEY = "localhost";
        

        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataAdapter adpt;
        protected SqlDataReader rdr;
        protected string connectionString;
        protected string sql;



        public BaseDao()
        {
          SetConnectionString(DEFAULT_CONNECTION_KEY);

        }
        public BaseDao(string connectionKey)
        {
            SetConnectionString(connectionKey);

        }

        public void SetConnectionString(string connectionKey)
        {
            if (connectionKey.Trim().Length == 0)
            {
                throw new DALException("DAL connection key must not be blank");
            }
            try
            {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionKey].ToString();
               
            }
            catch (Exception exception)
            {
                logger.Error(exception.Message);
                throw new DALException("The DAL connection key does not exist in the config file");
            }
            if (connectionString.Trim().Length == 0)
            {
                throw new DALException("DAL connection string must not be blank");
            }

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
                conn.Dispose();
                logger.Debug("database is connected");


            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DALException("cannot connect to the database");

            }
        }

        public void Cleanup()
        {
            if (rdr != null)
            {
                rdr.Close();

            }

            if (cmd != null)
            {
                cmd.Dispose();
            }
            if (adpt != null)
            {
                adpt.Dispose();
            }
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }

}
