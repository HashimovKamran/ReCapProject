using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaimDetailDto> GetClaims(User user);
    }
}