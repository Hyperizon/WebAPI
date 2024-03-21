using Core.DataAccess.EntityFramework;
using Core.Entities.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, NortwindContext>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using (var ctx = new NortwindContext())
        {
            var result = from OperationClaim in ctx.OperationClaims
                         join UserOperationClaim in ctx.UserOperationClaims
                         on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                         where UserOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };

            return result.ToList();
        }
    }
}
