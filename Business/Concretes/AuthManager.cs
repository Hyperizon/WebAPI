using Business.Abstracts;
using Business.Constants;
using Core.Entities.Concretes;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private IUserService _userService;
    private ITokenHelper _tokenHelper;
    public AuthManager(IUserService userService, ITokenHelper tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;

    }

    public IDataResult<User> Login(UserForLoginDto userForLoginDto)
    {
        var userToCheck = _userService.GetByMail(userForLoginDto.Email);
        if (userToCheck is null)
        {
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }

        if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            return new ErrorDataResult<User>(Messages.PasswordError);
        }

        return new SuccsessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
    }

    public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
        var user = new User { 
            Email = userForRegisterDto.Email, 
            FirstName = userForRegisterDto.FirstName, 
            LastName = userForRegisterDto.LastName, 
            PasswordHash = passwordHash, 
            PasswordSalt=passwordSalt, 
            Status = true
        };
        _userService.Add(user);
        return new SuccsessDataResult<User>(user, Messages.UserRegistered);
    }

    public IResult UserExists(string email)
    {
        if (_userService.GetByMail(email) != null)
        {
            return new ErrorResult(Messages.UserAlreadyExists);
        }
        return new SuccsessResult();
    }

    public IDataResult<AccessToken> CreateAccessToken(User user)
    {
        var claims = _userService.GetClaims(user);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccsessDataResult<AccessToken>(accessToken, "Access token created!");
    }
}
