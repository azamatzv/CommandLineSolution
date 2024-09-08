using CommandLine.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandLine.Data;

public class CommandAPIRepo : ICommandAPIRepo
{
    private readonly CommandContext _context;
    public CommandAPIRepo(CommandContext commandContext)
    {
        this._context = commandContext;
    }

    public async Task CreateCommandAsync(Command command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        await _context.Commands.AddAsync(command);
    }

    public void DeleteCommand(Command command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        _context.Commands.Remove(command);
    }

    public async Task<IEnumerable<Command>> GetAllCommandsAsync()
    {
        return await _context.Commands.ToListAsync();
    }

    public async Task<Command> GetCommandByIdAsync(int id)
    {
        return await _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task UpdateCommandAsync(Command command)
    {
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }

  
}
