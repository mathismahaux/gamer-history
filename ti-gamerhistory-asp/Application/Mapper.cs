using Application.UseCases.Game.Dtos;
using Application.UseCases.GameSession.Dtos;
using Application.UseCases.Support.Dtos;
using Application.UseCases.User.Dtos;
using AutoMapper;
using Domain;
using Infrastructure.Ef.DbEntities;
using DtoOutputGame = Application.UseCases.Game.Dtos.DtoOutputGame;

namespace Application;

public class Mapper : Profile
{
    public Mapper()
    {
        // Game
        CreateMap<DtoInputCreateGame, Game>();
        CreateMap<Game, DtoOutputGame>();
        CreateMap<DbGame, Game>();
        CreateMap<DbGame, DtoOutputGame>();
        
        // User
        CreateMap<DtoInputCreateUser, User>();
        CreateMap<User, DtoOutputUser>();
        CreateMap<DbUser, User>();
        CreateMap<DbUser, DtoOutputUser>();
        
        // Support
        CreateMap<Support, DtoOutputSupport>();
        CreateMap<DbSupport, Support>();
        CreateMap<DbSupport, DtoOutputSupport>();
        
        // GameSession
        CreateMap<GameSession, DtoOutputGameSession>();
        CreateMap<DbGameSession, GameSession>();
        CreateMap<DbGameSession, DtoOutputGameSession>();
        
        CreateMap<DbUserHistory, DtoOutputUserHistory>();

    }
}