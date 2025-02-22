﻿using Entities.Concrete;
using Entities.DTOs;

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        public List<CarDetailDto> GetCarDetailDtos();
    }
}
