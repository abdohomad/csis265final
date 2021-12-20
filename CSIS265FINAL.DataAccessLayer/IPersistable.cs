using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIS265FINAL.DataAccessLayer
{
   public interface IPersistable
    {
        object Insert(object car);
        object SelectOneObject(object car);
        IList<object> SelectManyObject(object car);
        object Update(object car);
        object Delete(object car);
    }
}
