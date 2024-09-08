using CommandLine.Models;
using System.Collections;

namespace CommandLine.Data;

public interface ICommandAPIRepo
{
    Task<IEnumerable<Command>> GetAllCommandsAsync();

    Task<Command> GetCommandByIdAsync(int id);

    Task CreateCommandAsync(Command command);

    Task UpdateCommandAsync(Command command);

    void DeleteCommand(Command command);

    public Task<bool> SaveChangesAsync();
}
