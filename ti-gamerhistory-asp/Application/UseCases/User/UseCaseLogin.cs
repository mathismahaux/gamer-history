using Application.Services;
using Application.UseCases.User.Dtos;
using Domain;
using Infrastructure.Ef;

namespace Application.UseCases.User;

public class UseCaseLogin
{
    private readonly IUserRepository _userRepository;
    private readonly ISessionRepository _sessionRepository;
    private readonly TokenService _tokenService;

    public UseCaseLogin(IUserRepository userRepository, ISessionRepository sessionRepository, TokenService tokenService)
    {
        _userRepository = userRepository;
        _sessionRepository = sessionRepository;
        _tokenService = tokenService;
    }

    public string Execute(DtoInputLogin dtoInputLogin)
    {
        var user = _userRepository.FetchByUsername(dtoInputLogin.Username);
        if (user == null || user.Password != dtoInputLogin.Password || user.Pseudo != dtoInputLogin.Username)
        {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        var existingSession = _sessionRepository.FetchByUserId(user.Id);
        if (existingSession != null)
        {
            throw new InvalidOperationException("User already has an active session.");
        }

        var session = new Session
        {
            UserId = user.Id,
            StartTime = DateTime.UtcNow
        };
        _sessionRepository.Create(session.UserId, session.StartTime);

        return _tokenService.GenerateToken(user.Id, user.Pseudo, user.Role);
    }
}