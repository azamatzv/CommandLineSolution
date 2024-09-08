using AutoMapper;
using CommandLine.Data;
using CommandLine.Dtos;
using CommandLine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandLine.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ICommandAPIRepo _commandAPIRepo;
    private readonly IMapper _mapper;

    public CommandsController(ICommandAPIRepo commandAPIRepo, IMapper mapper)
    {
        _commandAPIRepo = commandAPIRepo;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<IActionResult> CreateCommand(CommandCreatedDto commandCreatedDto)
    {
        var commandModel = _mapper.Map<Command>(commandCreatedDto);

        await _commandAPIRepo.CreateCommandAsync(commandModel);

        await _commandAPIRepo.SaveChangesAsync();

        var commandReadDto = _mapper.Map<CommandReadDto>(commandCreatedDto);

        return Created("", commandModel);
    }


    [HttpGet]
    public async Task<IActionResult> GetCommand()
    {
        var commands = await _commandAPIRepo.GetAllCommandsAsync();

        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommandById(int id)
    {
        var command = await _commandAPIRepo.GetCommandByIdAsync(id);

        if (command == null)
            return NotFound();

        return Ok(_mapper.Map<CommandReadDto>(command));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommand(int id)
    {
        var commandModelFromRepo = await _commandAPIRepo.GetCommandByIdAsync(id);

        if (commandModelFromRepo == null)
            return NotFound();

        _commandAPIRepo.DeleteCommand(commandModelFromRepo);

        await _commandAPIRepo.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCommand(int id, CommandUpdateDto updateDto)
    {
        var commandModelFromRepo = await _commandAPIRepo.GetCommandByIdAsync(id);

        if (commandModelFromRepo == null)
            return NotFound();

        _mapper.Map(updateDto, commandModelFromRepo);
        
        await _commandAPIRepo.UpdateCommandAsync(commandModelFromRepo);

        await _commandAPIRepo.SaveChangesAsync();

        return NoContent();
    }
}