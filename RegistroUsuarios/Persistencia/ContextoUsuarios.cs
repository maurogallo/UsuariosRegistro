using Microsoft.EntityFrameworkCore;
using RegistroUsuarios.Modelo;
using System.Collections.Generic;

namespace RegistroUsuarios.Persistencia
{
    public class ContextoUsuarios : DbContext
    {
        public ContextoUsuarios(DbContextOptions<ContextoUsuarios> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Usuarios> Usuarios { get; set; }

        

    }
}
