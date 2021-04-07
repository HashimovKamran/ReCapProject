using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public List<OperationClaimDetailDto> GetClaims(User user)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from operationClaim in context.OperationClaims 
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaimDetailDto { Id = operationClaim.Id, UserId = userOperationClaim.UserId, OperationClaimId = userOperationClaim.OperationClaimId, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}