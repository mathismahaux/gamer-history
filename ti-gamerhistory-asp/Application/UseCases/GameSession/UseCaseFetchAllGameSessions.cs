using Application.UseCases.GameSession.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.GameSession;

public class UseCaseFetchAllGameSessions: IUseCaseQuery<IEnumerable<DtoOutputGameSession>>
{
    private readonly IGameSessionRepository _gameSessionRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchAllGameSessions(IGameSessionRepository gameSessionRepository, IMapper mapper)
    {
        _gameSessionRepository = gameSessionRepository;
        _mapper = mapper;
    }

    public IEnumerable<DtoOutputGameSession> Execute()
    {
        var gameSessions = _gameSessionRepository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputGameSession>>(gameSessions);
    }
}