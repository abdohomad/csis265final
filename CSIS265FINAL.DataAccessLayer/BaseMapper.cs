using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIS265FINAL.DataAccessLayer
{
    public abstract class BaseMapper
    {
       
            protected log4net.ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            protected SqlDataReader rdr;
            public BaseMapper(SqlDataReader rdr)
            {
                this.rdr = rdr;
            }

            public abstract object DoMapping();

            public int GetValidInt(string columName)
            {

                try
                {
                    return Convert.ToInt32(rdr[columName.ToString()]);
                }
                catch (Exception ex)
                {
                    logger.Error($"{columName} had invalid data {ex.Message}");
                    return -1;

                }

            }

            public double GetValidDouble(string columName)
            {

                try
                {
                    return Convert.ToDouble(rdr[columName.ToString()]);
                }
                catch (Exception ex)
                {
                    logger.Error($"{columName} had invalid data {ex.Message}");
                    return -1;

                }

            }

            public bool GetValidBool(string columName)
            {

                try
                {
                    return Convert.ToBoolean(rdr[columName.ToString()]);
                }
                catch (Exception ex)
                {
                    logger.Error($"{columName} had invalid data {ex.Message}");
                    return false;

                }

            }

            public string GetValidString(string columName)
            {

                try
                {
                    return rdr[columName].ToString();
                }
                catch (Exception ex)
                {
                    logger.Error($"{columName} had invalid data {ex.Message}");
                    return string.Empty;

                }

            }

        }
}
