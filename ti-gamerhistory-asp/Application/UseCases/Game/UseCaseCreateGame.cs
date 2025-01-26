using Application.UseCases.Game.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Game;

public class UseCaseCreateGame : IUseCaseWriter<DtoOutputGame, DtoInputCreateGame>
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public UseCaseCreateGame(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public DtoOutputGame Execute(DtoInputCreateGame input)
    {
        var dbGame = _gameRepository.Create(input.Name, input.MinutesForCompletion, input.SupportId);
        return _mapper.Map<DtoOutputGame>(dbGame);
    }
}