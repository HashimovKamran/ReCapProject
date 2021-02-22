using Business.Abstract;
using Business.Constants;
using Core.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length > 2 && user.LastName.Length > 2)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.IsInvalid);
            }
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == Id));
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length > 2 && user.LastName.Length > 2)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.IsInvalid);
            }
        }
    }
}
