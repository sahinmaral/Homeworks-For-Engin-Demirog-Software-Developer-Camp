﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Business.Abstract;
using Business.Constants;

using Core.Utilities.Results;

using DataAccess.Abstract;

using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {

            if (DateTime.Now.Hour == 0)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>( _userDal.GetAll());
        }

        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_userDal.Get(filter), Messages.UserRetrieved);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.UserId == userId));
        }

        public IResult Insert(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
    }
}
