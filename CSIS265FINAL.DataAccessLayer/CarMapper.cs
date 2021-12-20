using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIS265FINAL.DataAccessLayer
{
   public class CarMapper: BaseMapper
    {
        public CarMapper(SqlDataReader rdr) : base(rdr)
        {

        }

        public override object DoMapping()
        {
            Car rtnObj = new Car
            {
                Id = GetValidInt("Id"),
                Make = GetValidString("MAKE"),
                Model = GetValidString("MODEL"),
                Color = GetValidString("COLOR"),
                Weight = GetValidDouble("WEIGHT"),
                Mpg = GetValidInt("MPG")
            };
            return rtnObj;

        }

    }
}
