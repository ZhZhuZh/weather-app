using FirstApp.Cmd;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Infrastructure;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<MoscowWeatherByDate> MoscowWeatherByDate { get; set; }
}
