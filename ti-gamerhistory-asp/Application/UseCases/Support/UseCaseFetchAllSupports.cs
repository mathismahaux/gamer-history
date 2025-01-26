using Application.UseCases.Support.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Support;

public class UseCaseFetchAllSupports : IUseCaseQuery<IEnumerable<DtoOutputSupport>>
{
    private readonly ISupportRepository _supportRepository;
    private readonly IMapper _mapper;
    
    public UseCaseFetchAllSupports(ISupportRepository supportRepository, IMapper mapper)
    {
        _supportRepository = supportRepository;
        _mapper = mapper;
    }
    
    public IEnumerable<DtoOutputSupport> Execute()
    {
        var supports = _supportRepository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputSupport>>(supports);
    }
}