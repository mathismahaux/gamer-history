using Application.UseCases.Support.Dtos;
using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Support;

public class UseCaseFetchSupportById : IUseCaseParametrizedQuery<DtoOutputSupport, int>
{
    private readonly ISupportRepository _supportRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchSupportById(IMapper mapper, ISupportRepository supportRepository)
    {
        _mapper = mapper;
        _supportRepository = supportRepository;
    }

    public DtoOutputSupport Execute(int id)
    {
        var dbUser = _supportRepository.FetchById(id);
        return _mapper.Map<DtoOutputSupport>(dbUser);
    }
}