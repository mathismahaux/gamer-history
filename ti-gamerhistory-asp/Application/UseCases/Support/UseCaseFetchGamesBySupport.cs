using Application.UseCases.Game.Dtos;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Support;

public class UseCaseFetchGamesBySupport
{
    private readonly IGameRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseFetchGamesBySupport(IGameRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public IEnumerable<DtoOutputGame> Execute(int supportId)
    {
        var games = _repository.FetchGamesBySupport(supportId);
        return _mapper.Map<IEnumerable<DtoOutputGame>>(games);
    }
}