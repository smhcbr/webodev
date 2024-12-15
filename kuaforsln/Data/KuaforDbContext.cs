using Microsoft.EntityFrameworkCore;

namespace kuaforsln.Data;

public class KuaforDbContext:DbContext
{
    public KuaforDbContext(DbContextOptions<KuaforDbContext> options) : base(options)
    {
        throw new NotImplementedException();
    }
}