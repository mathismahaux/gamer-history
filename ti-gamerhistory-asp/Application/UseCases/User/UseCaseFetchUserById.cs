using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.User;

public class UseCaseFetchUserById : IUseCaseParametrizedQuery<DtoOutputUser, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchUserById(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public DtoOutputUser Execute(int id)
    {
        var dbUser = _userRepository.FetchById(id);
        return _mapper.Map<DtoOutputUser>(dbUser);
    }
}