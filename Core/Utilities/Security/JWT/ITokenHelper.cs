using Core.Entities.Concrete;
using Core.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaimDetailDto> operationClaims);
    }
}