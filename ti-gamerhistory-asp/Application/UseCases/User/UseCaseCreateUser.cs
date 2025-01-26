using Application.UseCases.User.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.User;

public class UseCaseCreateUser : IUseCaseWriter<DtoOutputUser, DtoInputCreateUser>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UseCaseCreateUser(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public DtoOutputUser Execute(DtoInputCreateUser input)
    {
        var dbUser = _userRepository.Create(input.Pseudo, input.Email, input.Password, input.Role);
        return _mapper.Map<DtoOutputUser>(dbUser);
    }
}