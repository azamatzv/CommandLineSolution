using CommandLine.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandLine.Data;

public class CommandContext : DbContext
{
    public CommandContext(DbContextOptions<CommandContext> option) 
        : base(option)
    {

    }

    public DbSet<Command> Commands { get; set; }

}
