﻿using Core.DataAccess;
using Core.Entities.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts;

public interface IUserDal:IEntityRepository<User>
{
    List<OperationClaim> GetClaims(User user);
}
