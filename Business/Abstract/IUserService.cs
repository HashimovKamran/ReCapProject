using Core.Result;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> GetById(int Id);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByMail(string email);
        IDataResult<List<OperationClaimDetailDto>> GetClaims(User user);
    }
}