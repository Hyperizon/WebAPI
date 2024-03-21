using Azure.Core;
using Core.Entities.Concretes;
using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IAuthService
{
    IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
    IDataResult<User> Login(UserForLoginDto userForLoginDto);

    IResult userExists(string email);
    IDataResult<AccessToken> CreateAccessToken(User user);
}
