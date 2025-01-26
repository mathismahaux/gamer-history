using Infrastructure.Ef;

namespace Application.UseCases.User;

public class UseCaseLogout
{
    private readonly ISessionRepository _sessionRepository;

    public UseCaseLogout(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public bool Execute(int userId)
    {
        var session = _sessionRepository.FetchByUserId(userId);
        if (session == null)
        {
            throw new ArgumentException("Session not found.");
        }

        return _sessionRepository.Delete(session.Id);
    }
}