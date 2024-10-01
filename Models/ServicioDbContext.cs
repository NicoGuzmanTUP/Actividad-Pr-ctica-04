using Microsoft.EntityFrameworkCore;

namespace GestionTurnosPeluqueria.Models
{
    public class ServicioDbContext : DbContext
    {
        public DbSet<Servicio> servicios {  get; set; }
        public DbSet<DetalleTurno> detalles { get; set; }
        public DbSet<Turno> turnos { get; set; }
        public ServicioDbContext(DbContextOptions<ServicioDbContext> options) : base(options) 
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Relacion 1:1  entre Servicio y DetalleTurno
            modelBuilder.Entity<Servicio>()
                .HasOne(s => s.DetalleTurno)  // Un Servicio tiene un DetalleTurno
                .WithOne(d => d.Servicio)  // Un DetalleTurno tiene un Servicio
                .HasForeignKey<DetalleTurno>(d => d.ServicioId);  // La clave foránea en DetalleTurno es ServicioId


            // Relación 1:N entre Turno y DetalleTurno
            modelBuilder.Entity<Turno>()
                .HasMany(t => t.DetallesTurno)  // Un Turno tiene muchos DetallesTurno
                .WithOne(d => d.Turno)          // Un DetalleTurno tiene un Turno
                .HasForeignKey(d => d.TurnoId); // Clave foránea en DetalleTurno
        }

    
    }
}
