using Core.Utilities.Results;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICarService:IServiceBase<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
