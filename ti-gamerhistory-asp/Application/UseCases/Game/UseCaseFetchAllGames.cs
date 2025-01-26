using Application.UseCases.Game.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Game;

public class UseCaseFetchAllGames : IUseCaseQuery<IEnumerable<DtoOutputGame>>
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchAllGames(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public IEnumerable<DtoOutputGame> Execute()
    {
        var games = _gameRepository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputGame>>(games);
    }
}