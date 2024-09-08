using AutoMapper;
using CommandLine.Models;

namespace CommandLine.Dtos;

public class CommandsProfile : Profile
{
    public CommandsProfile()
    {
        CreateMap<CommandCreatedDto, Command>();
        CreateMap<CommandUpdateDto, Command>();
        CreateMap<Command, CommandReadDto>();
    }
}