﻿using DataAccess.Abstract;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarContext context = new CarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                             join br in context.Brands on car.BrandId equals br.BrandId
                             join co in context.Colours on car.ColourId equals co.ColourId
                             select new CarDetailDto
                             {
                                 BrandName = br.BrandName,
                                 ColourName = co.ColourName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                             };
                return result.ToList();

            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                return filter == null ?
                    context.Set<Car>().ToList() :
                    context.Set<Car>().Where(filter).ToList();
            }
        }


        public void Update(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
